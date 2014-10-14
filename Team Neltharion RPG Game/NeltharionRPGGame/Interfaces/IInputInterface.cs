using System;

namespace NeltharionRPGGame.Interfaces
{
    public interface IInputInterface
    {
        event EventHandler OnLeftMouseClicked;
        event EventHandler OnKeyOnePressed;
        event EventHandler OnKeyTwoPressed;
        event EventHandler OnKeyThreePressed;
    }
}
