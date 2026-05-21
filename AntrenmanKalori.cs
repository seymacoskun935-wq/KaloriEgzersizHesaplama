using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaloriTakip
{
    internal class AntrenmanKalori
    {
        public string Tur { get; set; }
        public string Bolge { get; set; }
        public double DakikaBasiKalori { get; set; }
        



        public AntrenmanKalori (string tur, string bolge, double dakikaBasiKalori)
        {
            Tur = tur;
            Bolge = bolge;
            DakikaBasiKalori = dakikaBasiKalori;
        }
    }
}
