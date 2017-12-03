using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Linker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void app_Startup(object sender, StartupEventArgs e)
        {
            // If no command line arguments were provided, don't process them
            if (e.Args.Length == 0) return;

            string strPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            int intTmp = strPath.IndexOf("Nightmares");
            string strScorePath = strPath.Substring(0, intTmp--);
            //strScorePath = strScorePath + @"Scoreboard Template/Scoreboard Template/bin/Debug/Scoreboard Template.exe";
            strScorePath = @"Scoreboard Template.exe"; //This will assume Linker.exe will be in the same folder as Scoreboard Template.exe, change when necessary

            //Start scoreboard
            var score = Process.Start(strScorePath, e.Args[1]);

            //Wait for it to exit before restarting the game
            score.WaitForExit();

            Application.Current.Shutdown(0);
        }
    }
}
