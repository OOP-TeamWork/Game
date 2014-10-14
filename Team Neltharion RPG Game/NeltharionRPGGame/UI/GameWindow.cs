using System;
using System.Windows.Forms;
using NeltharionRPGGame.GameEngine;
using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame.UI
{
    public partial class GameWindow : Form
    {
        public const int RefreshInterval = 50;
        public Engine gameEngine;

        public GameWindow()
        {
            InitializeComponent();   
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = RefreshInterval;
            timer.Tick += OnTimerTick;
          
            IInputInterface controller = new KeyboardMouseController(this); 
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
    }
}
