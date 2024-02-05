using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for Forget_password.xaml
    /// </summary>
    public partial class Forget_password : Page
    {
      public static readonly char c;

        public Forget_password()
        {
            InitializeComponent();
        }
        pharmasyEntities1 db = new pharmasyEntities1();
        private static bool isvalid(string pass)
        {
            return pass.Any(char.IsDigit) && pass.Any(char.IsUpper) && pass.Any(char.IsLower)  && pass.Any(char.IsLetterOrDigit);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (phone_t.Text == "")
            {
                MessageBox.Show("try again in phone");
            }
            else
            {
                if (newpass_t.Text == "")
                {
                    MessageBox.Show("try again in newpassword");

                }
                else
                {
                    if(isvalid(newpass_t.Text))
                    {
                        userer usere=new userer();
                        usere = db.userers.FirstOrDefault(X => X.mobile_number == phone_t.Text);
                        usere.passworde = newpass_t.Text;
                    }
                    if(newpass_t.Text==confpass_t.Text)
                    {
                        db.userers.AddOrUpdate();
                        Sign_In sign_In=new Sign_In();
                        this.NavigationService.Navigate(sign_In);
                        db.SaveChanges();
                        MessageBox.Show("done");
                    }
                    else if(newpass_t.Text!=confpass_t.Text)
                    {
                        MessageBox.Show("new pass not equal confirm");
                    }
                }
               
            }
        
        }
    }
}
