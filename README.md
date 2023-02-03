# Vehicle - Renklere göre Araba, Tekne, Otobüsler Crud işlemleri.

#### *Projede kullanılan teknoloji ve kütüphaneler*
- Clean Architecture
- JWT Authentication
- PostgreSql
- HMACSHA512 şifreleme algoritması 
- AutoMapper
- Fluent Validation
- CQRS
- MediatR
- Generic Repository pattern
- UnitOfWork pattern
- XUnit Test

### Postman Api dökümantasyonuna burdan ulaşabilirsiniz. [Tıklayınız](https://documenter.getpostman.com/view/15763755/2s935msQwp) 

### Kullanıcı 
- Kullanıcı ilgili bilgileri doldurup kayıt olabiliyor.
- Kullanıcı Email ve Pasword ile sisteme giriş yapabiliyor.
- Tüm kullanıcıları listelenebilir.

### Renkler
- Bir kullanıcı bir veya birden fazla Renk oluşturabilir.
- Kullanıcı Renk silme ve güncelleme işlemi yapabilir.
- Tüm renkler listeleme ve Id bazlı listeleme yapılabilir.

### Arabalar 
- Bir kullanıcı bir veya birden fazla araba oluşturabilir.
- Kullanıcı Araba silme ve güncelleme işlemi yapabilir.
- Kullanıcı Araba Id'si ile farları açıp kapatabilir.
- Kullanıcı Renk Id'si göre Arabaları listeleyebilir.
- Kullanıcı Tüm Arabaları listeleyebilir.

### Tekneler 
- Bir kullanıcı bir veya birden fazla Tekne oluşturabilir.
- Kullanıcı Tekne silme ve güncelleme işlemi yapabilir.
- Kullanıcı Tekne Id'si ile farları açıp kapatabilir.
- Kullanıcı Renk Id'si göre Tekneleri listeleyebilir.
- Kullanıcı Tüm Tekneleri listeleyebilir.

### Otobüsler 
- Bir kullanıcı bir veya birden fazla Otobüs oluşturabilir.
- Kullanıcı Otobüs silme ve güncelleme işlemi yapabilir.
- Kullanıcı Otobüs Id'si ile farları açıp kapatabilir.
- Kullanıcı Renk Id'si göre Otobüsleri listeleyebilir.
- Kullanıcı Tüm Otobüsleri listeleyebilir.

## Projenin Kurulumu
 - Projeyi aşagıdaki adresden biligisayarınıza klonlayabilirsiniz
 ````
 https://github.com/GuvenBoydak/VehicleTask.git
 ````
- Proje’yi VehicleTask.API appsettings.json  içerisindeki `` "ConnectionStrings": {
    "PostgreSql": "User ID=postgres;Password=1181;Server=localhost;Port=5432;Database=VehicleDb;Integrated Security=true;Pooling=true;"
  }`` baglantı adresini kendi database ayaralarınıza göre değiştirmelisiniz.
 
