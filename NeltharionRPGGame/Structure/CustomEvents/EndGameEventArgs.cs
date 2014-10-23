namespace NeltharionRPGGame.Structure.CustomEvents
{
    public class EndGameEventArgs
    {
        private string endGameMessage;

        public EndGameEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}
