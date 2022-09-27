using System;
using System.Windows;
using Debt_Book.Model;
using Debt_Book.ViewModels;

namespace Debt_Book.Views
{
    /// <summary>
    /// Interaction logic for AgentView.xaml
    /// </summary>
    public partial class DebitAddView : Window
    {
        public DebitAddView()
        {
            InitializeComponent();

            txtBoxName.Focus();     // Sætter name som default valg
        }

        private void btnClickOK(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as DebitAddViewModel;
            if (vm.IsValid)
                DialogResult = true;
            else
                MessageBox.Show("Enter a valid name and amount", "Invalid data");

            Transaction newTrans = new Transaction(vm.CurrentDebtor.Balance);
            
            vm.CurrentDebtor.Transactions.Add(newTrans);

        }
    }
}
