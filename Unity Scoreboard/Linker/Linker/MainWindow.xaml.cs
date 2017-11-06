using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Linker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string strPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            int intTmp = strPath.IndexOf("Nightmares");
            string strScorePath = strPath.Substring(0, intTmp--);
            strScorePath = strScorePath + @"Scoreboard Template/Scoreboard Template/bin/Debug/Scoreboard Template.exe";
            //Start scoreboard
            var score = Process.Start(strScorePath);

            //Wait for it to exit before restarting the game
            score.WaitForExit();

            Application.Current.Shutdown(0);
        }
    }
}
