using projekt_TUI.Models;
using System;
using System.Collections.ObjectModel;

namespace projekt_TUI.ViewModels
{
    public class PriceListItemViewModel : WorkspaceViewModel
    {
        public ObservableCollection<PriceListItemModel> Prices { get; set; }

        public PriceListItemViewModel()
            :base()
        {
            DisplayName = "nowa faktura";

            Prices = new ObservableCollection<PriceListItemModel>();

            for (int i = 1; i <= 9; i++)
            {
                Prices.Add(new PriceListItemModel
                {
                    NumerCeny = $"Cena{i}",
                    TypCeny = $"Typ{i}",
                    Akt = "Tak",
                    Marza = i * 0.1m,
                    Zaokr = i * 0.2m,
                    Offset = i * 0.3m,
                    CenaNetto = i * 1000,
                    CenaBrutto = i * 1200,
                    Waluta = i % 2 == 0 ? "PLN" : "EUR"
                });
            }
        }
    }
}
