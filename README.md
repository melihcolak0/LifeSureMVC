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
🗂️ Tek Katmanlı Dosya Yapısı - Presentation Layer
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
  <img src="https://github.com/melihcolak0/RapidAPIBooking/blob/842bc5860e9ff2219d18054a3b675a6860098bb8/ss/localhost_7176_Booking_Index.png" alt="image alt">
</div>
