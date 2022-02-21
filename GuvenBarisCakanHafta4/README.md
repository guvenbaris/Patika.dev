Kategori Detayları

● Tüm kategoriler listelenmeli
● Kullanıcı kategori id ile api call yaptiginda kategori altındaki ürünler kategoriye göre
filtrelenmeli, default olarak tüm ürünler çekilmeli.
● Yeni kategori eklenebilmeli veya mevcut olan güncellenebilmeli.

Ürün Detayları

● Teklif Ver apisi üründen gelen data içerisindeki isOfferable alanına göre control edilmeli.
● isOfferable durumunun sağlanmadığı takdirde teklif verilememeli.
● Teklif Ver apisi ile kullanıcı kendisi teklif girebilmeli. Teklif girme alanı number olmalı ve
buraya validasyon eklenmeli
● ayrica Teklif değeri yüzdelik olarak api tarafına yollanabilmeli (offeredPrice), mesela,
100₺ olan ürün için %40 değeri seçilirse, 40₺ teklif yapılabilmeli
● Eğer bir kullanıcı bir ürüne teklif verdiyse, o ürünün icin teklifini geri çekebilmeli. Verdigi
teklif yoksa kullanicilar bilgilendirilmeli.
● Kullanıcı teklif yapmadan bir ürünü direk satın alabilir. Kullanıcı ürünü satın alınca, ilgili
ürün datası içerisindeki isSold alanının değeri güncellenmeli.

Hesabım Detayları

● Kullanıcının yaptığı offer lar listelenmeli.
● Kullanicinin urunleri icin aldigi offer lar listelenmeli.
● Alınan tekliflere Onayla ve Reddet ile cevap verilebilmeli
● Verilen teklif onaylandığında satin alma icin uygun duruma getirilmeli. ● Ürün detay
daki gibi Satın Al tetiklenince statu güncellenmeli. Satın Al'a tetiklenince Teklif
Verdiklerim listesindeki ürünün durumu güncellenmeli

Ürün Ekleme Detayları

● İlgili validasyonlar eklenmeli:
● Ürün Adı alanı maksimum 100 karakter uzunluğunda olmalı ve zorunlu bir alan olmalı
● Açıklama alanı maksimum 500 karakter uzunluğunda olmalı ve zorunlu bir alan olmalı
● Kategori alanı ilgili endpointten çekilen kategorileri listelemeli ve en fazla bir kategori
seçebilmeli. Bu alan zorunlu bir alan olmalı
● Renk alanı ilgili endpointten çekilen renkleri listelemeli ve en fazla bir renk seçebilmeli. Bu
alan zorunlu bir alan olmamalı
● Marka alanı ilgili endpointten çekilen markaları listelemeli ve en fazla bir marka
seçilebilmeli. Bu alan zorunlu bir alan olmamalı
● Kullanım Durumu alanı ilgili endpointten çekilen kullanım durumlarını listelemeli ve en
fazla bir kullanım durumu seçebilmeli. Bu alan zorunlu bir alan olmalı
● Ürün Görseli alanından en fazla bir ürün görseli eklenmeli. Eklenen ürün görseli
istenildiği zaman silinebilmeli. Bu alan zorunlu bir alan olmalı. Sadece png/jpg/jpeg
formatında görseller eklenmeli. Maksimum 400kb değerinde görseller eklenilebilmeli
● Fiyat alanı number olmalı ve zorunlu bir alan olmalı
● Teklif Opsiyonu alanı boolean bir değer olmalı ve default olarak false olmalı
Ek Proje Gereksinimleri:
● Yazılan projenin nasıl ayağa kalktığı ve benzeri detayların paylaşıldığı bir README.md
file'ı projlere eklenmeli
● Clean kod , SOLID prensiplerine uymaya önem gösterilmeli.
● proje kapsamında enaz bir trigger ve stored procedure kullanmalısınız
● Repository , UnitOfWork gibi patternleri kullanarak gelistirme yapiniz.
ÖNEMLİ: Projenin detayları ve tasarımı herhangi bir yerde paylaşılmamalı!
Repositoryler private olmalı!




    public class CreateCategoryQueryResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; } = true;
    }