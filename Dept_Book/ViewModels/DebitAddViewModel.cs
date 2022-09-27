using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Debt_Book.Model;
using Debt_Book.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace Debt_Book.ViewModels
{
    public class DebitAddViewModel: BindableBase
    {
        private ObservableCollection<Debtor> listOfDebtors;
        private Debtor _currentDebtor;

        public DebitAddViewModel(string title, Debtor debtor)
        {
            Title = title;
            CurrentDebtor = debtor;
        }

        public DebitAddViewModel()
        {
            listOfDebtors = new ObservableCollection<Debtor>();
            listOfDebtors.Add(new Debtor("Oliver"));
            listOfDebtors.Add(new Debtor("Mathias"));
            listOfDebtors.Add(new Debtor("Andreas"));
        }

        #region Properties
        string title;

        public string Title
        {
            get { return title; }
            set
            {
                SetProperty(ref title, value);
            }
        }

        private double _initialDebt=0;

        public double InitialDebt
        {
            get { return _initialDebt; }
            set { SetProperty(ref _initialDebt, value); }
        }

        public ObservableCollection<Debtor> Debtors
        {
            get
            {
                return listOfDebtors;
            }
        }

        public Debtor CurrentDebtor
        {
            get { return _currentDebtor; }

            set { SetProperty(ref _currentDebtor, value); }
        }

        public bool IsValid
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(CurrentDebtor.Name))
                    isValid = false;
                return isValid;
            }
        }

        #endregion

        #region Methods
        #endregion

        #region Commands


        // *********************** ADD NEW ********************** //

        private DelegateCommand _addNewCommand;
        public DelegateCommand AddNewDebitorCommand =>
            _addNewCommand ?? (_addNewCommand = new DelegateCommand(ExecuteAddNew));
        private void ExecuteAddNew()
        {
            var newDebtor = new Debtor();
           var vm = new DebitAddViewModel("Add new agent", newDebtor);
           var dlg = new DebitAddView()
           {
               DataContext = vm
           };
           if (dlg.ShowDialog() == true)
           {
               Debtors.Add(newDebtor);
               CurrentDebtor = newDebtor; // Or CurrentIndex = Debtors.Count - 1;
           }
        }

         // *********************** CLOSE APP ********************** //

         private DelegateCommand _closeAppCommand;
         public DelegateCommand CloseAppCommand =>
             _closeAppCommand ?? (_closeAppCommand = new DelegateCommand(ExecuteCloseApp));
        
         void ExecuteCloseApp()
         {
             Application.Current.MainWindow.Close();
         }

         bool CanExecuteColorCommand()
         {
             return true;
         }


        #endregion

    }
}
