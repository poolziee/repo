using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV_Housing
{
    public class Complain
    {
        private String complain;

        public String TheComplain
        {
            get { return complain; }
        }

        public Complain(String complain)
            {
               this.complain = complain;
            }
    }

}
