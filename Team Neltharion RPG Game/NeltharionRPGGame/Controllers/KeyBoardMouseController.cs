using System;
using System.Windows.Forms;
using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame.UI
{
    public class KeyboardMouseController : IInputInterface
    {
        public event EventHandler OnRightPressed;

        public event EventHandler OnLeftPressed;

        public event EventHandler OnUpPressed;

        public event EventHandler OnDownPressed;

        public event EventHandler OnLeftMouseClicked;

        // the constructor binds our FormKeyDown method to Windows.Forms.OnKeyDown event, so we can handle the event from the form
        // using our delegates OnRightPressed, OnLeftPressed, OnUpPressed, OnDownPressed
        public KeyboardMouseController(Form form)
        {
            form.KeyDown += FormKeyDown;
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

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (this.OnUpPressed != null)
                    {
                        this.OnUpPressed(this, new EventArgs()); // setting mandatory delegate args that we wont actually use as data
                    }
                    break;
                case Keys.D:
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                    break;
                case Keys.S:
                    if (this.OnDownPressed != null)
                    {
                        this.OnDownPressed(this, new EventArgs());
                    }
                    break;
                case Keys.A:
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
