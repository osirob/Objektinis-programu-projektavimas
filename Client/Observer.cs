﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public abstract class Observer
    {
        public Subject? subject = null;
        public abstract void UpdateCordinatesFirstPlayer(string cordinates);
    }
}
