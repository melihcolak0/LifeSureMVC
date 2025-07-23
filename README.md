# 🚀 LifeSure AI Destekli Sigorta Sitesi
Bu repository, M&Y Yazılım Akademi bünyesinde yaptığım yedinci proje olan LifeSure Sigorata Sitesi projesini içermektedir. Bu eğitimde bana yol gösteren Murat Yücedağ'a çok teşekkür ederim.

Bu projede, LifeSure adlı bir sigorta firmasına ait çok dilli (Türkçe ve İngilizce) kullanıcı dostu bir web sitesi ve bu siteye entegre çalışan kapsamlı ve yapay zeka destekli bir yönetim paneli (admin panel) geliştirdim. ASP.NET Web Application (NET Framework(4.7.2)) teknolojisiyle geliştirilen bu projede, kullanıcıların farklı sigorta türlerini (Hayat, Sağlık, Araç, Konut, Evcil Hayvan vb.) görüntüleyebileceği, hizmet detaylarını inceleyebileceği, modern tasarımlı, responsive bir kullanıcı arayüzü sunulmaktadır. Yapay Zeka tarafında RapidAPI ve Huggincg Face üzerinden sağlanan API'ler ile entegre çalışan bir sistem kurdum. Bu sisteme çekilen verileri de LifeSure sigoratcılık temasında anlamlı bir şekilde kullandım.

Admin panel üzerinden Hakkında, Özellikler, Ekip Üyeleri, SSS, Slider, Hizmetler, Referanslar ve İletişim bölümleri ile ilgili ekleme, güncelleme ve silme işlemlerini kolaylıkla yönetilebilirsiniz. Panelde, veri tabanı tabloları dinamik olarak yönetilmektedir. Çoklu dil desteği için resource dosyaları ve manuel dil değiştirme mekanizması uygulanmıştır. MSSQL Server ile veritabanı işlemleri gerçekleştirilmiştir.

### Kullandığım Endpoitler;<br>
🔗 RapidAPI – LinkedIn Data Scraper API<br>
(👤 LinkedIn Kullanıcı Verisi Çekme)<br>
➤ linkedin-data-scraper-api1.p.rapidapi.com/<br>
<br>
🐦 RapidAPI – Twitter241 API<br>
(🧾 Twitter Kullanıcı Verisi Çekme)<br>
➤ twitter241.p.rapidapi.com/<br>
<br>
💬 RapidAPI – ChatGPT-42 API<br>
(❓ Sıkça Sorulan Sorular Oluşturma)<br>
➤ chatgpt-42.p.rapidapi.com/<br>
<br>
🎨 Hugging Face – Black Forest Labs / FLUX.1-dev<br>
(🖼️ Hizmetler için Yapay Zeka ile Görsel Oluşturma)<br>
➤ api-inference.huggingface.co/models/black-forest-labs/FLUX.1-dev<br><br>

Bu projeyle amacım, bir sigorta firmasının kurumsal web sitesi ihtiyaçlarını karşılayan, kullanıcı dostu ve yönetilebilir bir sistem tasarlamak oldu. Kodlama standartlarına dikkat edilerek geliştirilen bu proje, portföyümde web teknolojilerine olan hakimiyetimi göstermek amacıyla yer almaktadır. Proje üzerinde gelişitirilebilir bir çok yer bulunabilir. Amacım kendimi geliştirmek ve deneyim kazanmaktır.<br>

###  Kullandığım Teknolojiler:<br>
🧠 ASP.NET Web App (.NET Framework 4.7.2 (MVC Mimarisi))<br>
🗂️ Tek Katmanlı Dosya Yapısı - Presentation Layer<br>
🛢️ Entity Framework<br>
🗄️ MS SQL Server<br>
💾 JSON Parsing (Newtonsoft.Json)<br>
🔗 RapidAPI (Farklı veri kaynaklarına API entegrasyonu)<br>
🤖 Hugging Face API (Yapay zeka modelleriyle resim oluşturma)<br>
🌍 Localization (EN-TR TR-EN) – Dil Desteği<br>
🧩 jQuery, AJAX, JSON<br>
🎨 Bootstrap, HTML5, CSS3<br><br>

Projede genel anlamda 2 bölüm bulunmaktadır.<br>
Ana Sayfa: Burada kullanıcı Ana Sayfa, Oteller ve Otel Detayı sayfalarını görüntüleyebilir ve bu şekilde kendi uygun zamanına göre uygun otelleri bulabilir.<br>
Admin Paneli: Burada Admin, Hakkında, Özellikler, Ekip Üyeleri gibi bölümler ile ilgili CRUD işlemlerini yapar. Hizmetler ve SSS bölümleri için de yapay zeka destekli bir sistem ile Hizmet resmi oluşturma ve Sıkça Sorulan Soru ve Cevap üertimi yapılabilir.

## :arrow_forward: Projeden Ekran Görüntüleri

### :triangular_flag_on_post: Ana Sayfa
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Default_Index%20(1).png" alt="image alt">
</div>

### :triangular_flag_on_post: Dil Desteği, Twitter ve Linkedin API
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Default_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Default_Index%20(2).png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-22%20163532.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-22%20163930.png" alt="image alt">
</div>

### :triangular_flag_on_post: Admin Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_About_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Feature_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Feature_CreateFeature.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Feature_UpdateFeature_1.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Member_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Slider_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Testimonial_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Contact_Index.png" alt="image alt">
</div>

### :triangular_flag_on_post: AI Destekli Admin Paneli Bölümleri
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Faq_Index%20(1).png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Faq_CreateFaq%20(13).png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Faq_CreateFaq%20(24).png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Faq_CreateFaq%20(26).png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Faq_CreateFaq%20(28).png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Service_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Service_CreateService%20(2).png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Service_CreateService%20(9).png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Service_CreateService%20(11).png" alt="image alt">
</div>
