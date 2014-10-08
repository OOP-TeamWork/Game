using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

using WorkshopGame.Interfaces;
using WorkshopGame.Structure;

namespace WorkshopGame.UI
{
    public class PaintBrush : IPaintInterface
    {
        private const int ProgressBarSizeX = 60;
        private const int ProgressBarSizeY = 8;
        private const int ProgressBarOffsetX = -3;
        private const int ProgressBarOffsetY = -10;
        
        private const string MageImagePath = "../../Graphics/mage.png";
        private const string HealthPotionImagePath = "../../Graphics/health-potion.png";
        private const string TreeImagePath = "../../Graphics/tree.png";
        private const string WallImagePath = "../../Graphics/wall.jpg";
        private const string FireImagePath = "../../Graphics/fire.png";
        private const string GhoulImagePath = "../../Graphics/ghoul.png";
        private const string SpitImagePath = "../../Graphics/spit.png";

        private Image mageImage, healthPotionImage, treeImage, wallImage, 
            fireImage, ghoulImage, spitImage;
        private Form gameWindow;
        private List<PictureBox> pictureBoxes;
        private List<ProgressBar> progressBars;

        public PaintBrush(Form form)
        {
            this.gameWindow = form;
            this.LoadResources();
            this.pictureBoxes = new List<PictureBox>();
            this.progressBars = new List<ProgressBar>();
        }

        public void AddObject(IRenderable renderableObject)
        {
            this.CreatePictureBox(renderableObject);
            if (renderableObject is IUnit)
            {
                this.CreateProgressBar(renderableObject as IUnit);
            }
        }

        public void RemoveObject(IRenderable renderableObject)
        {
            var picBox = GetPictureBoxByObject(renderableObject);
            this.gameWindow.Controls.Remove(picBox);
            this.pictureBoxes.Remove(picBox);
            if (renderableObject is IUnit)
            {
                var progressBar = GetProgressBarByObject(renderableObject as IUnit);
                this.gameWindow.Controls.Remove(progressBar);
                this.progressBars.Remove(progressBar);
            }
        }

        public void RedrawObject(IRenderable objectToBeRedrawn)
        {
            var newCoordinates = new Point(objectToBeRedrawn.X, objectToBeRedrawn.Y);
            var picBox = GetPictureBoxByObject(objectToBeRedrawn);
            picBox.Location = newCoordinates;

            if (objectToBeRedrawn is IUnit)
            {
                var unit = objectToBeRedrawn as IUnit;
                var progressBar = GetProgressBarByObject(unit);
                this.SetProgressBarLocation(unit, progressBar);
                progressBar.Value = unit.CurrentHealthPoints;
            }
        }

        private void CreateProgressBar(IUnit unit)
        {
            var progressBar = new ProgressBar();
            progressBar.Size = new Size(ProgressBarSizeX, ProgressBarSizeY);
            this.SetProgressBarLocation(unit, progressBar);
            progressBar.Maximum = unit.MaximumHealthPoints;
            progressBar.Value = unit.CurrentHealthPoints;
            progressBar.Tag = unit;
            progressBars.Add(progressBar);
            this.gameWindow.Controls.Add(progressBar);
        }

        private void CreatePictureBox(IRenderable renderableObject)
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

        private void SetProgressBarLocation(IUnit unit, ProgressBar progressBar)
        {
            progressBar.Location = new Point(unit.X + ProgressBarOffsetX, unit.Y + ProgressBarOffsetY);
        }

        private Image GetSpriteImage(IRenderable renderableObject)
        {
            Image image;
            switch (renderableObject.SpriteType)
            {
                case SpriteType.Mage:
                    image = this.mageImage;
                    break;
                case SpriteType.Fire:
                    image = this.fireImage;
                    break;
                case SpriteType.Ghoul:
                    image = this.ghoulImage;
                    break;
                case SpriteType.Spit:
                    image = this.spitImage;
                    break;
                default:
                    image = this.wallImage;
                    break;
            }
            return image;
        }

        private PictureBox GetPictureBoxByObject(IRenderable renderableObject)
        {
            return this.pictureBoxes.First(p => p.Tag == renderableObject);
        }

        private ProgressBar GetProgressBarByObject(IUnit unit)
        {
            return this.progressBars.First(p => p.Tag == unit);
        }

        public void LoadResources()
        {
            this.mageImage = Image.FromFile(MageImagePath);
            this.healthPotionImage = Image.FromFile(HealthPotionImagePath);
            this.treeImage = Image.FromFile(TreeImagePath);
            this.wallImage = Image.FromFile(WallImagePath);
            this.fireImage = Image.FromFile(FireImagePath);
            this.ghoulImage = Image.FromFile(GhoulImagePath);
            this.spitImage = Image.FromFile(SpitImagePath);
        }
    }
}
