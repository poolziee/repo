using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class EmployeePlanner :IComparable<EmployeePlanner>
    {
        public Employee Employee { get; set; }
        public string Occupation { get; set; }
        public int EmptyShiftIndex { get; set; }
        public double HoursWorked { get; set; }
        public string PreferedShift { get; set; }

        public EmployeePlanner(Employee emp, string occupation, int emptyShiftIndex, double hoursWorked)
        {
            Employee = emp;
            Occupation = occupation;
            EmptyShiftIndex = emptyShiftIndex;
            HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            return ($"{Employee.Id} {Employee.FullName}, Occupation:{Occupation}| {HoursWorked} hr worked/ {Employee.ContractHours} hr contract");
        }

        public int CompareTo(EmployeePlanner other)
        {
            if(this.HoursWorked > other.HoursWorked)
            {
                return 1;
            }
            else if(other.HoursWorked > this.HoursWorked)
            {
                return -1;
            }
            return 0;
           
        }
    }
}
