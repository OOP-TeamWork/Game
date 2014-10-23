using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NeltharionRPGGame.Interfaces
{
    public interface ITimeoutable
    {
        int MaximumTimeout { get; set; }

        int CurrentTimeout { get; set; }

        bool HasTimedOut { get; set; }
    }
}
