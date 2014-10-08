using System;

namespace WorkshopGame.Interfaces
{
    public interface IUserInputInterface
    {
        event EventHandler OnRightPressed;
        event EventHandler OnLeftPressed;
        event EventHandler OnUpPressed;
        event EventHandler OnDownPressed;
        event EventHandler OnSpellOnePressed;
    }
}
