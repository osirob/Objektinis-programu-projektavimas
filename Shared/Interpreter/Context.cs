using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interpreter
{
    public class Context
    {
        string input;
        string output;

        public Context(string input){
            this.input = input;
        }

        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        public string Result
        {
            get { return output; }
            set { output = value; }
        }
    }
}
