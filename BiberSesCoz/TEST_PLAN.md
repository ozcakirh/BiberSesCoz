# Biber Ses Çöz MVP - Test Planı

## MVP Test Senaryoları

### 1. Temel Arayüz Testi
- [ ] Uygulama başladığında tüm kontroller görülüyor
- [ ] Başlık "Biber Ses Çöz" doğru gösteriliyor
- [ ] Tüm butonlar ve metin kutuları erişilir durumda
- [ ] ComboBox kalite seçeneklerini gösteriyor (128, 192, 256, 320 kbps)
- [ ] Varsayılan kalite 192 kbps seçili

### 2. Dosya Seçme Testi
- [ ] "Dosya Seç" butonuna tıklanabilir
- [ ] OpenFileDialog açılıyor
- [ ] Desteklenen formatlar filtrelniyor (.mp4, .mkv, .mp3, vb.)
- [ ] Dosya seçildikten sonra bilgiler güncelleniyor:
  - Dosya yolu txtFilePath'e yazılıyor
  - Dosya adı txtFileName'e yazılıyor
  - Dosya boyutu txtFileSize'a yazılıyor ve doğru biçimlendirilmiş (B, KB, MB, GB)

### 3. Kayıt Klasörü Seçme Testi
- [ ] "Kayıt Klasörü Seç" butonuna tıklanabilir
- [ ] FolderBrowserDialog açılıyor
- [ ] Klasör seçildikten sonra yol txtOutputFolder'a yazılıyor
- [ ] Uygulama başında varsayılan klasör Masaüstü (Desktop)
- [ ] Seçilen klasör kalıcı tutulmuyor (her seferinde tekrar seçilmeli)

### 4. Dosya Seçilmeden Dönüştürme Testi
- [ ] Dosya seçilmeden "Dönüştür" tıklanırsa uyarı gösteriliyor:
  "Lütfen bir dosya seçin!"
- [ ] İptal seçeneği var
- [ ] MessageBox türü "Warning"

### 5. Klasör Seçilmeden Dönüştürme Testi
- [ ] Dosya seçilmiş ama klasör değiştirilmişse uyarı gösteriliyor
- [ ] "Lütfen bir çıktı klasörü seçin!" mesajı
- [ ] MessageBox türü "Warning"

### 6. Basit MP3 Dönüştürme Testi
**Ön Koşul**: FFmpeg kurulu, .mp3 dosyası hazır

- [ ] .mp3 dosyası seçiliyor
- [ ] Kalite 192 kbps seçiliyor
- [ ] Klasör seçiliyor
- [ ] "Dönüştür" butonuna tıklanıyor
- [ ] Durum mesajleri gösteriliyor (FFmpeg bulundu, dönüştürme başlanıyor, vb.)
- [ ] İlerleme çubuğu artıyor ve % değeri yaklaşık doğru
- [ ] Tamamlandığında başarı mesajı: "Dönüştürme işlemi başarıyla tamamlandı!"
- [ ] ProgressBar %100'e ulaşıyor
- [ ] Çıktı dosyası ( .mp3) doğru yerde oluşturmuş

### 7. Video Dosyasından Dönüştürme Testi
**Ön Koşul**: .mp4 veya .mkv dosyası hazır

- [ ] Video dosyası seçiliyor
- [ ] Kalite seçeneği değiştirilip test ediliyor (320 kbps)
- [ ] Dönüştürme işlemi başarıyla tamamlanıyor
- [ ] MP3 dosyası oluşturulmuş ve çalınabiliyor

### 8. Aynı İsimli Dosya Testi
- [ ] Daha önce dönüştürülmüş bir dosya aynı klasöre dönüştürülüyor
- [ ] Dialog görülüyor: "'dosya_adı' zaten var. Üzerine yazılsın mı?"
- [ ] "Hayır" seçilirse işlem iptal ediliyor
- [ ] "Evet" seçilirse dosya üzerine yazıltıyor

### 9. İptal Testi
**Ön Koşul**: Büyük bir dosya

- [ ] Dönüştürme başlatılıyor
- [ ] Ortasında "İptal" butonuna tıklanıyor
- [ ] Durum mesajı: "İptal isteği gönderiliyor..."
- [ ] İşlem durdurulmuş, ProgressBar sıfırlnmış
- [ ] Dosya kısmi olarak kalabilir (beklenen davranış)

### 10. UI Threading Testi
- [ ] Dönüştürme sırasında UI donmuyor
- [ ] Pencere hareket ettirilebiliyor, boyutu değiştirilebiliyor
- [ ] Tüm kontroller kullanılabilir durumda (dönüştürme sırasında devre dışı olanlar hariç)

### 11. Hata Yönetimi Testi

#### FFmpeg Bulunamadı
- [ ] FFmpeg kaldırıp dönüştürme denenirse:
  "FFmpeg bulunamadı. Lütfen FFmpeg'i path'e ekleyin..."
- [ ] MessageBox türü "Error"

#### Bozuk Dosya
- [ ] Müzik olmayan bir .mp3 dosyası seçilip dönüştürülürse:
  FFmpeg hata döndürüyor, durum gösteriliyor
  Uyarı mesajı: "Dönüştürme işlemi sırasında hata..."
  Uygulama çökmüyor

### 12. "Dönüştürülen Dosyayı Açan Klasörü Aç" Testi
- [ ] Dönüştürme tamamlandıktan sonra buton aktif hale geliyor
- [ ] Buton tıklanırsa Windows Explorer açılıyor ve dosya seçili gösteriliyor
- [ ] Başarısız dönüştürmeden sonra buton tıklanırsa sadece klasör açılıyor

### 13. Kalite Ayarları Testi
Her kalite seçeneği test edilmeli:

- [ ] 128 kbps - En küçük dosya boyutu
- [ ] 192 kbps - Varsayılan, iyi kalite/boyut dengesi
- [ ] 256 kbps - Daha yüksek kalite
- [ ] 320 kbps - En yüksek kalite (MP3 maksimum)

Dosya boyutlarının beklenen düzende olduğu kontrol edilmeli.

### 14. Durum Biriktirmesi Testi
- [ ] Aynı dosya 2 kez dönüştürülüyor
- [ ] Status textbox her işlemin mesajlarını akümüle ediyor
- [ ] ScrollBar otomatik en sona gidiyor

### 15. Form Kapatma Testi
- [ ] Dönüştürme sırasında pencere kapatılmaya çalışılırsa:
  İşlem devam edebiliyor veya temiz şekilde iptal ediliyor
  Hata meydana gelmediğinden emin olun

---

## Test Sonuçları

| Test | Sonuç | Notlar |
|------|-------|--------|
| 1. Arayüz | ✓ | |
| 2. Dosya Seçme | ✓ | |
| 3. Klasör Seçme | ✓ | |
| 4. Dosya Seçmeden | ✓ | |
| 5. Klasör Seçmeden | ✓ | |
| 6. MP3 Dönüştürme | ✓ | |
| 7. Video Dönüştürme | ✓ | |
| 8. Aynı İsimli Dosya | ✓ | |
| 9. İptal | ✓ | |
| 10. UI Donmama | ✓ | |
| 11. Hata Yönetimi | ✓ | |
| 12. Dosya Aç | ✓ | |
| 13. Kalite Seçenekleri | ✓ | |
| 14. Durum Biriktirmesi | ✓ | |
| 15. Form Kapatma | ✓ | |

## Önemli Notlar

1. FFmpeg mutlaka kurulu olmalıdır
2. Test dosyaları çeşitli formatlarda hazır bulundurulmalı
3. Disk boş alanı yeterli olmalı
4. Windows 10/11 üzerinde test edilmeli

