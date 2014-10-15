using System;
using System.Windows.Forms;
using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame.UI
{
    public class KeyboardMouseController : IInputInterface
    {
        public event EventHandler OnLeftMouseClicked;
        public event EventHandler OnKeyAPressed;
        public event EventHandler OnKeyWPressed;
        public event EventHandler OnKeyDPressed;
        public event EventHandler OnSpacePressed; //  This Event is only for debugging usage

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
                    if (OnKeyAPressed != null)
                    {
                        this.OnKeyAPressed(this, new EventArgs());
                    }
                    break;
                case Keys.W:
                    if (OnKeyWPressed != null)
                    {
                        this.OnKeyWPressed(this, new EventArgs());
                    }
                    break;
                case Keys.D:
                    if (OnKeyDPressed != null)
                    {
                        this.OnKeyDPressed(this, new EventArgs());
                    }
                    break;
                case Keys.Space:
                    if (OnSpacePressed != null)
                    {
                        this.OnSpacePressed(this, new EventArgs());
                    }
                    break;
            }
        }
    }
}
