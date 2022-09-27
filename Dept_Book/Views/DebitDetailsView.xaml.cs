using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Debt_Book.Views
{
    /// <summary>
    /// Interaction logic for DebitDetailsView.xaml
    /// </summary>
    public partial class DebitDetailsView : Window
    {
        public DebitDetailsView()
        {
            InitializeComponent();

            txtBoxValue.Focus();     // Sætter name som default valg
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
