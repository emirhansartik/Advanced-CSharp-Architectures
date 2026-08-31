#region Menü_Başlangıcı

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Nodes;

// Başlık tasarımı
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("=====================================================");
Console.WriteLine("       🌤️ API CONSUME İŞLEMİNE HOŞ GELDİNİZ 🌤️       ");
Console.WriteLine("=====================================================");
Console.ResetColor();

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("### Yapmak İstediğiniz İşlemi Seçin ###\n");
Console.ResetColor();

Console.WriteLine("[1] Şehir Listesini Getirin");
Console.WriteLine("[2] Şehir ve Hava Durumu Listesini Getirin");
Console.WriteLine("[3] Yeni Şehir Ekleme");
Console.WriteLine("[4] Şehir Silme İşlemi");
Console.WriteLine("[5] Şehir Güncelleme İşlemi");
Console.WriteLine("[6] ID'ye Göre Şehir Getirme");
Console.WriteLine();

#endregion

string number;

Console.ForegroundColor = ConsoleColor.Green;
Console.Write("Tercihiniz: ");
Console.ResetColor();
number = Console.ReadLine();
Console.WriteLine();

// ---------------------------------------------------------
// 1. ŞEHİR LİSTESİ (GET)
// ---------------------------------------------------------
if (number == "1")
{
    string url = "https://localhost:7152/api/Weathers";
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);
        string responseBody = await response.Content.ReadAsStringAsync();
        JArray jArray = JArray.Parse(responseBody);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("--- 🌍 ŞEHİR LİSTESİ ---");
        Console.ResetColor();

        foreach (var item in jArray)
        {
            string cityName = item["cityName"].ToString();
            Console.WriteLine($"📍 Şehir: {cityName}");
        }
    }
}

// ---------------------------------------------------------
// 2. ŞEHİR VE HAVA DURUMU (GET)
// ---------------------------------------------------------
if (number == "2")
{
    string url = "https://localhost:7152/api/Weathers";
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);
        string responseBody = await response.Content.ReadAsStringAsync();
        JArray jArray = JArray.Parse(responseBody);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("--- 🌍 ŞEHİR VE HAVA DURUMU DETAYLARI ---");
        Console.ResetColor();

        foreach (var item in jArray)
        {
            string cityName = item["cityName"].ToString();
            string temp = item["temp"].ToString();
            string country = item["country"].ToString();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"📍 {cityName} - {country}  -->  🌡️ {temp} Derece");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}

// ---------------------------------------------------------
// 3. YENİ ŞEHİR EKLEME (POST)
// ---------------------------------------------------------
if (number == "3")
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("### 📝 YENİ VERİ GİRİŞİ ###\n");
    Console.ResetColor();

    string cityName, country, detail;
    decimal temp;

    Console.Write("Şehir Adı: ");
    cityName = Console.ReadLine();

    Console.Write("Ülke Adı: ");
    country = Console.ReadLine();

    Console.Write("Hava Durumu Detayı: ");
    detail = Console.ReadLine();

    Console.Write("Sıcaklık: ");
    temp = decimal.Parse(Console.ReadLine());

    string url = "https://localhost:7152/api/Weathers";
    var newWeatherCity = new
    {
        cityName = cityName,
        country = country,
        detail = detail,
        temp = temp
    };

    using (HttpClient client = new HttpClient())
    {
        string json = JsonConvert.SerializeObject(newWeatherCity);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        // Kullanıcıya başarılı olduğuna dair görsel bir mesaj
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✅ Şehir başarıyla sisteme eklendi!");
        Console.ResetColor();
    }
}

// ---------------------------------------------------------
// 4. ŞEHİR SİLME (DELETE)
// ---------------------------------------------------------
if (number == "4")
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("### 🗑️ ŞEHİR SİLME İŞLEMİ ###\n");
    Console.ResetColor();

    string url = "https://localhost:7152/api/Weathers?id=";
    Console.Write("Silmek istediğiniz Id Değeri: ");
    int id = int.Parse(Console.ReadLine());

    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.DeleteAsync(url + id);
        response.EnsureSuccessStatusCode();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✅ {id} numaralı şehir başarıyla silindi!");
        Console.ResetColor();
    }
}

// ---------------------------------------------------------
// 5. ŞEHİR GÜNCELLEME (PUT)
// ---------------------------------------------------------
if (number == "5")
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("### 🔄 VERİ GÜNCELLEME İŞLEMİ ###\n");
    Console.ResetColor();

    string url = "https://localhost:7152/api/Weathers";
    string cityName, country, detail;
    decimal temp;
    int cityId;

    Console.Write("Şehir Id: ");
    cityId = int.Parse(Console.ReadLine());

    Console.Write("Yeni Şehir Adı: ");
    cityName = Console.ReadLine();

    Console.Write("Yeni Ülke Adı: ");
    country = Console.ReadLine();

    Console.Write("Yeni Hava Durumu Detayı: ");
    detail = Console.ReadLine();

    Console.Write("Yeni Sıcaklık: ");
    temp = decimal.Parse(Console.ReadLine());

    var updatedWeatherValues = new
    {
        CityId = cityId,
        CityName = cityName,
        Country = country,
        Detail = detail,
        Temp = temp
    };

    using (HttpClient client = new HttpClient())
    {
        string Json = JsonConvert.SerializeObject(updatedWeatherValues);
        StringContent content = new StringContent(Json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PutAsync(url, content);
        response.EnsureSuccessStatusCode();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✅ Şehir bilgileri başarıyla güncellendi!");
        Console.ResetColor();
    }
}

// ---------------------------------------------------------
// 6. ID'YE GÖRE GETİRME (GET)
// ---------------------------------------------------------
if (number == "6")
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("### 🔍 ID'YE GÖRE ŞEHİR GETİRME ###\n");
    Console.ResetColor();

    string url = "https://localhost:7152/api/Weathers/GetByIdWeatherCity?id=";

    Console.Write("Bilgilerini Getirmek İstediğiniz ID Değeri: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine();

    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url + id);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        JObject weatherCityObject = JObject.Parse(responseBody);

        string cityName = weatherCityObject["cityName"].ToString();
        string detail = weatherCityObject["detail"].ToString();
        string country = weatherCityObject["country"].ToString();
        decimal temp = decimal.Parse(weatherCityObject["temp"].ToString());

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("--- 🔍 BULUNAN ŞEHİR BİLGİLERİ ---");
        Console.ResetColor();

        Console.WriteLine($"📍 Şehir: {cityName} | 🌍 Ülke: {country}");
        Console.WriteLine($"☁️  Detay: {detail} | 🌡️ Sıcaklık: {temp} Derece\n");
    }
}

Console.WriteLine("Çıkmak için bir tuşa basın...");
Console.Read();