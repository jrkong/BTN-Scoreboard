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

namespace Scoreboard_Template
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreateUserSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                DataHandler dh = new DataHandler();
                dh.createUser(tbCreateUsername.Text, tbCreatePassword.Password, tbCreateEmail.Text);
                this.Close();
            }
        }

        private bool validate()
        {
            bool valid = false;
            if (tbCreateUsername.Text.Length == 0)
            {
                lblCreateUserErr.Content = "Username is a required field";
                lblCreateUserErr.Visibility = Visibility.Visible;
            }
            else if (tbCreatePassword.Password.Length == 0)
            {
                lblCreateUserErr.Content = "Password is a required field";
                lblCreateUserErr.Visibility = Visibility.Visible;
            }
            else if (tbCreateEmail.Text.Length == 0)
            {
                lblCreateUserErr.Content = "Email is a required field";
                lblCreateUserErr.Visibility = Visibility.Visible;
            }
            else
            {
                valid = true;
            }

            return valid;
        }
    }
}
