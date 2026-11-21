namespace BiberSesCoz
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.lblQuality = new System.Windows.Forms.Label();
            this.cmbQuality = new System.Windows.Forms.ComboBox();
            this.btnSelectOutputFolder = new System.Windows.Forms.Button();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListView();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnClearFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(152, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Biber Ses Çöz";

            // btnSelectFile
            this.btnSelectFile.Location = new System.Drawing.Point(12, 49);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(100, 23);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Dosya Seç (Çoklu)";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.BtnSelectFile_Click);

            // lstFiles
            this.lstFiles.FullRowSelect = true;
            this.lstFiles.GridLines = true;
            this.lstFiles.HideSelection = false;
            this.lstFiles.Location = new System.Drawing.Point(12, 80);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(544, 140);
            this.lstFiles.TabIndex = 19;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.Details;
            this.lstFiles.Columns.Add("Dosya Adı", 260);
            this.lstFiles.Columns.Add("Boyut", 100);
            this.lstFiles.Columns.Add("Durum", 160);
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.LstFiles_SelectedIndexChanged);

            // btnRemoveFile
            this.btnRemoveFile.Location = new System.Drawing.Point(12, 225);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(130, 23);
            this.btnRemoveFile.TabIndex = 20;
            this.btnRemoveFile.Text = "Seçili Dosyayı Sil";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.BtnRemoveFile_Click);

            // btnClearFiles
            this.btnClearFiles.Location = new System.Drawing.Point(148, 225);
            this.btnClearFiles.Name = "btnClearFiles";
            this.btnClearFiles.Size = new System.Drawing.Size(110, 23);
            this.btnClearFiles.TabIndex = 21;
            this.btnClearFiles.Text = "Listeyi Temizle";
            this.btnClearFiles.UseVisualStyleBackColor = true;
            this.btnClearFiles.Click += new System.EventHandler(this.BtnClearFiles_Click);

            // lblFilePath
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(12, 260);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(53, 13);
            this.lblFilePath.TabIndex = 2;
            this.lblFilePath.Text = "Dosya Yolu:";

            // txtFilePath
            this.txtFilePath.Location = new System.Drawing.Point(12, 276);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(544, 20);
            this.txtFilePath.TabIndex = 3;

            // lblFileName
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 305);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(60, 13);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "Dosya Adı:";

            // txtFileName
            this.txtFileName.Location = new System.Drawing.Point(12, 321);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(544, 20);
            this.txtFileName.TabIndex = 5;

            // lblFileSize
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(12, 350);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(64, 13);
            this.lblFileSize.TabIndex = 6;
            this.lblFileSize.Text = "Dosya Boyutu:";

            // txtFileSize
            this.txtFileSize.Location = new System.Drawing.Point(12, 366);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.ReadOnly = true;
            this.txtFileSize.Size = new System.Drawing.Size(544, 20);
            this.txtFileSize.TabIndex = 7;

            // lblQuality
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(12, 395);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(51, 13);
            this.lblQuality.TabIndex = 8;
            this.lblQuality.Text = "Kalite:";

            // cmbQuality
            this.cmbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuality.FormattingEnabled = true;
            this.cmbQuality.Items.AddRange(new object[] {
            "128 kbps",
            "192 kbps",
            "256 kbps",
            "320 kbps"});
            this.cmbQuality.Location = new System.Drawing.Point(12, 411);
            this.cmbQuality.Name = "cmbQuality";
            this.cmbQuality.Size = new System.Drawing.Size(544, 21);
            this.cmbQuality.TabIndex = 9;
            this.cmbQuality.SelectedIndex = 1; // Default: 192 kbps

            // btnSelectOutputFolder
            this.btnSelectOutputFolder.Location = new System.Drawing.Point(12, 438);
            this.btnSelectOutputFolder.Name = "btnSelectOutputFolder";
            this.btnSelectOutputFolder.Size = new System.Drawing.Size(159, 23);
            this.btnSelectOutputFolder.TabIndex = 10;
            this.btnSelectOutputFolder.Text = "Kayıt Klasörü Seç";
            this.btnSelectOutputFolder.UseVisualStyleBackColor = true;
            this.btnSelectOutputFolder.Click += new System.EventHandler(this.BtnSelectOutputFolder_Click);

            // lblOutputFolder
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(12, 464);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(79, 13);
            this.lblOutputFolder.TabIndex = 11;
            this.lblOutputFolder.Text = "Kayıt Klasörü:";

            // txtOutputFolder
            this.txtOutputFolder.Location = new System.Drawing.Point(12, 480);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.ReadOnly = true;
            this.txtOutputFolder.Size = new System.Drawing.Size(544, 20);
            this.txtOutputFolder.TabIndex = 12;

            // btnConvert
            this.btnConvert.Location = new System.Drawing.Point(12, 506);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(100, 23);
            this.btnConvert.TabIndex = 13;
            this.btnConvert.Text = "Dönüştür";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(12, 535);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(544, 23);
            this.progressBar.TabIndex = 14;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 561);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 13);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Durum:";

            // txtStatus
            this.txtStatus.Location = new System.Drawing.Point(12, 577);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(544, 60);
            this.txtStatus.TabIndex = 16;

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(118, 506);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Enabled = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // btnOpenFolder
            this.btnOpenFolder.Location = new System.Drawing.Point(224, 506);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(332, 23);
            this.btnOpenFolder.TabIndex = 18;
            this.btnOpenFolder.Text = "Dönüştürülen Dosyayı Açan Klasörü Aç";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Enabled = false;
            this.btnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 649);
            this.Controls.Add(this.btnClearFiles);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.lblOutputFolder);
            this.Controls.Add(this.btnSelectOutputFolder);
            this.Controls.Add(this.cmbQuality);
            this.Controls.Add(this.lblQuality);
            this.Controls.Add(this.txtFileSize);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Biber Ses Çöz";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.ComboBox cmbQuality;
        private System.Windows.Forms.Button btnSelectOutputFolder;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.Button btnClearFiles;
    }
}

