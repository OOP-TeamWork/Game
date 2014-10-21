using System;
using System.Windows.Forms;
using NeltharionRPGGame.Helper;
using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame.Controllers
{
    public class KeyboardMouseController : IInputInterface
    {
        public event EventHandler OnLeftMouseClicked;
        public event EventHandler OnRightMouseClicked;
        public event EventHandler OnKeyOnePressed;
        public event EventHandler OnKeyTwoPressed;
        public event EventHandler OnKeyThreePressed;
        public event EventHandler OnSpacePressed; //  This Event is only for debugging usage
        public event EventHandler OnQPressed;

        public KeyboardMouseController(Form form)
        {
            form.KeyDown += FormKeyPressed;
            form.MouseClick += MouseClicked;
        }

        public void MouseClicked(object sender, MouseEventArgs e)
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

        private void FormKeyPressed(object sender, EventArgs e)
        {
            KeyEventArgs keyArgs = e as KeyEventArgs;

            switch (keyArgs.KeyCode)
            {
                case Keys.D1:
                    if (OnKeyOnePressed != null)
                    {
                        this.OnKeyOnePressed(this, new EventArgs());
                    }
                    break;
                case Keys.D2:
                    if (OnKeyTwoPressed != null)
                    {
                        this.OnKeyTwoPressed(this, new EventArgs());
                    }
                    break;
                case Keys.D3:
                    if (OnKeyThreePressed != null)
                    {
                        this.OnKeyThreePressed(this, new EventArgs());
                    }
                    break;
                case Keys.Space:
                    if (OnSpacePressed != null)
                    {
                        this.OnSpacePressed(this, new EventArgs());
                    }
                    break;   
                case Keys.Q:
                    if (OnQPressed != null)
                    {
                        this.OnQPressed(this, new SpellCastEventArgs(Cursor.Position.X - GlobalGameData.OffsetX,
                            Cursor.Position.Y - GlobalGameData.OffsetY));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}