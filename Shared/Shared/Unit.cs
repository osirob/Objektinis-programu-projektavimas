using Shared.Observer;
using System;
using System.Collections.Generic;
using System.Text;


namespace Shared.Shared
{
    public abstract class Unit : Observer.Observer
    {
        protected Position position = new Position();


        /*
        public Unit(Subject subject)
        {
            this.subject = subject;
            this.subject.Subscribe(this);
        }
        */

    }
}
