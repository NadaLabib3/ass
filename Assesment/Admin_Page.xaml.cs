using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for Admin_Page.xaml
    /// </summary>
    public partial class Admin_Page : Page
    {
        public Admin_Page(druga druga)
        {
            InitializeComponent();
            DataContext=druga;
        }

        public Admin_Page()
        {
        }

        pharmasyEntities1 db = new pharmasyEntities1();
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // try
            // {

            // Dategride.ItemsSource=db.drugas.Where(X=> X.namee == name_t.Text).Select(X => new {X.price,X.quantity}).ToList();

            //}


            //catch 
            //{
            //    MessageBox.Show("eroor");
            //}try{
            try 
            {
                  var rect=db.drugas.Where(X=>X.namee==name_t.Text).Select(X => new {X.price,X.quantity});
            }
            catch
            {
                MessageBox.Show("");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                druga druga = new druga();
                var darg = db.drugas.Remove(db.drugas.First(X => X.namee == name_t.Text));
                MessageBox.Show("dletede");
                db.SaveChanges();
            }
            catch
            {

            }
        }
    }
}
