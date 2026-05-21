using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaloriTakip
{
    internal class Bilgiler
    {
     
        
          public int Boy { get; set; }
           public  int Kilo { get; set; }
          public   int Yas { get; set; }
        public int Cinsiyet { get; set; }
        public int Bmr { get; set; }
        public double  Total { get; set; }
        public double KalanHedef { get; set; }
        public double ToplamYakilan { get; set; }
        public double HedefKalori { get; set; }
       

        public Bilgiler( int boy, int kilo, int yas, int cinsiyet )
        {
            Boy = boy;
            Kilo = kilo;
            Yas = yas;
            Cinsiyet = cinsiyet;
          
            
        }
        
            


    }
}
