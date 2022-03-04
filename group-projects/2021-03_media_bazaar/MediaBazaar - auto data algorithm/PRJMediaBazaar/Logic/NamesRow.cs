using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class NamesRow
    {
        public Employee Morning { get; set; }
        public Employee Midday { get; set; }
        public Employee Evening { get; set; }

        public NamesRow(Employee morningEmployee, Employee middayEmployee, Employee eveningEmployee)
        {
            Morning = morningEmployee;
            Midday = middayEmployee;
            Evening = eveningEmployee;
        }

    }
}
