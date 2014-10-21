using System;
using System.Windows.Forms;
using NeltharionRPGGame.Controllers;
using NeltharionRPGGame.GameEngine;

namespace NeltharionRPGGame.UI
{
    public partial class GameWindow : Form, IMessageFilter
    {
        public const int RefreshInterval = 50;

        private KeyboardMouseController controller;
        public Engine gameEngine;

        public GameWindow()
        {
            InitializeComponent();   
            Application.AddMessageFilter(this);
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            // For Debugging Timer Is Disabled
            // Just Comment Timer

            Timer timer = new Timer();
            timer.Interval = RefreshInterval;
            timer.Tick += OnTimerTick;
          
            controller = new KeyboardMouseController(this); 

            PaintBrush painter = new PaintBrush();
            painter.InitializeField(this);

            this.gameEngine = new Engine();
            this.gameEngine.InitializeWorld(controller, painter);

            timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            this.gameEngine.PlayNextTurn();
        }

        public bool PreFilterMessage(ref Message m)
        {
            const int MessageCodeRighttMouseClick = 0x0204;

            if (m.Msg == MessageCodeRighttMouseClick)
            {
                var userClick = this.PointToClient(Cursor.Position);
                this.controller.MouseClicked(
                    this, new MouseEventArgs(
                        MouseButtons.Right, 1, userClick.X, userClick.Y, 0));
                return true;
            }
            return false;
        }
    }
}
