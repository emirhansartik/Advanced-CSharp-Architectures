# Advanced C# Architectures

A comprehensive collection of 8 real-world C# backend projects focusing on Dapper, Web API, JWT authentication, SQL Triggers, and real-time data integrations.

## 🚀 Teknolojiler

* **Programlama Dili:** C#
* **Framework:** .NET 
* **Veritabanı:** MS SQL Server
* **ORM:** Dapper, Entity Framework Core
* **Güvenlik:** JWT (Json Web Token)
* **Mimari:** Katmanlı Mimari, DTO (Data Transfer Object) ve Repository Pattern

---

## 📁 Proje Yol Haritası

| # | Proje Modülü | Açıklama | Durum |
| :--- | :--- | :--- | :--- |
| **1** | **Project1_DapperNorthwind** | Dapper Micro-ORM ile CRUD operasyonları ve saf SQL kullanımı. | ✅ Tamamlandı |
| **2** | **Web API Hava Durumu** | .NET Web API altyapısının kurulması, Entity Framework ve endpoint tasarımı. | 🟢 Aktif |
| **3** | **API Consume** | Geliştirilen API mimarisinin dış bir istemci tarafından tüketilmesi. | ⏳ Beklemede |
| **4** | **Rapid API Döviz Kurları** | Dış servis entegrasyonları ve canlı veri çekimi. | ⏳ Beklemede |
| **5** | **SQL Trigger Projesi** | Veritabanı seviyesinde tetikleyici (Trigger) kuralları ve otomasyon. | ⏳ Beklemede |
| **6** | **JWT Authentication** | Token bazlı şifreleme ve gelişmiş rol/yetki yönetimi. | ⏳ Beklemede |
| **7** | **Mail & Aktivasyon** | Kullanıcı işlemleri için SMTP ile e-posta onay süreçleri. | ⏳ Beklemede |
| **8** | **Real-Time Masa Durumu** | Dinamik ve anlık veri akışı (Real-time) sağlayan restoran modülü. | ⏳ Beklemede |

---

## ⚙️ Kurulum ve Kullanım

1. Projeyi bilgisayarınıza klonlayın:
   `git clone https://github.com/emirhansartik/Advanced-CSharp-Architectures.git`
2. Ana dizindeki `My8Projects.sln` dosyasını Visual Studio ile açın.
3. İncelemek istediğiniz projenin klasöründeki SQL scriptlerini (`NorthwindScriptsFolder` vb.) SQL Server üzerinde çalıştırarak veritabanını oluşturun.
4. `App.config` veya `appsettings.json` içerisindeki `ConnectionString` (Bağlantı Dizesi) alanını kendi SQL Server bilginize göre güncelleyerek veritabanı bağlantılarını tamamlayın.
5. İlgili projeyi Visual Studio üzerinden "Set as Startup Project" olarak işaretleyip çalıştırın.
