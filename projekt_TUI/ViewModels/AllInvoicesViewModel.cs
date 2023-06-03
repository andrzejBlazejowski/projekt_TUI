using projekt_TUI.Models;
using System;
using System.Collections.ObjectModel;

namespace projekt_TUI.ViewModels
{
    public class AllInvoicesViewModel : WorkspaceViewModel
    {
        public ObservableCollection<InvoiceItem> DocumentItems { get; set; }

        public AllInvoicesViewModel()
            :base()
        {
            DisplayName = "faktury";

            DocumentItems = new ObservableCollection<InvoiceItem>();

            for (int i = 1; i <= 7; i++)
            {
                DocumentItems.Add(new InvoiceItem
                {
                    NumerDokumentu = $"fs{i}/2022",
                    Status = $"Status{i}",
                    DataWystawienia = DateTime.Now.AddDays(-i),
                    Magazyn = $"Magazyn{i}",
                    Kontrachent = $"Kontrachent{i}",
                    Waluta = $"Waluta{i}",
                    NIP = $"2345345345{i}",
                    Miasto = $"Miasto{i}",
                    Netto = i* 1000,
                    Brutto = i* 1200
                });
            }
        }
    }
}
