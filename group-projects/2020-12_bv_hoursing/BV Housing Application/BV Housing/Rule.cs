using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV_Housing
{
    public class Rule
    {
        private String rule;
        public String TheRule
        {
            get {return this.rule;}
            set { this.rule = value;}
        }
        

        public Rule(String rule)
        {
            this.rule = rule;
        }
    }

}
