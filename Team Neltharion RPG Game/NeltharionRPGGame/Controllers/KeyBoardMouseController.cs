using System;
using System.Windows.Forms;
using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame.UI
{
    public class KeyboardMouseController : IInputInterface
    {
        public event EventHandler OnLeftMouseClicked;

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
                default:
                    break;
            }
        }
    }
}
