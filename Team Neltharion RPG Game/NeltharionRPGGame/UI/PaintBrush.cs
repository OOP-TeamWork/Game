using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.UI
{
    public class PaintBrush : IDrawable
    {
        // Weapon bar data
        private const int WeaponBoxSizeX = 40;
        private const int WeaponBoxSizeY = 40;
        private const int WeaponFieldsCount = 3;

        // Health Points Bar Data
        private const int HealthPointsFieldsCount = 3;

        private const string MageImagePath = "../../Graphics/mage.png";
        private const string WitchImagePath = "../../Graphics/witch.png";
        private const string FighterImagePath = "../../Graphics/fighter.png";
        private const string SwordImagePath = "../../Graphics/sword.png";
        private const string DefaulthWeaponImagePath = "../../Graphics/default.png";
        // load additional images here and add them to GetSpriteImage method

        private Image mageImage;
        private Image witchImage;
        private Image fighterImage;
        private Image swordImage;
        private Image defaultWeaponImage;
        private GameWindow gameWindow;
        private List<PictureBox> pictureBoxes;
        private PictureBox[] weaponFields; 

        public void InitializeField(GameWindow window)
        {
            this.gameWindow = window;
            this.LoadResources();
            this.pictureBoxes = new List<PictureBox>();
            this.weaponFields = new PictureBox[WeaponFieldsCount];
            CreateInventoryBar(this.weaponFields);
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
            for (int field = 0; field < WeaponFieldsCount; field++)
            {
                if (weapons[field] != null)
                {
                    this.weaponFields[field].Tag = weapons[field];
                    this.weaponFields[field].Image = GetSpriteImage(weapons[field]);
                }
                else
                {
                    weaponFields[field].Tag = null;
                    weaponFields[field].Image = defaultWeaponImage;
                }
            }
        }

        public void DrawHealthPointsBar(int maxHealthPoints, int healthPoints)
        {
            throw new System.NotImplementedException();
        }

        private void CreateInventoryBar(PictureBox[] weaponFields)
        {
            PictureBox weaponField;
            for (int field = 0; field < WeaponFieldsCount; field++)
            {
                weaponField = new PictureBox();
                int leftGameFieldOffset = field*WeaponBoxSizeX;
                weaponField.Size = new Size(WeaponBoxSizeX, WeaponBoxSizeY);
                weaponField.Location = new Point(leftGameFieldOffset, 0);
                weaponField.Parent = this.gameWindow;
                weaponFields[field] = weaponField;
                this.gameWindow.Controls.Add(weaponField);
            }
        }

        private void CreateHealthPointsBar()
        {
            PictureBox healthPointsField;
            for (int field = 0; field < HealthPointsFieldsCount; field++)
            {
                healthPointsField = new PictureBox();
                healthPointsField.Size = new Size(WeaponBoxSizeX, WeaponBoxSizeY);
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

        private PictureBox GetPictureBoxByObject(IRenderable renderableObject)
        {
            return this.pictureBoxes.First(p => p.Tag == renderableObject);
        }

        public void LoadResources()
        {
            this.mageImage = Image.FromFile(MageImagePath);
            this.witchImage = Image.FromFile(WitchImagePath);
            this.fighterImage = Image.FromFile(FighterImagePath);
            this.swordImage = Image.FromFile(SwordImagePath);
            this.defaultWeaponImage = Image.FromFile(DefaulthWeaponImagePath);
        }
    }
}
