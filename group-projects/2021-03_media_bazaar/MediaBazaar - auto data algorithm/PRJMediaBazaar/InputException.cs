using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class InputException : Exception
    {
        private List<string> _errors = new List<string>();
        public InputException(List<string> errors) : base()
        {
            _errors = errors;
        }

        public override string ToString()
        {
           return String.Join("\n", _errors);
        }
    }
}
