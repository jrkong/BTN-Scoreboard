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
            string temp = File.ReadAllText(@"K:\Users\Alex\Desktop\Unity Scoreboard\Nightmares\Test_Data\Score.txt");
            
            InitializeComponent();

            Score_Label.Content = temp;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
