# Biber Ses Çöz - MVP (İlk Kullanılabilir Sürüm)

Windows masaüstü ses dönüştürme uygulaması

## Sistem Gereksinimleri

- Windows 10 veya Windows 11
- .NET Framework 4.8
- FFmpeg (sistem PATH'ine kurulu veya uygulamanın yanında)

## FFmpeg Kurulumu

### Yöntem 1: Sistem PATH'ine Ekleme (Önerilir)

1. [FFmpeg web sitesinden](https://ffmpeg.org/download.html) Windows build'ini indirin
2. FFmpeg'i çıkarın ve `bin` klasörünü bulun
3. Windows Ortam Değişkenine `ffmpeg.exe`'nin bulunduğu klasörü PATH'e ekleyin
4. Terminali yeniden açıp `ffmpeg -version` komutu çalıştırarak kurulumu doğrulayın

### Yöntem 2: Uygulamanın Yanında

1. FFmpeg'i indirin ve çıkarın
2. `ffmpeg.exe` dosyasını uygulamanın `bin\Debug` veya `bin\Release` klasörüne kopyalayın

## Desteklenen Dosya Formatları

### Giriş Formatları
- Video: MP4, MKV, AVI, MOV, WEBM
- Ses: MP3, WAV, M4A, AAC, FLAC, WMA

### Çıkış Formatı
- MP3 (128, 192, 256, 320 kbps)

## Nasıl Kullanılır

1. **Dosya Seç (Çoklu)**: Bir veya daha fazla video/ses dosyası seçin
2. **Dosya Listesi**: Seçilen dosyalar ad, boyut ve durum bilgileriyle listelenir
3. **Kalite Seç**: Çıkış MP3 kalitesini seçin (varsayılan: 192 kbps)
4. **Kayıt Klasörü**: MP3 dosyasını kaydedecek klasörü seçin
5. **Dönüştür**: Dosyalar listedeki sıraya göre dönüştürülür
6. **İşlem İzleme**: Dosya durumları ve genel ilerleme çubuğundan işlemi takip edin
7. **İptal**: İşlem devam ederken İptal butonuyla aktif FFmpeg sürecini durdurabilirsiniz

Seçili dosyayı **Seçili Dosyayı Sil** ile listeden çıkarabilir, **Listeyi Temizle** ile tüm listeyi sıfırlayabilirsiniz.

## MVP Özellikleri (v0.1)

✓ Çoklu dosya seçme (OpenFileDialog)
✓ Dosya listesi (ad, boyut, işlem durumu)
✓ Kalite seçimi (128, 192, 256, 320 kbps)
✓ Sırayla toplu dönüştürme
✓ FFmpeg entegrasyonu
✓ Asenkron işlem (UI donmama)
✓ İşlem ilerleme takibi
✓ İptal işlevselliği
✓ Hata mesajları (Türkçe)
✓ Dönüştürülen dosyayı klasörde açma

## Bilinen Sınırlamalar

- Genel ilerleme dosya bazında hesaplanır; tek dosyanın iç ilerlemesi ayrıca gösterilmez
- Aynı isimli çıktı dosyalarında kullanıcıdan üzerine yazma onayı istenir

## Gelecek Sürümlerde Planlanmış

- Daha gelişmiş FFmpeg seçenekleri
- Ses ekinleştirme
- Başka ses formatlarına dönüştürme (FLAC, WAV, vb.)

## Sorun Gidermek

### "FFmpeg bulunamadı" Hatası
- FFmpeg'i indirip sistem PATH'ine ekleyin veya uygulamanın yanına kopyalayın

### "Dosya oluşturulamadı" Hatası
- Kayıt klasörünün yazma iznine sahip olduğundan emin olun
- Disk boş alanı kontrol edin

### Dönüştürme Başarısız Oldu
- Dosyanın bozuk olmadığından emin olun
- FFmpeg'in doğru kurulu olduğunu kontrol edin
- Status penceresindeki hata mesajını okuyun

## Lisans

FFmpeg GPL/LGPL lisansı altında sağlanmaktadır. Uygulamanı dağıtırken FFmpeg lisansa uygun şekilde sunmalısınız.

---

Geliştirme: .NET Framework 4.8 ile C# ve Windows Forms
