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
    /// Interaction logic for Sign_In.xaml
    /// </summary>
    public partial class Sign_In : Page
    {
        public Sign_In()
        {
            InitializeComponent();
        }
        pharmasyEntities1 db =new pharmasyEntities1(); 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            usere usere = new usere();
            if ((bool)radiouser.IsChecked)
            {
                usere.typee = "user";
                var rec = db.userers.FirstOrDefault(X => X.namee == name_t.Text && X.passworde == pass_t.Text);
                if (rec != null)
                {
                    rec.typee = "user";
                    db.SaveChanges();
                     User_page user_Page = new User_page();
                    this.NavigationService.Navigate(user_Page);
                    MessageBox.Show("done");
                }
                else
                {
                    MessageBox.Show("rrorr the user");
                }
            }
            else if((bool)radioadmin.IsChecked)
            {
                usere.typee = "admin";
                var rec = db.userers.FirstOrDefault(X => X.namee == name_t.Text&&X.passworde==pass_t.Text);
                if (rec != null)
                {
                    rec.typee = "Admine";
                    db.SaveChanges();
                    Admin_Page admin_Page=new Admin_Page();
                    this.NavigationService.Navigate(admin_Page);
                    MessageBox.Show("done");
                }
                else
                {
                    MessageBox.Show("rrorr is admin");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Forget_password forget_Password = new Forget_password();
            this.NavigationService.Navigate(forget_Password);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sign_up sign_Up = new sign_up();
            this.NavigationService.Navigate(sign_Up);
        }
    }
}
