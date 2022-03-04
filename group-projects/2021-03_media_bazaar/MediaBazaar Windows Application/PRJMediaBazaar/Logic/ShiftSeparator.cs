using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class ShiftSeparator
    {

        private int neededShiftAmount;
        private EmployeeWorkday[] workdays;
        private List<Employee> morning;
        private List<Employee> mid;
        private List<Employee> evening;

        public int MorningCount { get; private set; }
        public int MiddayCount { get; private set; }
        public int EveningCount { get; private set; }

        public ShiftSeparator(EmployeeWorkday[] workdays, int neededShiftAmount)
        {
            morning = new List<Employee>();
            mid = new List<Employee>();
            evening = new List<Employee>();
            this.workdays = workdays;
            this.neededShiftAmount = neededShiftAmount;
            SeparateShifts();
        }

        private void SeparateShifts()
        {

            if (workdays != null)
            {
                foreach (EmployeeWorkday ew in workdays)
                {
                 
                    if (ew.SecondShift == Shift.None || ew.FirstShift == Shift.None) //1  assigned shift
                    {
                        Shift busyShift = GetBusyShift(ew.FirstShift, ew.SecondShift);


                        switch (busyShift)
                        {
                            case Shift.Morning:
                                morning.Add(ew.Employee);
                                break;
                            case Shift.Midday:
                                mid.Add(ew.Employee);
                                break;
                            case Shift.Evening:
                                evening.Add(ew.Employee);
                                break;
                        }
                    }
                    else  //2 assigned shifts
                    {
                        Shift emptyShift = GetEmptyShift(ew.FirstShift, ew.SecondShift);

                        string employeeName = ew.Employee.FullName;

                        switch (emptyShift)
                        {
                            case Shift.Morning:
                                mid.Add(ew.Employee);
                                evening.Add(ew.Employee);
                                break;

                            case Shift.Evening:
                                morning.Add(ew.Employee);
                                mid.Add(ew.Employee);
                                break;
                        }
                    }
                }

            }

            MorningCount = morning.Count();
            MiddayCount = mid.Count();
            EveningCount = evening.Count();

            while (morning.Count < neededShiftAmount)
            {
                morning.Add(null);
            }
            while (mid.Count < neededShiftAmount)
            {
                mid.Add(null);
            }
            while (evening.Count < neededShiftAmount)
            {
                evening.Add(null);
            }

        }

        public NamesRow[] GetNamesRows()
        {
            List<NamesRow> rows = new List<NamesRow>();
            for (int i = 0; i < neededShiftAmount; i++)
            {
                rows.Add(new NamesRow(morning[i], mid[i], evening[i]));
            }
            return rows.ToArray();
        }

        private Shift GetEmptyShift(Shift firstShift, Shift secondShift)
        {
            if (firstShift == Shift.None)
            {
                return firstShift;
            }
            else if (secondShift == Shift.None)
            {
                return secondShift;
            }
            else if ((firstShift == Shift.Morning && secondShift == Shift.Midday) || (secondShift == Shift.Morning && firstShift == Shift.Midday))
            {
                return Shift.Evening;
            }
            else if ((firstShift == Shift.Midday && secondShift == Shift.Evening) || (secondShift == Shift.Midday && firstShift == Shift.Evening))
            {
                return Shift.Morning;
            }
            return Shift.None;

        }

        private Shift GetBusyShift(Shift firstShift, Shift secondShift)
        {
            if (firstShift != Shift.None)
            {
                return firstShift;
            }
            return secondShift;

        }

    }
}
