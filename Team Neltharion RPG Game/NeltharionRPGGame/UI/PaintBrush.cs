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

        private const string MageImagePath = "../../Graphics/mage.png";
        private const string WitchImagePath = "../../Graphics/witch.png";
        private const string FighterImagePath = "../../Graphics/fighter.png";
        private const string SwordImagePath = "../../Graphics/sword.png";
        private const string DefaulthWeaponImagePath = "../../Graphics/default.png";
        private const string RedHealthHeartImagePath = "../../Graphics/redHeart.png";
        private const string BlackHealthHeartImagePath = "../../Graphics/blackHeart.png";
        // load additional images here and add them to GetSpriteImage method

        private List<PictureBox> pictureBoxes;
        private Image mageImage;
        private Image witchImage;
        private Image fighterImage;
        private Image swordImage;
        private Image defaultWeaponImage;
        private Image redHeartImage;
        private Image blackHeartImage;
        private GameWindow gameWindow;
        private PictureBox[] weaponBoxes;
        private PictureBox[] healthPointsBoxes;

        public List<PictureBox> PictureBoxes
        {
            get
            {
                return this.pictureBoxes;
            }
        }

        public void InitializeField(GameWindow window)
        {
            this.gameWindow = window;
            this.LoadResources();
            this.pictureBoxes = new List<PictureBox>();
            this.weaponBoxes = new PictureBox[WeaponBoxesCount];
            CreateInventoryBar();
            this.healthPointsBoxes = new PictureBox[HealthPointsBoxesCount];
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
                    this.weaponBoxes[box].Image = GetSpriteImage(weapons[box]);
                }
                else
                {
                    weaponBoxes[box].Tag = null;
                    weaponBoxes[box].Image = defaultWeaponImage;
                }
            }
        }

        public void DrawHealthPointsBar(int maxHealthPoints, int healthPoints)
        {
            int firstHearthMaxValue = maxHealthPoints/HealthPointsBoxesCount;
            int secondHearthMaxValue = firstHearthMaxValue*2;
            if (healthPoints > secondHearthMaxValue)
            {
                this.healthPointsBoxes[0].Image = this.redHeartImage;
                this.healthPointsBoxes[1].Image = this.redHeartImage;
                this.healthPointsBoxes[2].Image = this.redHeartImage;
            }
            else if (healthPoints > firstHearthMaxValue)
            {
                this.healthPointsBoxes[2].Image = this.blackHeartImage;
            }
            else
            {
                this.healthPointsBoxes[1].Image = this.blackHeartImage;
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
            int leftGameeFieldOffset = WeaponBoxSizeX*WeaponBoxesCount + 10;
            for (int box = 0; box < HealthPointsBoxesCount; box++)
            {
                int boxXCoordinate = leftGameeFieldOffset + HeallthPointsBoxesSizeX*box;
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
            var spriteImage = GetSpriteImage(renderableObject);
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

        private Image GetSpriteImage(IRenderable renderableObject)
        {
            Image image;
            switch (renderableObject.SpriteType)
            {
                case SpriteType.Mage:
                    image = this.mageImage;
                    break;
                case SpriteType.Witch:
                    image = this.witchImage;
                    break;
                case SpriteType.Fighter:
                    image = this.fighterImage;
                    break;
                case SpriteType.Sword:
                    image = this.swordImage;
                    break;
                default:
                    image = null; 
                    break;
            }
            return image;
        }

        public void LoadResources()
        {
            this.mageImage = Image.FromFile(MageImagePath);
            this.witchImage = Image.FromFile(WitchImagePath);
            this.fighterImage = Image.FromFile(FighterImagePath);
            this.swordImage = Image.FromFile(SwordImagePath);
            this.defaultWeaponImage = Image.FromFile(DefaulthWeaponImagePath);
            this.redHeartImage = Image.FromFile(RedHealthHeartImagePath);
            this.blackHeartImage = Image.FromFile(BlackHealthHeartImagePath);
        }
    }
}
