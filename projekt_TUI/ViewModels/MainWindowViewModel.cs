using projekt_TUI.Helpers;
using projekt_TUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace projekt_TUI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region commands
        public ICommand NewItemCommand
        {
            get
            {
                return new BaseCommand(() => CreateView(new NewItemViewModel()));
            }
        }
        public ICommand NewContractCommand
        {
            get
            {
                return new BaseCommand(() => CreateView(new ContractViewModel()));
            }
        }
        public ICommand ItemsCommand
        {
            get
            {
                return new BaseCommand(showAllItems);
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            Commands = new(CreateCommands());
            Workspaces = new();
            Workspaces.CollectionChanged += OnWorkspacesChanged;
        }

        #region Butns
        public ReadOnlyCollection<CommandViewModel> Commands { get; set; }

        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel("itemy",new BaseCommand(showAllItems)),
                new CommandViewModel("Item",new BaseCommand(()=>CreateView(new NewItemViewModel()))),
                new CommandViewModel("Kontrakt",new BaseCommand(()=>CreateView(new ContractViewModel()))),
                new CommandViewModel("Pracownik",new BaseCommand(()=>CreateView(new EmployeeViewModel()))),
                new CommandViewModel("Faktury",new BaseCommand(()=>CreateView(new AllInvoicesViewModel()))),
            };
        }

        #endregion

        #region Zakładki
        public ObservableCollection<WorkspaceViewModel> Workspaces { get; set; }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            this.Workspaces.Remove(workspace);
        }
        #endregion

        #region Funkcje pomocnicze
        private void CreateView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
        private void showAllItems()
        {
            AllItemsViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllItemsViewModel) as AllItemsViewModel;
            if (workspace == null)
            {
                workspace = new AllItemsViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        #endregion
    }
}
