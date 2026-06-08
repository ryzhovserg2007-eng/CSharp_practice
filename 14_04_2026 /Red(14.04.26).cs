using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    public abstract class Red : Object
    {
        protected string _input;
        public string Input => _input;

        protected Red(string input)
        {
            _input = input;
        }
        public abstract void Review();

        public virtual void ChangeText(string text)
        {
            _input = text;
            Review();
        }
    }
}
