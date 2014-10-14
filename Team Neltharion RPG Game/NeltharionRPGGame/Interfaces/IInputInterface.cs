using System;

namespace NeltharionRPGGame.Interfaces
{
    public interface IInputInterface
    {
        event EventHandler OnRightPressed;
        event EventHandler OnLeftPressed;
        event EventHandler OnUpPressed;
        event EventHandler OnDownPressed;
        event EventHandler OnLeftMouseClicked;
    }
}
