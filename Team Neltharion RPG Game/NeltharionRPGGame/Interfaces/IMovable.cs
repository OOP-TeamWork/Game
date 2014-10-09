﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeltharionRPGGame
{
    public interface IMovable
    {
        int MovementSpeed { get; set; }

        int DirX { get; set; }

        int DirY { get; set; }

        void Move();
    }
}
