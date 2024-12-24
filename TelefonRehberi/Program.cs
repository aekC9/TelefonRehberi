using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                List<Person> phoneBook = new List<Person>();
                phoneBook.Add(new Person { Name = "Ayşe", SurName = "Yılmaz", PhoneNumber = "12345643215" });
                phoneBook.Add(new Person { Name = "Ali", SurName = "Demir", PhoneNumber = "12345643216" });
                phoneBook.Add(new Person { Name = "Mehmet", SurName = "Kaya", PhoneNumber = "12345643217" });
                phoneBook.Add(new Person { Name = "Fatma", SurName = "Arslan", PhoneNumber = "12345643218" });
                phoneBook.Add(new Person { Name = "Bilal", SurName = "Aslan", PhoneNumber = "12345643219" });

                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
                Console.WriteLine("*****************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncellemek");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                Console.WriteLine("*****************************************");
                int secim = int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        Console.Write("İsim: ");
                        string name = Console.ReadLine();
                        Console.Write("Soyisim: ");
                        string surName = Console.ReadLine();
                        Console.Write("Telefon Nuamrası: ");
                        string phoneNumber = Console.ReadLine();
                        phoneBook.Add(new Person { Name = name, SurName = surName, PhoneNumber = phoneNumber });
                        break;
                    case 2:
                        Console.Write("Silmek istediğiniz kişinin adını giriniz: ");
                        string delName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(delName))
                        {
                            Console.WriteLine("Geçersiz giriş! Lütfen bir isim girin.");
                        }
                        else
                        {
                            var personToRemove = phoneBook.FirstOrDefault(p => p.Name.Equals(delName, StringComparison.OrdinalIgnoreCase));
                            if (personToRemove != null)
                            {
                                phoneBook.Remove(personToRemove);
                                Console.WriteLine("Kayıt silindi!");
                            }
                            else
                            {
                                Console.WriteLine("Kişi bulunamadı");
                            }
                        }
                        break;
                    case 3:
                        Console.Write("Güncellemek istediğiniz kişinin adını giriniz: ");
                        string updName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(updName))
                        {
                            Console.WriteLine("Geçersiz giriş! Lütfen bir isim girin.");
                        }
                        else
                        {
                            var personToUpdate = phoneBook.FirstOrDefault(p => p.Name.Equals(updName, StringComparison.OrdinalIgnoreCase));
                            if (personToUpdate != null)
                            {
                                Console.WriteLine("Yeni telefon numarası");
                                string newPhoneNumber = Console.ReadLine();
                                personToUpdate.PhoneNumber = newPhoneNumber;
                                Console.WriteLine("Numara güncellendi");
                            }
                        }
                        break;
                    case 4:
                        var sortedByNames = phoneBook.OrderBy(p => p.Name).ToList();
                        Console.WriteLine("İsimlere göre alfabetik sıralama(A-Z)");
                        foreach (var person in sortedByNames)
                        {
                            Console.WriteLine($"İsim: {person.Name} Soyisim: {person.SurName} Telefon Numarası: {person.PhoneNumber}");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Hangi kategoriye göre arama yapmak istersiniz?(1-İsim,2-Soyisim,3-Telefon Numarası");
                        int searchType = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Arama kriterini giriniz: ");
                        string searchQuery = Console.ReadLine();

                        List<Person> results = new List<Person>();
                        switch (searchType)
                        {
                            case 1:
                                results = phoneBook.Where(p => !string.IsNullOrWhiteSpace(p.Name) && p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
                                break;
                            case 2:
                                results = phoneBook.Where(p => !string.IsNullOrWhiteSpace(p.SurName) && p.SurName.ToLower().Contains(searchQuery.ToLower())).ToList();
                                break;
                            case 3:
                                results = phoneBook.Where(p => !string.IsNullOrWhiteSpace(p.PhoneNumber) && p.PhoneNumber.Contains(searchQuery)).ToList();
                                break;
                        };
                        if (results.Any())
                        {
                            Console.WriteLine("Arama sonuçları:");
                            foreach (var person in results)
                            {
                                Console.WriteLine($"İsim: {person.Name} Soyisim: {person.SurName} Telefon Nuamrası: {person.PhoneNumber}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aradığınız kriterlere uygun bir kayıt bulunamadı");
                        }
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim yaptınız.");
                        break;
                }
            }
        }
    }
}
