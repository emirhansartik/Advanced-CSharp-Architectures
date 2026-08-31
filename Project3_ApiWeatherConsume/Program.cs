#region Menü_Başlangıcı

Console.WriteLine("Api Consume İşlemine Hoş Geldiniz");
Console.WriteLine();
Console.WriteLine("### Yapmak İstediğiniz İşlemi Seçin ###");
Console.WriteLine();
Console.WriteLine("1-Şehir Listesini  Getirin");
Console.WriteLine("2-Yeni Şehir Ekleme");
Console.WriteLine("3-Şehir Silme İşlemi");
Console.WriteLine("4-Şehir Güncelleme İşlemi");
Console.WriteLine("5-ID'ye Göre Şehir Getirme");
Console.WriteLine();

#endregion

string number;


Console.Write("Tercihiniz: ");
number = Console.ReadLine();
Console.WriteLine();

if (number == "1")
{
    string url = "";
}
if (number == "2")
{
    Console.WriteLine("Yeni Şehir Ekleme Alanı");
}
if (number == "3")
{
    Console.WriteLine("Şehir Silme Alanı");
}



Console.Read();