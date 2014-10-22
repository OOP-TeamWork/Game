using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using NeltharionRPGGame.Data;
using NeltharionRPGGame.Helper;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.UI
{
    public class PaintBrush : IDrawable
    {
        private Dictionary<GameObject, PictureBox> pictureBoxes;
        private GameWindow gameWindow;
        private PictureBox[] weaponBoxes;
        private PictureBox[] healthPointsBoxes;

        public void InitializeField(GameWindow window)
        {
            this.gameWindow = window;
            this.pictureBoxes = new Dictionary<GameObject, PictureBox>();
            this.weaponBoxes = new PictureBox[GlobalGameData.WeaponBoxesCount];
            this.healthPointsBoxes = new PictureBox[GlobalGameData.HealthPointsBoxesCount];

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
            this.pictureBoxes.Remove(renderableObject);
        }

        public void RedrawObject(GameObject objectToBeRedrawn)
        {
            var newCoordinates = new Point(objectToBeRedrawn.X, objectToBeRedrawn.Y);
            var picBox = GetPictureBoxByObject(objectToBeRedrawn);

            picBox.Location = newCoordinates;             
        }

        public void DrawInventoryBar(Item[] weapons)
        {
            for (int box = 0; box < GlobalGameData.WeaponBoxesCount; box++)
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
            int firstHearthMaxValue = maxHealthPoints / GlobalGameData.HealthPointsBoxesCount;
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
            PictureBox objPicBox = null;

            foreach (KeyValuePair<GameObject, PictureBox> pictureBox in pictureBoxes)
            {
                if (pictureBox.Key == renderableObject)
                {      
                    objPicBox = pictureBox.Value;
                    break;
                }
            }
            
            if (objPicBox != null)
            {
                objPicBox.Image = ImageLoader.GetObjectImage(renderableObject.SpriteType);  
            }

            return objPicBox;
        }

        private void CreateInventoryBar()
        {
            PictureBox weaponBox;

            for (int field = 0; field < GlobalGameData.WeaponBoxesCount; field++)
            {
                weaponBox = new PictureBox();

                int leftGameFieldOffset = field * GlobalGameData.WeaponBoxSizeX;
                weaponBox.Size = new Size(GlobalGameData.WeaponBoxSizeX, GlobalGameData.WeaponBoxSizeY);
                weaponBox.Location = new Point(leftGameFieldOffset, 0);
                weaponBox.Parent = this.gameWindow;
                this.weaponBoxes[field] = weaponBox;

                this.gameWindow.Controls.Add(weaponBox);
            }
        }

        private void CreateHealthPointsBar()
        {
            PictureBox healthPointsBox;
            int leftGameeFieldOffset = GlobalGameData.WeaponBoxSizeX * GlobalGameData.WeaponBoxesCount + 10;

            for (int box = 0; box < GlobalGameData.HealthPointsBoxesCount; box++)
            {
                int boxXCoordinate = leftGameeFieldOffset + GlobalGameData.HealthPointsBoxesSizeX * box;

                healthPointsBox = new PictureBox();
                healthPointsBox.Size = new Size(
                    GlobalGameData.HealthPointsBoxesSizeX, GlobalGameData.HealthPointsBoxesSizeY);
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

            this.pictureBoxes.Add(renderableObject, picBox);
            this.gameWindow.Controls.Add(picBox);
        }
    }
}
