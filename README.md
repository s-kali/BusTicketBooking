# BusTicketBooking
Booking app with Windows Form and MSSQL
Uygulamanın amacı kişilerin kendi kullanıcı adı ve şifreleriyle oluşturduğu kullanıcı kimlikleriyle
otobüs bileti satın alabileceği bir veritabanı ve arayüze sahip olan sistem oluşturmaktır.

Veritabanı Şeması:

![Database Diagram](https://user-images.githubusercontent.com/79456608/108720999-8e3b5600-7532-11eb-9000-aa5be74f91e8.png)

Giriş Ekranı:
Kullanıcı eğer kayıtlıysa giriş yapabilir ve giriş bilgisine göre farklı arayüzlere yönlendirilir.
Kayıtlı değilse sign up now seçeneğine tıklayarak ile kayıt arayüzüne yönlendirilebilir.
![resim](https://user-images.githubusercontent.com/79456608/108721111-ae6b1500-7532-11eb-97a8-5b1a252da3de.png)

Kayıt Ekranı:
Kayıt olmamış kullanıcıların AUTH_type olarak user atanıp kayıt olabileceği kısım. 
![resim](https://user-images.githubusercontent.com/79456608/108721140-b9be4080-7532-11eb-94fb-560ba4b358a5.png)

Admin Ekranı:
Admin bilgileriyle giriş yapıldıktan sonra bilet yönetimi ve yolcu yönetimi olmak üzere 2 farklı arayüze yönlendirilebilir
veya back seçeneği ile login arayüzüne dönebilirsiniz.
![resim](https://user-images.githubusercontent.com/79456608/108721171-c3e03f00-7532-11eb-9bf4-b79b6c7cda5c.png)

Bilet Yönetim Arayüzü:
Bilet ekleme veya TicketID üzerinden güncelleme/silme işleminin yapılabileceği bölümdür.
![resim](https://user-images.githubusercontent.com/79456608/108721204-cc387a00-7532-11eb-8f73-d353cc5b38d8.png)

Yolcu Yönetim Arayüzü:
Passenger_id üzerinden güncelleme/silme işleminin yapılabileceği bölümdür.
![resim](https://user-images.githubusercontent.com/79456608/108721454-115cac00-7533-11eb-8407-fec60652f661.png)

Kullanıcı Arayüzü:
Kullanıcının yolcu bilgilerini girip, tarih ve yolculuk bilgileri üzerinden bilet koşullarını görüntüleyip
alabildiği arayüzdür.

![resim](https://user-images.githubusercontent.com/79456608/108721509-1f123180-7533-11eb-9145-ece1b96da6ce.png)
