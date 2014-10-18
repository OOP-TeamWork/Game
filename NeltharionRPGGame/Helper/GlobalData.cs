using System.Linq;
using System.Windows.Forms;

namespace NeltharionRPGGame.Helper
{
    public abstract class GlobalData
    {
        static GlobalData()
        {
            Form currentGameWindow = Application.OpenForms.Cast<Form>().FirstOrDefault();
            WindowWidth = currentGameWindow.ClientRectangle.Width;
            WindowHeight = currentGameWindow.ClientRectangle.Height;
        }

        public static int WindowWidth { get; private set; }

        public static int WindowHeight { get; private set; }
    }
}
