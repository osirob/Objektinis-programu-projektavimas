using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
