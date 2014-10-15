using System;

namespace NeltharionRPGGame.Interfaces
{
    public interface IInputInterface
    {
        event EventHandler OnLeftMouseClicked;
        event EventHandler OnKeyAPressed;
        event EventHandler OnKeyWPressed;
        event EventHandler OnKeyDPressed;
        event EventHandler OnSpacePressed;
    }
}
