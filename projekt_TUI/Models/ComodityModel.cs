using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_TUI.Models
{
    public class CommodityModel
    {
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public int Ilosc { get; set; }
        public string Jm { get; set; }
        public decimal Rabat { get; set; }
        public decimal Cena { get; set; }
        public decimal Wartosc { get; set; }
        public string Magazyn { get; set; }
    }
}
