Ad: Muammer Kablan
Öğrenci Numarası: 2602020014

Oyunun Açıklaması: Doğru topları toplayarak istenilen puana gelip bölümü geçme üzerine kurulu 3D top sürme oyunu.

Kullanılan C# Scriptlerinin Görevi: Oyuna yeni şeyler eklenmeyeceği ve büyütülmeyeceği için tek bir scriptde yazdım o da BallManager. Scriptde hem oyuncunun hareket kabiliyetlerini atıyoruz hem OnTriggerEnter ile toplama ve puan sistemini yapıyoruz hem de Level geçiş sistmini yapıyoruz.

Nesne toplama sistemi, OnTriggerEnter ve CompareTag ile içine girdiğimiz objenin istediğimiz şeye uyup uymamasını kontrol ederek puanı arttırıp azaltmamız üzerine kurulu.

Karşılaşılan Hata: Objelerin içine girsem de ne yazı yazıyordu ne de puanım artıyordu. 1 saat fln uğraştım sonra OnTriggerEnter'ı OriggerEnter olarak yazdığımı fark edip düzeltince her şey düzeldi.
2. ilk level dışı levellerde finishe girince ilk levele atıyordu ama ben aynı levele baştan başlamasını istiyordum. Bunu da puanı kontrol etme sistemini direk LoadLevela taşıyarak çözdüm çünkü ilk halinde fonksiyonlar ayrık olduğundan ilk seviyede olduğunu sanıyordu.

Oyunun nasıl çalıştırılacağı: Oyunu unity 6000.0.25f1(unutmuşum) üzerinden proje olarak kurarak yukarıdan play demek yeterli.

Video Bağlantısı: https://www.youtube.com/watch?v=UBfSdurhovk
