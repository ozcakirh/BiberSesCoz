# 🌶️ Biber Ses Çöz (BiberSesCoz)

**Biber Ses Çöz**, FFmpeg altyapısını kullanarak video ve ses dosyalarından yüksek hızda ve toplu olarak MP3 formatında ses ayrıştırma/dönüştürme işlemi yapan, Windows için geliştirilmiş hafif bir masaüstü uygulamasıdır[cite: 2, 3, 4].

---

## ✨ Özellikler

* **Toplu (Çoklu) Dosya Dönüştürme:** Birden fazla video veya ses dosyasını aynı anda kuyruğa ekleyip tek tıkla dönüştürebilirsiniz.
* **Geniş Format Desteği:** `.mp4`, `.mkv`, `.avi`, `.mov`, `.webm`, `.mp3`, `.wav`, `.m4a`, `.aac`, `.flac` ve `.wma` uzantılı dosyaları destekler.
* **Seçilebilir Ses Kalitesi (Bitrate):** Çıktı kalitesini ihtiyacınıza göre **128 kbps**, **192 kbps** (varsayılan), **256 kbps** veya **320 kbps** olarak ayarlayabilirsiniz[cite: 3, 4].
* **Akıllı FFmpeg Algılama:** Uygulama; kendi çalışma dizinini, alt klasörleri (`ffmpeg\bin`, `tools\ffmpeg\bin`), `Program Files` dizinini ve sistem `PATH` değişkenini otomatik tarayarak `ffmpeg.exe` dosyasını bulur.
* **Asenkron İşlem ve Canlı İlerleme:** Arka planda asenkron olarak çalışır; arayüz donmadan ilerleme çubuğunu, dosya bazlı durumları (*Bekliyor, İşleniyor, Tamamlandı, Atlandı*) ve canlı FFmpeg günlüklerini takip edebilirsiniz[cite: 3].
* **Güvenli İptal ve Üzerine Yazma Kontrolü:** Devam eden işlemi anında iptal edebilir (yarım kalan dosyalar otomatik temizlenir) ve hedef klasörde aynı isimde dosya varsa üzerine yazılıp yazılmayacağını seçebilirsiniz[cite: 3].
* **Hızlı Klasör Erişimi:** Dönüştürme tamamlandığında tek tıkla Windows Gezgini üzerinden çıktı dosyasının konumunu açabilirsiniz[cite: 3, 4].

---

## 🛠️ Gereksinimler

* **İşletim Sistemi:** Windows 7 / 8 / 10 / 11
* **Çalışma Zamanı:** .NET Framework 4.8
* **Harici Bağımlılık:** [FFmpeg](https://ffmpeg.org/) (`ffmpeg.exe`)[cite: 3]

---

## 🚀 Kurulum ve Kullanım

### 1. FFmpeg Kurulumu
Uygulamanın çalışabilmesi için sisteminizde `ffmpeg.exe` bulunmalıdır[cite: 3]. Şu yöntemlerden birini kullanabilirsiniz:
* **PowerShell üzerinden hızlı kurulum:**
  ```powershell
  winget install --id=Gyan.FFmpeg -e
