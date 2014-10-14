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
        private const int ProgressBarSizeX = 60;
        private const int ProgressBarSizeY = 8;
        private const int ProgressBarOffsetX = -3;
        private const int ProgressBarOffsetY = -10;

        private const string MageImagePath = "../../Graphics/mage.png";
        private const string WitchImagePath = "../../Graphics/witch.png";
        private const string FighterImagePath = "../../Graphics/fighter.png";
        // load additional images here and add them to GetSpriteImage method

        private Image mageImage;
        private Image witchImage;
        private Image fighetrImage;
        private GameWindow gameWindow;
        private List<PictureBox> pictureBoxes;
        private List<ProgressBar> progressBars;

        public void InitializeField(GameWindow window)
        {
            this.gameWindow = window;
            this.LoadResources();
            this.pictureBoxes = new List<PictureBox>();
            this.progressBars = new List<ProgressBar>();
        }

        public void AddObject(IRenderable renderableObject)
        {
            this.CreatePictureBox(renderableObject);
            if (renderableObject is Creature)
            {
                this.CreateProgressBar(renderableObject as Creature);
            }
        }

        public void RemoveObject(IRenderable renderableObject)
        {
            var picBox = GetPictureBoxByObject(renderableObject);
            this.gameWindow.Controls.Remove(picBox);
            this.pictureBoxes.Remove(picBox);
            if (renderableObject is Creature)
            {
                var progressBar = GetProgressBarByObject(renderableObject as Creature);
                this.gameWindow.Controls.Remove(progressBar);
                this.progressBars.Remove(progressBar);
            }
        }

        public void RedrawObject(IRenderable objectToBeRedrawn)
        {
            var newCoordinates = new Point(objectToBeRedrawn.X, objectToBeRedrawn.Y);
            var picBox = GetPictureBoxByObject(objectToBeRedrawn);
            picBox.Location = newCoordinates;

            if (objectToBeRedrawn is Creature)
            {
                var unit = objectToBeRedrawn as Creature;
                var progressBar = GetProgressBarByObject(unit);
                this.SetProgressBarLocation(unit, progressBar);
                progressBar.Value = unit.HealthPoints;
            }
        }

        private void CreateProgressBar(Creature unit)
        {
            var progressBar = new ProgressBar();
            progressBar.Size = new Size(ProgressBarSizeX, ProgressBarSizeY);
            this.SetProgressBarLocation(unit, progressBar);
            progressBar.Maximum = unit.MaximumHealthPoints;
            progressBar.Value = unit.HealthPoints;
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

        private void SetProgressBarLocation(Creature unit, ProgressBar progressBar)
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
                case SpriteType.Witch:
                    image = this.witchImage;
                    break;
                case SpriteType.Fighter:
                    image = this.fighetrImage;
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

        private ProgressBar GetProgressBarByObject(Creature unit)
        {
            return this.progressBars.First(p => p.Tag == unit);
        }

        public void LoadResources()
        {
            this.mageImage = Image.FromFile(MageImagePath);
            this.witchImage = Image.FromFile(WitchImagePath);
            this.fighetrImage = Image.FromFile(FighterImagePath);
        }
    }
}
