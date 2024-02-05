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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assesment
{
    /// <summary>
    /// Interaction logic for User_page.xaml
    /// </summary>
    public partial class User_page : Page
    {
        public User_page()
        {
            InitializeComponent();
        }
        pharmasyEntities1 db = new pharmasyEntities1();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {

                dategride.ItemsSource = db.drugas.Where(X => X.namee == name_t.Text).Select(X => new { X.price, X.quantity }).ToList();
                int totalprise;
                int quntity;
                int price;
               // totalprise = dategride.ItemsSource.
               // totalprise = price * quntity;
            }


            catch
            {
                MessageBox.Show("eroor");
            }
        }
    }
}
