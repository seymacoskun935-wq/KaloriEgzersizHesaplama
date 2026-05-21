using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KaloriTakip
{
  
    internal class Program
    {
        static  List<Bilgiler> bilgiler = new List<Bilgiler>();
        static List<AntrenmanKalori> veri = new List<AntrenmanKalori>()
        {
            new AntrenmanKalori  ( "Ağırlık",  "Sırt", 7),
              new AntrenmanKalori  ( "Ağırlık",  "Omuz", 6),
                new AntrenmanKalori  ( "Ağırlık",  "Triceps", 5),
                  new AntrenmanKalori  ( "Ağırlık",  "Biceps", 5),
                    new AntrenmanKalori  ( "Ağırlık",  "Bacak", 9),
                      new AntrenmanKalori  ( "Ağırlık",  "Kalça", 8),
                        new AntrenmanKalori  ( "Ağırlık",  "Göğüs", 7),
                          new AntrenmanKalori  ( "Ağırlık",  "Karın", 6),
                            new AntrenmanKalori  ( "Kardiyo",  "Yürüyüş", 4),
                              new AntrenmanKalori  ( "Kardiyo",  "Koşu", 11),
                                new AntrenmanKalori  ( "Kardiyo",  "Bisiklet", 8),
                                  new AntrenmanKalori  ( "Kardiyo",  "Eliptik", 9),
                                    new AntrenmanKalori  ( "Kardiyo",  "İp Atlama", 13),
                                      new AntrenmanKalori  ( "Kardiyo",  "Yüzme", 10)
         
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Kalori takip uygulamama hoşgeldinnnnn");
            Console.WriteLine("Daha kapsamlı hesaplama için lütfen bilgilerinizi girin");
            KullaniciBilgileri();
        }
        
        public static void KullaniciBilgileri()
        {

            int boy = Kontrol("Boy: ", 250, 100);
         
            int kilo = Kontrol("Kilo: ", 150, 30);
            int yas = Kontrol("Yaş: ", 100, 15);
            
            Console.WriteLine("Cinsiyet: (1 = Kadın, 2 = Erkek)");
            int cinsiyet =Convert.ToInt32 ( Console.ReadLine());
          
            
                if (cinsiyet < 1 || cinsiyet > 2)
                {

                    Console.WriteLine("Lütfen 1 veya 2 girin");
                return;
                }
            
            


            Bilgiler kullanici = new Bilgiler(boy, kilo, yas, cinsiyet );

            bilgiler.Add(kullanici);

            KaloriHesapla(kullanici);


        }
        public static int Kontrol(string mesaj, int max, int min)
        {
            int deger;
            while (true)
            {
                Console.Write(mesaj);
                if (!int.TryParse(Console.ReadLine(), out deger))
                {
                    Console.WriteLine("Lütfen sayı girin!");
                }
                else if (deger > max || deger < min)
                {
                    Console.WriteLine("geçersiz değer aralığı");
                }
                else
                {
                    return deger;
                }

                
            }
        }
        public static void KaloriHesapla(Bilgiler kisi)
        {                                
            Console.WriteLine("Günlük bazal metabolizma hızınız: ");
            if (kisi.Cinsiyet == 1)
            {
                kisi.Bmr = Convert.ToInt32(10 * kisi.Kilo + 6.25 * kisi.Boy - 5 * kisi.Yas - 161); //kadın
                Console.WriteLine( kisi.Bmr);
            }
            if (kisi.Cinsiyet == 2)
            {
              kisi.Bmr=  Convert.ToInt32(10 * kisi.Kilo + 6.25 * kisi.Boy - 5 * kisi.Yas + 5); // erkek
                Console.WriteLine( kisi.Bmr);
            }

            HareketDurumu(kisi);
        }
        public static void HareketDurumu( Bilgiler kisi)
        {
            Console.WriteLine(" Günlük hareket durumunuz nedir? ");
            Console.WriteLine("1= Sedanter: Masa başı iş, hiç spor veya egzersiz yapmama durumu. ");
            Console.WriteLine("2= Az aktif: Haftada 1-3 gün hafif tempolu egzersiz veya yürüyüş yapma.");
            Console.WriteLine("3= Orta derece aktif: Haftada 3-5 gün orta tempoda spor yapma. " );
            Console.WriteLine("4= Çok aktif: Haftada 6-7 gün ağır veya tempolu antrenman yapma." );

            int hareket; 
            if (!int.TryParse(Console.ReadLine() , out hareket))
            {
                Console.WriteLine("Lütfen sayı girin");
                return;
            }
            switch (hareket)
            {
                case 1:
                  
                       kisi.Total =  kisi.Bmr * 1.2;
                    Console.WriteLine("Günlük yakılan kaloriniz: "+ kisi.Total );
                    break;
                case 2:
                    kisi.Total = kisi.Bmr * 1.375;
                    Console.WriteLine("Günlük yakılan kaloriniz: "+ kisi.Total );
                    break;
                case 3:
                    kisi.Total = kisi.Bmr * 1.55;
                    Console.WriteLine("Günlük yakılan kaloriniz: "+ kisi.Total);
                    break;
                case 4:
                    kisi.Total = kisi.Bmr * 1.725;
                    Console.WriteLine("Günlük yakılan kaloriniz: "+ kisi.Total);
                    break;
                default:
                    Console.WriteLine("Geçersiz değer");
                    break;
            }
            Console.WriteLine(" Bugünkü hedefiniz kaç kalori yakmak");
            kisi.HedefKalori = Convert.ToInt32(Console.ReadLine());

            EgzersizListesi(kisi );
        }
      

      public static void EgzersizListesi( Bilgiler kisi)
        {
           
            Console.WriteLine(" Egzersiz türü seçin: ");
            Console.WriteLine(" 1= Ağırlık ");
            Console.WriteLine(" 2= Kardiyo ");
          
            int secim;
            if (!int.TryParse(Console.ReadLine(), out secim))
            {
                Console.WriteLine("Lütfen sayı girin");
                return;
            }
            switch (secim)
            {
                case 1:
                    AgirlikListesi( kisi);
                    break;
                case 2:
                    KardiyoListesi( kisi );
                    break;
            }

           
            int tekrar;
 
            Console.WriteLine(" Başka egzersiz yapmak ister misiniz? ");
            Console.WriteLine(" 1-Evet");
            Console.WriteLine(" 2-Hayır");

            if (!int.TryParse(Console.ReadLine(), out tekrar ))
            {
                Console.WriteLine("Lütfen sayı girin");
                return;
            }
            if (tekrar != 1 && tekrar != 2)
            {
                Console.WriteLine("Geçersiz değer!");
            }

            if (tekrar == 1)
            {
                EgzersizListesi(kisi);           
            }
            else
            {
                return;
            }
           
        
      }
        public static void AgirlikListesi( Bilgiler kisi)
        {
            Console.WriteLine(" Kas grubu seçin: ");
            Console.WriteLine(" 1- Sırt");
            Console.WriteLine(" 2- Omuz");
            Console.WriteLine(" 3- Triceps");
            Console.WriteLine(" 4- Biceps");
            Console.WriteLine(" 5- Bacak");
            Console.WriteLine(" 6- Kalça");
            Console.WriteLine(" 7- Göğüs");
            Console.WriteLine(" 8- Karın");

            int bolge;
            if (!int.TryParse(Console.ReadLine(), out bolge))
            {
                Console.WriteLine("Lütfen sayı girin");
                return;
            }
            string secilenBolge = "";

            switch (bolge)
            {
                case 1:
                    secilenBolge = "Sırt";
                    break;
                case 2:
                    secilenBolge = "Omuz";
                    break;
                case 3:
                    secilenBolge = "Triceps";
                    break;
                case 4:
                    secilenBolge = "Biceps";
                    break;
                case 5 :
                    secilenBolge = "Bacak";
                    break;
                case 6:
                    secilenBolge = "Kalça";
                    break;
                case 7:
                    secilenBolge = "Göğüs";
                    break;
                case 8:
                    secilenBolge = "Karın";
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem");
                    return;     
            }


            var secilen = veri.FirstOrDefault(x => x.Bolge == secilenBolge);
            if (secilen == null)
            {
                Console.WriteLine("Egzersiz bulunamadı");
            }

            Console.WriteLine("Kaç dakika çalıştın? ");
            int dakika;

            if (!int.TryParse(Console.ReadLine(), out dakika ))
            {
                Console.WriteLine("Lütfen sayı girin");
                return;
            }

            double yakilan = secilen.DakikaBasiKalori * dakika * (kisi.Kilo / 70.0);
            kisi.ToplamYakilan += yakilan;


            Console.WriteLine("Yakılan kalori: " + yakilan );
            Console.WriteLine("Toplam yakılan kalori: " + kisi.ToplamYakilan );

            HedefKontrol(kisi, yakilan);


        }
        public static void KardiyoListesi(Bilgiler kisi)
        {
            Console.WriteLine(" Kardiyo dalı seçin: ");
            Console.WriteLine(" 1- Yürüyüş");
            Console.WriteLine(" 2- Koşu");
            Console.WriteLine(" 3- Bisiklet");
            Console.WriteLine(" 4- Eliptik");
            Console.WriteLine(" 5- İp atlama");
            Console.WriteLine(" 6- Yüzme");

            int krdy;
            if (!int.TryParse(Console.ReadLine(), out krdy))
            {
                Console.WriteLine("Lütfen sayı girin");
                return;
            }

            string secilenKardiyo = "";

            switch (krdy)
            {
                case 1:
                    secilenKardiyo = "Yürüyüş";
                    break;
                case 2:
                    secilenKardiyo = "Koşu";
                    break;
                case 3:
                    secilenKardiyo = "Bisiklet";
                    break;
                case 4:
                    secilenKardiyo = "Eliptik";
                    break;
                case 5:
                    secilenKardiyo = "İp atlama";
                    break;
                case 6:
                    secilenKardiyo = "Yüzme";
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem");
                    return;
            }
            var secilen = veri.FirstOrDefault(x => x.Bolge == secilenKardiyo);
            if (secilen == null)
            {
                Console.WriteLine("Egzersiz bulunamadı");
            }

            Console.WriteLine("Kaç dakika yaptın? ");
            int dakika;

            if (!int.TryParse(Console.ReadLine(), out dakika ))
            {
                Console.WriteLine("Lütfen sayı girin");
                return;
            }

            double yakilan = secilen.DakikaBasiKalori * dakika * (kisi.Kilo / 70.0);

            kisi.ToplamYakilan += yakilan;

            Console.WriteLine("Yakılan kalori: " + (int)yakilan );
            Console.WriteLine("Toplam yakılan kalori: " + (int)kisi.ToplamYakilan);

            HedefKontrol(kisi, yakilan);
           
        }


        public  static void HedefKontrol(Bilgiler kisi, double yakilan) 
        {
            kisi.KalanHedef = kisi.HedefKalori - kisi.ToplamYakilan;
            Console.WriteLine("Bugünkü hedefi tamamlamaya kalan kalori: " + (int)kisi.KalanHedef);

            if (kisi.KalanHedef <= 0)
            {
                Console.WriteLine("Tebrikler günlük hedefi tamamladınnn");
            }
        }               
    }
}
