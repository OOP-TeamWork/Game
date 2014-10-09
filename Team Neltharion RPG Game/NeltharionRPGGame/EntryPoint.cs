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
            Application.Run(new GameWindow());
        }
    }
}
