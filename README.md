# Notepad Uygulaması

C# Windows Forms ve .NET Framework kullanılarak geliştirilmiş basit ve kullanışlı bir metin düzenleme uygulaması.

## 📋 Özellikler

### Dosya İşlemleri
- **Yeni Dosya**: Yeni bir metin dosyası oluşturma (Ctrl+N)
- **Dosya Aç**: Mevcut metin dosyalarını açma (Ctrl+O)
- **Kaydet**: Dosyayı kaydetme (Ctrl+S)
- **Farklı Kaydet**: Dosyayı farklı bir konuma kaydetme (Ctrl+Shift+S)
- **Çıkış**: Uygulamadan çıkış

### Düzenleme İşlemleri
- **Kopyala**: Seçili metni kopyalama (Ctrl+C)
- **Kes**: Seçili metni kesme (Ctrl+X)
- **Yapıştır**: Panodaki metni yapıştırma (Ctrl+V)
- **Hepsini Seç**: Tüm metni seçme (Ctrl+A)

### Görünüm Ayarları
- **Yazı Tipi**: Yazı tipi, boyutu ve rengini değiştirme
- **Tema**: Açık ve Koyu tema seçenekleri
  - Açık Tema: Klasik beyaz arka plan
  - Koyu Tema: Göz dostu koyu arka plan

### Güvenlik Özellikleri
- **Kaydedilmemiş Değişiklik Uyarısı**: Form kapanırken veya yeni dosya açılırken kaydedilmemiş değişiklikler için uyarı
- **UTF-8 Desteği**: Türkçe karakterler dahil tüm karakterleri destekler

## 🚀 Kurulum

### Gereksinimler
- Windows İşletim Sistemi
- .NET Framework 4.8 veya üzeri
- Visual Studio 2019 veya üzeri (geliştirme için)

### Kurulum Adımları

1. Projeyi klonlayın veya indirin:
   ```bash
   git clone <repository-url>
   cd NotePad
   ```

2. Visual Studio'da projeyi açın:
   - `NotePad.sln` dosyasını çift tıklayarak açın

3. Projeyi derleyin:
   - `Build` > `Build Solution` (Ctrl+Shift+B)
   - Veya `F5` tuşuna basarak çalıştırın

4. Uygulamayı çalıştırın:
   - Visual Studio'dan `F5` ile çalıştırabilirsiniz
   - Veya `bin\Debug\NotePad.exe` dosyasını çift tıklayarak çalıştırabilirsiniz

## 📖 Kullanım Kılavuzu

### Yeni Dosya Oluşturma
1. Menü çubuğundan `Dosya` > `Yeni` seçeneğini tıklayın
2. Veya `Ctrl+N` klavye kısayolunu kullanın
3. Kaydedilmemiş değişiklikler varsa uyarı alırsınız

### Dosya Açma
1. Menü çubuğundan `Dosya` > `Aç` seçeneğini tıklayın
2. Veya `Ctrl+O` klavye kısayolunu kullanın
3. Açılan pencereden dosyanızı seçin
4. Dosya UTF-8 encoding ile açılır

### Dosya Kaydetme
1. **Hızlı Kaydet**: `Dosya` > `Kaydet` veya `Ctrl+S`
   - Daha önce kaydedilmiş dosyalar için mevcut konuma kaydeder
   - Yeni dosyalar için "Farklı Kaydet" penceresi açılır

2. **Farklı Kaydet**: `Dosya` > `Farklı Kaydet` veya `Ctrl+Shift+S`
   - Dosyayı farklı bir konuma veya farklı bir isimle kaydetmenizi sağlar

### Metin Düzenleme
- **Kopyala**: Metni seçin ve `Ctrl+C` veya `Düzenle` > `Kopyala`
- **Kes**: Metni seçin ve `Ctrl+X` veya `Düzenle` > `Kes`
- **Yapıştır**: İmleci istediğiniz yere getirin ve `Ctrl+V` veya `Düzenle` > `Yapıştır`
- **Hepsini Seç**: `Ctrl+A` veya `Düzenle` > `Hepsini Seç`

### Yazı Tipi Değiştirme
1. Menü çubuğundan `Görünüm` > `Yazı Tipi` seçeneğini tıklayın
2. Açılan pencereden istediğiniz yazı tipini, boyutunu ve rengini seçin
3. `Tamam` butonuna tıklayın

### Tema Değiştirme
1. Menü çubuğundan `Görünüm` > `Tema` seçeneğini tıklayın
2. `Açık Tema` veya `Koyu Tema` seçeneklerinden birini seçin
3. Tema anında uygulanır

### Kaydedilmemiş Değişiklikler
- Metin alanında herhangi bir değişiklik yaptığınızda, başlık çubuğunda dosya adının başına `*` işareti eklenir
- Form kapanırken veya yeni dosya açılırken kaydedilmemiş değişiklikler için uyarı alırsınız
- Uyarı penceresinde:
  - **Evet**: Değişiklikleri kaydeder ve işleme devam eder
  - **Hayır**: Değişiklikleri kaydetmeden işleme devam eder
  - **İptal**: İşlemi iptal eder

## ⌨️ Klavye Kısayolları

| İşlem | Kısayol |
|-------|---------|
| Yeni Dosya | `Ctrl+N` |
| Dosya Aç | `Ctrl+O` |
| Kaydet | `Ctrl+S` |
| Farklı Kaydet | `Ctrl+Shift+S` |
| Kopyala | `Ctrl+C` |
| Kes | `Ctrl+X` |
| Yapıştır | `Ctrl+V` |
| Hepsini Seç | `Ctrl+A` |

## 🛠️ Teknik Detaylar

- **Platform**: Windows Forms
- **Framework**: .NET Framework 4.8
- **Dil**: C#
- **Encoding**: UTF-8 (BOM olmadan)
- **Minimum .NET Sürümü**: 4.8

## 📝 Notlar

- Tüm dosyalar UTF-8 encoding ile kaydedilir
- Türkçe karakterler tam desteklenir
- Word wrap özelliği varsayılan olarak açıktır
- Tab tuşu ile girintileme yapabilirsiniz
- Uygulama minimum 600x400 piksel boyutunda açılır

## 🐛 Bilinen Sorunlar

Şu anda bilinen bir sorun bulunmamaktadır.

## 📄 Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

## 👨‍💻 Geliştirici

Bu uygulama C# Windows Forms ile geliştirilmiştir.

---

**Not**: Bu uygulama basit bir metin düzenleyicidir. Gelişmiş özellikler için profesyonel metin düzenleyicileri kullanmanız önerilir.

