using projekt_TUI.Models;
using System;
using System.Collections.ObjectModel;

namespace projekt_TUI.ViewModels
{
    public class InvoiceViewModel : WorkspaceViewModel
    {
        public ObservableCollection<CommodityModel> Commodities { get; set; }

        public InvoiceViewModel()
            :base()
        {
            DisplayName = "nowa faktura";

            Commodities = new ObservableCollection<CommodityModel>();

            for (int i = 1; i <= 10; i++)
            {
                Commodities.Add(new CommodityModel
                {
                    Kod = $"Kod{i}",
                    Nazwa = $"Nazwa{i}",
                    Ilosc = i,
                    Jm = $"Jm{i}",
                    Rabat = i * 0.1m,
                    Cena = i * 100,
                    Wartosc = i * 1000,
                    Magazyn = $"Magazyn{i}"
                });
            }
        }
    }
}
