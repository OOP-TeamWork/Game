using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using NeltharionRPGGame.Helper;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.UI
{
    public class PaintBrush : IDrawable
    {
        // Weapon Bar Data
        private const int WeaponBoxSizeX = 40;
        private const int WeaponBoxSizeY = 40;
        private const int WeaponBoxesCount = 3;

        // Health Points Bar Data
        private const int HealthPointsBoxesCount = 3;
        private const int HeallthPointsBoxesSizeX = 40;
        private const int HeallthPointsBoxesSizeY = 40;

        private List<PictureBox> pictureBoxes;
        private GameWindow gameWindow;
        private PictureBox[] weaponBoxes;
        private PictureBox[] healthPointsBoxes;

        public List<PictureBox> PictureBoxes { get; private set; }

        public void InitializeField(GameWindow window)
        {
            this.gameWindow = window;
            this.pictureBoxes = new List<PictureBox>();
            this.weaponBoxes = new PictureBox[WeaponBoxesCount];
            this.healthPointsBoxes = new PictureBox[HealthPointsBoxesCount];
            CreateInventoryBar();
            CreateHealthPointsBar();
        }

        public void AddObject(GameObject renderableObject)
        {
            this.CreatePictureBox(renderableObject);
        }

        public void RemoveObject(GameObject renderableObject)
        {
            var picBox = GetPictureBoxByObject(renderableObject);
            this.gameWindow.Controls.Remove(picBox);
            this.pictureBoxes.Remove(picBox);
        }

        public void RedrawObject(GameObject objectToBeRedrawn)
        {
            var newCoordinates = new Point(objectToBeRedrawn.X, objectToBeRedrawn.Y);
            var picBox = GetPictureBoxByObject(objectToBeRedrawn);
            picBox.Location = newCoordinates;
        }

        public void DrawInventoryBar(Weapon[] weapons)
        {
            for (int box = 0; box < WeaponBoxesCount; box++)
            {
                if (weapons[box] != null)
                {
                    this.weaponBoxes[box].Tag = weapons[box];
                    this.weaponBoxes[box].Image = ImageLoader.GetObjectImage(weapons[box].SpriteType);
                }
                else
                {
                    weaponBoxes[box].Tag = null;
                    weaponBoxes[box].Image = ImageLoader.GetObjectImage(SpriteType.DefaultWeapon);
                }
            }
        }

        public void DrawHealthPointsBar(int maxHealthPoints, int healthPoints)
        {
            int firstHearthMaxValue = maxHealthPoints/HealthPointsBoxesCount;
            int secondHearthMaxValue = firstHearthMaxValue * 2;

            if (healthPoints > secondHearthMaxValue)
            {
                this.healthPointsBoxes[0].Image = ImageLoader.GetObjectImage(SpriteType.RedHeart);
                this.healthPointsBoxes[1].Image = ImageLoader.GetObjectImage(SpriteType.RedHeart);
                this.healthPointsBoxes[2].Image = ImageLoader.GetObjectImage(SpriteType.RedHeart);
            }
            else if (healthPoints > firstHearthMaxValue)
            {
                this.healthPointsBoxes[2].Image = ImageLoader.GetObjectImage(SpriteType.BlackHeart);
            }
            else
            {
                this.healthPointsBoxes[1].Image = ImageLoader.GetObjectImage(SpriteType.BlackHeart);
            }
        }

        private PictureBox GetPictureBoxByObject(IRenderable renderableObject)
        {
            return this.pictureBoxes.First(p => p.Tag == renderableObject);
        }

        private void CreateInventoryBar()
        {
            PictureBox weaponBox;

            for (int field = 0; field < WeaponBoxesCount; field++)
            {
                weaponBox = new PictureBox();

                int leftGameFieldOffset = field*WeaponBoxSizeX;
                weaponBox.Size = new Size(WeaponBoxSizeX, WeaponBoxSizeY);
                weaponBox.Location = new Point(leftGameFieldOffset, 0);
                weaponBox.Parent = this.gameWindow;
                this.weaponBoxes[field] = weaponBox;

                this.gameWindow.Controls.Add(weaponBox);
            }
        }

        private void CreateHealthPointsBar()
        {
            PictureBox healthPointsBox;
            int leftGameeFieldOffset = WeaponBoxSizeX * WeaponBoxesCount + 10;

            for (int box = 0; box < HealthPointsBoxesCount; box++)
            {
                int boxXCoordinate = leftGameeFieldOffset + HeallthPointsBoxesSizeX * box;

                healthPointsBox = new PictureBox();
                healthPointsBox.Size = new Size(
                    HeallthPointsBoxesSizeX, HeallthPointsBoxesSizeY);
                healthPointsBox.Location = new Point(boxXCoordinate, 0);
                healthPointsBox.Parent = this.gameWindow;
                healthPointsBoxes[box] = healthPointsBox;

                this.gameWindow.Controls.Add(healthPointsBox);
            }
        }

        private void CreatePictureBox(GameObject renderableObject)
        {
            var spriteImage = ImageLoader.GetObjectImage(renderableObject.SpriteType);
            var picBox = new PictureBox();

            picBox.BackColor = Color.Transparent;
            picBox.Image = spriteImage;
            picBox.Parent = this.gameWindow;
            picBox.Location = new Point(renderableObject.X, renderableObject.Y);
            picBox.Size = new Size(renderableObject.SizeX, renderableObject.SizeY);
            picBox.Tag = renderableObject;

            this.pictureBoxes.Add(picBox);
            this.gameWindow.Controls.Add(picBox);
        } 
    }
}
