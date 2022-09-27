using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Debt_Book.Model
{
    public class Debtor: BindableBase
    {
        string _name;
        private ObservableCollection<Transaction> _transactions;
        private double _balance;
        public double Balance
        {
            get
            {
                return _balance;
            }
            set { SetProperty(ref _balance, value); }
        }


        public Debtor()
        {
            _transactions = new ObservableCollection<Transaction>();
        }

        public Debtor(string name)
        {
            _name= name;
            _transactions = new ObservableCollection<Transaction>();
        }


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        public ObservableCollection<Transaction> Transactions
        {
            get 
            { 
                return _transactions; 
            }
            set
            {
                SetProperty(ref _transactions, value);
            }
        }
        public Debtor Clone()
        {
            return this.MemberwiseClone() as Debtor;
        }

        public void UpdateBalance()
        {
            double sum = 0;
            foreach (var transaction in _transactions)
            {
                sum += transaction.Value;
            }

            Balance = sum;
        }
    }

}
