using System;
using System.Windows.Forms;
using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame.UI
{
    public class KeyboardMouseController : IInputInterface
    {
        public event EventHandler OnLeftMouseClicked;
        public event EventHandler OnRightMouseClicked;
        public event EventHandler OnKeyOnePressed;
        public event EventHandler OnKeyTwoPressed;
        public event EventHandler OnKeyThreePressed;

        public KeyboardMouseController(Form form)
        {
            form.MouseClick += MouseClicked;
        }

        private void MouseClicked(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (this.OnLeftMouseClicked != null)
                    {
                        this.OnLeftMouseClicked(sender, e);
                    }
                    break;
                case MouseButtons.Right:
                    if (this.OnRightMouseClicked != null)
                    {
                        this.OnRightMouseClicked(sender, e);
                    }
                    break;
                default:
                    break;
            }
        }

        private void FormKeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (OnKeyOnePressed != null)
                    {
                        this.OnKeyOnePressed(this, new EventArgs());
                    }
                    break;
                case Keys.E:
                    if (OnKeyTwoPressed != null)
                    {
                        this.OnKeyTwoPressed(this, new EventArgs());
                    }
                    break;
                case Keys.R:
                    if (OnKeyThreePressed != null)
                    {
                        this.OnKeyThreePressed(this, new EventArgs());
                    }
                    break;
            }
        }
    }
}
