using System.Linq;
using System.Windows.Forms;

namespace NeltharionRPGGame.Helper
{
    public abstract class GlobalGameData
    {
        // Weapon Bar Data
        public const int WeaponBoxSizeX = 60;
        public const int WeaponBoxSizeY = 60;
        public const int WeaponBoxesCount = 3;

        // Health Bar Data
        public const int HealthPointsBoxesCount = 3;
        public const int HealthPointsBoxesSizeX = 60;
        public const int HealthPointsBoxesSizeY = 60;

        // Spellcast offset
        public const int OffsetX = 128;
        public const int OffsetY = 90;

        static GlobalGameData()
        {
            Form currentGameWindow = Application.OpenForms.Cast<Form>().FirstOrDefault();
            WindowWidth = currentGameWindow.ClientRectangle.Width;
            WindowHeight = currentGameWindow.ClientRectangle.Height;
        }

        public static int WindowWidth { get; private set; }

        public static int WindowHeight { get; private set; }
    }
}
