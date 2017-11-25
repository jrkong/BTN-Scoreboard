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
using System.Data;

namespace Scoreboard_Template
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        private String u;

        public Leaderboard(String user, String score)
        {
            u = user;
            DataHandler dh = new DataHandler();
            DataSet ds = dh.getScores();
            InitializeComponent();
            dgTopScores.ItemsSource = new DataView(ds.Tables["Scores"]);
        }

        public Leaderboard()
        {
            u = "";
            DataHandler dh = new DataHandler();
            DataSet ds = dh.getScores();
            InitializeComponent();
            btnMyToggle.IsEnabled = false;
            dgTopScores.ItemsSource = new DataView(ds.Tables["Scores"]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMyToggle_Click(object sender, RoutedEventArgs e)
        {
            if (btnMyToggle.Content.ToString() == "My Scores")
            {
                DataHandler dh = new DataHandler();
                DataSet ds = dh.getMyScores(u);
                dgTopScores.ItemsSource = new DataView(ds.Tables["Scores"]);
                (dgTopScores.ItemsSource as DataView).Sort = "score DESC";
                btnMyToggle.Content = "All Scores";
            }
            else
            {
                DataHandler dh = new DataHandler();
                DataSet ds = dh.getScores();
                dgTopScores.ItemsSource = new DataView(ds.Tables["Scores"]);
                btnMyToggle.Content = "My Scores";
            }
        }
    }
}
