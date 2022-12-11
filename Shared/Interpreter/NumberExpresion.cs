using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interpreter
{
    public class NumberExpresion : Expresion
    {
        private int number;
        public NumberExpresion(int number)
        {
            this.number = number;
        }
        public NumberExpresion(string number)
        {
            this.number = int.Parse(number);
        }
        public object intepret()
        {
            return this.number;
        }
    }
}
