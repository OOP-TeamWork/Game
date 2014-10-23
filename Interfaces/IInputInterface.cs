using System;

namespace NeltharionRPGGame.Interfaces
{
    public interface IInputInterface
    {
        bool ControllerEnabled { get; set; }

        event EventHandler OnLeftMouseClicked;
        event EventHandler OnRightMouseClicked;
        event EventHandler OnKeyOnePressed;
        event EventHandler OnKeyTwoPressed;
        event EventHandler OnKeyThreePressed;
        event EventHandler OnSpacePressed;
        event EventHandler OnQPressed;
    }
}
