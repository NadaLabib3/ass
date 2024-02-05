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
    /// Interaction logic for sign_up.xaml
    /// </summary>
    public partial class sign_up : Page
    {
        public sign_up()
        {
            InitializeComponent();
        }
        private static bool isvlaid(string pass)
        {
            return pass.Any(char.IsDigit) && pass.Any(char.IsUpper) && pass.Any(char.IsLower) && pass.Any(char.IsLetterOrDigit);
        }
        pharmasyEntities1 db = new pharmasyEntities1();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isvlaid(pass_t.Text))
            {
                int a = int.Parse(age_t.Text);
                if (a >= 18 && a <= 60)
                {
                    if (phone_t.Text.Length == 11)
                    {
                        if (pass_t.Text == conf_t.Text)
                        {
                          
                            Sign_In sign_In = new Sign_In();
                            this.NavigationService.Navigate(sign_In);
                            db.SaveChanges();
                            MessageBox.Show("done");
                        }
                        else if (pass_t.Text != conf_t.Text)
                        {
                            MessageBox.Show("new pass not equal confirm");
                        }
                        if (combo_t.SelectedIndex!=0)
                        {
                            userer user = new userer();
                            user.namee = name_t.Text;
                            user.email = email_t.Text;
                            user.city = combo_t.Text;
                            if (Radiouser.IsChecked == true)
                            {
                                _ = user.gender == "user";

                            }
                            else if (Radioadmin.IsChecked == true)
                            {
                                _ = user.gender == "admine";

                            }
                           if (Radiomale.IsChecked == true)
                            {
                                if (Radioadmin.IsChecked==true)
                                {
                                    user.typee = "admine";
                                    User_page user_Page = new User_page();
                                    this.NavigationService.Navigate(user_Page);
                                    MessageBox.Show("done");
                                }

                            }
                         
                            else if (Radiofemale.IsChecked == true)
                            {
                                _ = user.gender == "female";
                                if (Radiouser.IsChecked == true)
                                {
                                    user.typee = "user";
                                    User_page user_Page = new User_page();
                                    this.NavigationService.Navigate(user_Page);
                                    MessageBox.Show("done");
                                }
                            }
                            db.userers.Add(user);
                            db.SaveChanges();
                            MessageBox.Show("done");
                        }
                    }
                    else
                    {
                        MessageBox.Show("try again is  phoneNumber");
                    }
                        
                }
           
                else
                {
                    MessageBox.Show("try again is Age");
                }
            }
            else
            {
                MessageBox.Show("not is valid");
            }


        }
    }
}
