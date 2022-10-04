using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Debt_Book.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Debt_Book.ViewModels
{
    public class DebitDetailsViewModel: BindableBase
    {
        public DebitDetailsViewModel()
        {

        }

        public DebitDetailsViewModel(Debtor debtor)
        {
            CurrentDetailDebtor = debtor;
            ChangesCount = 0;
        }

        #region fileds and properties 

        private Debtor _currentDetailDebtor;
        
        public Debtor CurrentDetailDebtor
        {
            get { return _currentDetailDebtor; }
            set { SetProperty(ref _currentDetailDebtor, value); }
        }


        private double _newValue;
        public double NewValue
        {
            get
            {
                return _newValue;
            }
            set
            {
                SetProperty(ref _newValue, value);
            }
        }

        private ObservableCollection<Transaction> _transactions;

        public ObservableCollection<Transaction> Transactions
        {
            get { return _transactions; }
            set { SetProperty(ref _transactions, value); }
        }

        private int _changesCount;
        public int ChangesCount
        {
            get { return _changesCount; }
            set
            {
                SetProperty(ref _changesCount, value);
            }
        }
        #endregion

        #region Commands

        //add Transaktion skal bruges til at sætte ny value 
        private DelegateCommand _addTrans;
        public DelegateCommand AddNewTrans =>
            _addTrans ?? (_addTrans = new DelegateCommand(ExecuteAddTrans).ObservesProperty(() => NewValue));


        public void ExecuteAddTrans()
        {
            Transaction newTrans = new Transaction(NewValue);
            CurrentDetailDebtor.Transactions.Add(newTrans);
            CurrentDetailDebtor.UpdateBalance();
            ChangesCount++;
        }

        //Skal bruges til at fortryde ændringer 
        DelegateCommand<CancelEventArgs> _cancelCommand;
        public DelegateCommand<CancelEventArgs> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new
                  DelegateCommand<CancelEventArgs>(CancelCommand_Execute));
            }
        }

        private void CancelCommand_Execute(CancelEventArgs arg)
        {
           for (int i = ChangesCount; i >0; i--)
           {
                CurrentDetailDebtor.Transactions.RemoveAt(CurrentDetailDebtor.Transactions.Count - 1);
           }
           CurrentDetailDebtor.UpdateBalance();
        }

        #endregion

    }
}
