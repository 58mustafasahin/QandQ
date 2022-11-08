# QandQ

Proje https://mustafasahin-qandq.herokuapp.com/index.html sitesinde dockerize edilerek canlıya alınmıştır.

Projede themoviedb.org sitesindeki api'ler kullanılarak in memory veritabanı kullanılarak bazı CRUD operasyonlarını yapabileceğimiz Rest API yazıldı.

Entity Framework Core 6 kütüphanesi ve InMemory veritabanı kullanıldı.

Projedeki servis yapısı için Onion Mimarisi kullanıldı. Ayrıca Generic Repository yapısı oluşturuldu ve Mediatr pattern ile Command(RUD) ve Query(C) işlemleri yapıldı. Mediatr pattern için MediatR ve MediatR.Extensions.Microsoft.DependencyInjection Kütüphaneleri kullanıldı.

Yetkilendirme olarak JWT altyapısı kurularak kullanıcı kayıt olma ve giriş yapma işlemleri eklendi. Kullanıcı sağ üst köşede olan Authorize kısmına aldığı token ile apilere erişim sağlayabilir.

RateAndNote ekleme işlemi için validasyon sınıfı eklendi. Note için 2-200 karakter aralığı belirlenirken, Rate için 1-10 sayı sınıflandırması yapıldı. Validasyon için FluentValidationAspNetCore kütüphanesi kullanıldı. Validasyon işlemi için IAsyncActionFilter ile otomatik validasyon sağlandı.

Data mapping işlemi için Mapster kütüphanesi kullanıldı. Kütüphane Application katmanında Mediatr pattern içerisinde Handler'larda kullanıldı.

Kullanıcıya film tavsiyesi için mail servisi yazıldı, fakat gmail artık güvenliksiz uygulamalara mail gönderimine izin vermiyor. Mail servisi için MailKit kütüphanesi kullanıldı. 

Listeleme ve Filtreleme servislerine sayfalama(pagination) işlemi ile varsayılan(default) olarak 1.sayfa ve 10 veri getirecek şekilde ayarlandı. Talep edilen sayfa ve veri sayısı girilerek istenilen bilgiler elde edilmektedir.

Film listesi periyodik olarak hangfire kütüphanesi kullanılarak her dakikada bir kez istek atarak memory veritabanını yeniliyor.
