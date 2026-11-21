using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiberSesCoz
{
    public partial class Form1 : Form
    {
        private readonly List<string> selectedFiles = new List<string>();
        private string outputFolderPath = "";
        private string lastConvertedFilePath = "";
        private CancellationTokenSource cancellationTokenSource;
        private Process activeProcess;
        private bool isConverting;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            outputFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txtOutputFolder.Text = outputFolderPath;
            cmbQuality.SelectedIndex = 1;
            UpdateListButtons();
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.Filter = "Ses ve Video Dosyaları|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.mp3;*.wav;*.m4a;*.aac;*.flac;*.wma|Tüm Dosyalar|*.*";
                dialog.Title = "Dönüştürülecek Dosyaları Seçin";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                foreach (string file in dialog.FileNames)
                {
                    if (!selectedFiles.Contains(file, StringComparer.OrdinalIgnoreCase))
                        selectedFiles.Add(file);
                }

                RefreshFileList();
                if (lstFiles.Items.Count > 0)
                    lstFiles.Items[0].Selected = true;
            }
        }

        private void RefreshFileList()
        {
            lstFiles.BeginUpdate();
            try
            {
                lstFiles.Items.Clear();
                foreach (string file in selectedFiles)
                {
                    var info = new FileInfo(file);
                    var item = new ListViewItem(info.Name);
                    item.SubItems.Add(FormatFileSize(info.Length));
                    item.SubItems.Add("Bekliyor");
                    item.Tag = file;
                    lstFiles.Items.Add(item);
                }
            }
            finally
            {
                lstFiles.EndUpdate();
            }

            UpdateListButtons();
        }

        private void LstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItems.Count == 0)
                return;

            string file = lstFiles.SelectedItems[0].Tag as string;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
                return;

            var info = new FileInfo(file);
            txtFilePath.Text = file;
            txtFileName.Text = info.Name;
            txtFileSize.Text = FormatFileSize(info.Length);
        }

        private void BtnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItems.Count == 0)
                return;

            string file = lstFiles.SelectedItems[0].Tag as string;
            selectedFiles.Remove(file);
            RefreshFileList();
        }

        private void BtnClearFiles_Click(object sender, EventArgs e)
        {
            if (selectedFiles.Count == 0)
                return;

            selectedFiles.Clear();
            RefreshFileList();
            txtFilePath.Clear();
            txtFileName.Clear();
            txtFileSize.Clear();
        }

        private void UpdateListButtons()
        {
            bool hasFiles = selectedFiles.Count > 0;
            btnRemoveFile.Enabled = hasFiles && !isConverting;
            btnClearFiles.Enabled = hasFiles && !isConverting;
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double size = bytes;
            int order = 0;
            while (size >= 1024 && order < sizes.Length - 1)
            {
                size /= 1024;
                order++;
            }
            return string.Format(CultureInfo.InvariantCulture, "{0:0.##} {1}", size, sizes[order]);
        }

        private void BtnSelectOutputFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Kayıt klasörünü seçin";
                dialog.SelectedPath = outputFolderPath;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    outputFolderPath = dialog.SelectedPath;
                    txtOutputFolder.Text = outputFolderPath;
                }
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            if (selectedFiles.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir dosya seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(outputFolderPath))
            {
                MessageBox.Show("Lütfen geçerli bir kayıt klasörü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bitrate = (cmbQuality.SelectedItem ?? "192 kbps").ToString().Split(' ')[0];
            cancellationTokenSource = new CancellationTokenSource();
            ConvertFilesAsync(bitrate, cancellationTokenSource.Token);
        }

        private async void ConvertFilesAsync(string bitrate, CancellationToken cancellationToken)
        {
            isConverting = true;
            SetControlsForConversion(true);
            progressBar.Value = 0;
            txtStatus.Clear();
            int completed = 0;

            try
            {
                string ffmpegPath = FindFFmpeg();
                if (string.IsNullOrEmpty(ffmpegPath))
                    throw new Exception("FFmpeg bulunamadı. ffmpeg.exe dosyasını uygulamanın yanına veya ffmpeg\\bin klasörüne koyun ya da PATH değişkenine ekleyin.");

                AppendStatus("FFmpeg bulundu: " + ffmpegPath);
                foreach (string file in selectedFiles.ToList())
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    SetFileStatus(file, "İşleniyor");
                    AppendStatus("Dönüştürülüyor: " + Path.GetFileName(file));
                    bool converted = await Task.Run(() => ConvertSingleFile(ffmpegPath, file, bitrate, cancellationToken), cancellationToken);
                    if (converted)
                        SetFileStatus(file, "Tamamlandı");
                    completed++;
                    progressBar.Value = (int)((completed * 100L) / selectedFiles.Count);
                }

                lastConvertedFilePath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(selectedFiles[selectedFiles.Count - 1]) + ".mp3");
                btnOpenFolder.Enabled = true;
                AppendStatus("Tüm dosyalar başarıyla dönüştürüldü.");
                MessageBox.Show("Toplu dönüştürme tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                AppendStatus("Dönüştürme işlemi iptal edildi.");
            }
            catch (Exception ex)
            {
                AppendStatus("Hata: " + ex.Message);
                MessageBox.Show("Dönüştürme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isConverting = false;
                SetControlsForConversion(false);
            }
        }

        private bool ConvertSingleFile(string ffmpegPath, string inputPath, string bitrate, CancellationToken cancellationToken)
        {
            string outputPath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(inputPath) + ".mp3");
            if (File.Exists(outputPath) && !AskOverwrite(outputPath))
            {
                SetFileStatus(inputPath, "Atlandı");
                return false;
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = ffmpegPath,
                Arguments = string.Format("-i \"{0}\" -vn -codec:a libmp3lame -b:a {1}k -y \"{2}\"", inputPath, bitrate, outputPath),
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            try
            {
                using (var process = new Process { StartInfo = startInfo })
                {
                    activeProcess = process;
                    process.Start();
                    string line;
                    while ((line = process.StandardError.ReadLine()) != null)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        AppendStatus(line);
                    }
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                        throw new Exception("FFmpeg hata kodu: " + process.ExitCode);
                }
            }
            catch (OperationCanceledException)
            {
                if (File.Exists(outputPath))
                    File.Delete(outputPath);
                throw;
            }
            catch (IOException) when (cancellationToken.IsCancellationRequested)
            {
                if (File.Exists(outputPath))
                    File.Delete(outputPath);
                throw new OperationCanceledException(cancellationToken);
            }
            finally
            {
                activeProcess = null;
            }

            if (!File.Exists(outputPath))
                throw new Exception("Çıktı dosyası oluşturulamadı: " + Path.GetFileName(inputPath));
            lastConvertedFilePath = outputPath;
            return true;
        }

        private bool AskOverwrite(string outputPath)
        {
            DialogResult result = DialogResult.No;
            Action ask = () => result = MessageBox.Show("'" + Path.GetFileName(outputPath) + "' zaten var. Üzerine yazılsın mı?", "Dosya Zaten Var", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (InvokeRequired)
                Invoke(ask);
            else
                ask();
            return result == DialogResult.Yes;
        }

        private void SetFileStatus(string file, string status)
        {
            Action update = () =>
            {
                foreach (ListViewItem item in lstFiles.Items)
                {
                    if (string.Equals(item.Tag as string, file, StringComparison.OrdinalIgnoreCase))
                    {
                        item.SubItems[2].Text = status;
                        break;
                    }
                }
            };
            if (InvokeRequired) Invoke(update); else update();
        }

        private void SetControlsForConversion(bool converting)
        {
            btnConvert.Enabled = !converting;
            btnCancel.Enabled = converting;
            btnSelectFile.Enabled = !converting;
            btnSelectOutputFolder.Enabled = !converting;
            cmbQuality.Enabled = !converting;
            btnOpenFolder.Enabled = !converting && File.Exists(lastConvertedFilePath);
            UpdateListButtons();
        }

        private string FindFFmpeg()
        {
            var candidates = new List<string>
            {
                Path.Combine(Application.StartupPath, "ffmpeg.exe"),
                Path.Combine(Application.StartupPath, "ffmpeg", "bin", "ffmpeg.exe"),
                Path.Combine(Application.StartupPath, "tools", "ffmpeg", "bin", "ffmpeg.exe")
            };
            string path = Environment.GetEnvironmentVariable("PATH");
            if (!string.IsNullOrWhiteSpace(path))
                candidates.AddRange(path.Split(Path.PathSeparator).Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => Path.Combine(p.Trim(), "ffmpeg.exe")));
            candidates.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "ffmpeg", "bin", "ffmpeg.exe"));
            candidates.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "ffmpeg", "bin", "ffmpeg.exe"));
            return candidates.Distinct(StringComparer.OrdinalIgnoreCase).FirstOrDefault(File.Exists);
        }

        private void AppendStatus(string message)
        {
            Action append = () =>
            {
                txtStatus.AppendText(message + Environment.NewLine);
                txtStatus.SelectionStart = txtStatus.TextLength;
                txtStatus.ScrollToCaret();
            };
            if (txtStatus.InvokeRequired) txtStatus.BeginInvoke(append); else append();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource == null)
                return;
            cancellationTokenSource.Cancel();
            if (activeProcess != null && !activeProcess.HasExited)
            {
                try { activeProcess.Kill(); } catch { }
            }
            AppendStatus("İptal isteği gönderildi.");
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastConvertedFilePath) && File.Exists(lastConvertedFilePath))
                Process.Start("explorer.exe", "/select, \"" + lastConvertedFilePath + "\"");
            else if (Directory.Exists(outputFolderPath))
                Process.Start(outputFolderPath);
        }
    }
}
