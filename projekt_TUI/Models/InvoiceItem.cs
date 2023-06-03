using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_TUI.Models
{
    public class InvoiceItem
    {
        public string NumerDokumentu { get; set; }
        public string Status { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string Magazyn { get; set; }
        public string Kontrachent { get; set; }
        public string Waluta { get; set; }
        public string NIP { get; set; }
        public string Miasto { get; set; }
        public decimal Netto { get; set; }
        public decimal Brutto { get; set; }
    }
}
