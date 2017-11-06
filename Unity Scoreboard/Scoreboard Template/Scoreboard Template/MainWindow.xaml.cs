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
using System.IO;

namespace Scoreboard_Template
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //string temp = File.ReadAllText(@"..\..\..\..\Nightmares\Test_Data\Score.txt"); //Change to correct relative path
            string temp = File.ReadAllText(@"Score.txt"); //Change to correct relative path
            DataHandler dh = new DataHandler();
            if (!dh.verifyDatabase())
            {
                dh.initializeDatabase();
            }

            InitializeComponent();

            Score_Label.Content = temp;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataHandler dh = new DataHandler();
            if (dh.authenticate(tbUsername.Text, tbPassword.Text))
            {
                Leaderboard scores = new Leaderboard(tbUsername.Text, Score_Label.Content.ToString());
                scores.Show();
                this.Close();
            }
        }
    }
}
