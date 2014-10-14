using System;
using System.Windows.Forms;
using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame.UI
{
    public class KeyboardMouseController : IInputInterface
    {
        public event EventHandler OnLeftMouseClicked;
        public event EventHandler OnKeyOnePressed;
        public event EventHandler OnKeyTwoPressed;
        public event EventHandler OnKeyThreePressed;

        public KeyboardMouseController(Form form)
        {
            form.KeyDown += FormKeyPressed;
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
                default:
                    break;
            }
        }

        private void FormKeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (OnKeyOnePressed != null)
                    {
                        this.OnKeyOnePressed(this, new EventArgs());
                    }
                    break;
                case Keys.W:
                    if (OnKeyTwoPressed != null)
                    {
                        this.OnKeyTwoPressed(this, new EventArgs());
                    }
                    break;
                case Keys.D:
                    if (OnKeyThreePressed != null)
                    {
                        this.OnKeyThreePressed(this, new EventArgs());
                    }
                    break;
            }
        }
    }
}
