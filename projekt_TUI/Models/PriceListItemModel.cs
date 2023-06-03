using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_TUI.Models
{
    public class PriceListItemModel
    {
        public string NumerCeny { get; set; }
        public string TypCeny { get; set; }
        public string Akt { get; set; }
        public decimal Marza { get; set; }
        public decimal Zaokr { get; set; }
        public decimal Offset { get; set; }
        public decimal CenaNetto { get; set; }
        public decimal CenaBrutto { get; set; }
        public string Waluta { get; set; }
    }
}
