using System;
using System.Windows.Forms;
using NeltharionRPGGame.UI;

namespace NeltharionRPGGame
{
    static class EntryPoint
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashScreen splashScreen = new SplashScreen();
            if (splashScreen.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new GameWindow());
            }
        }
    }
}
