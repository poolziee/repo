using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace PRJMediaBazaar.Logic
{
    class Availabilities
    {
        private Employee[] _employees;
        private List<EmployeePlanner> _available;
        private List<EmployeePlanner> _unavailable;
        private AvailabilitiesDAL availabilitiesDAL;

        public Availabilities(Employee[] employeesOnPosition, Day day, Shift shift)
        {
            _available = new List<EmployeePlanner>();
            _unavailable = new List<EmployeePlanner>();
            _employees = employeesOnPosition;
            availabilitiesDAL = new AvailabilitiesDAL(employeesOnPosition.ToList());
            PopulateLists(day, shift);
            
        }

        public EmployeePlanner[] Available { get { return _available.ToArray(); } }
        public EmployeePlanner[] Unavailable { get { return _unavailable.ToArray(); } }


        private void PopulateLists(Day day, Shift shift)
        {


            List<EmployeeWorkday> workdays = availabilitiesDAL.SelectEmployeesWorkdays(day.WeekId,day.Id, _employees[0].JobPosition);
            List<Employee> busyEmployees = new List<Employee>();

            foreach(EmployeeWorkday wd in workdays) //employees in the workdays_table
            {
                Employee employee = wd.Employee;
                double hoursInfo =wd.Hours;
                if (!Convert.ToBoolean(wd.Absence)) //the employee isn't absent
                {
                    int index = Helper.GetEmptyShiftIndex(wd.FirstShift.ToString(), wd.SecondShift.ToString());
                    string busyShift = wd.GetBusyShift();

                    if (index == -1)  //employee has a double shift
                    {
                        EmployeePlanner ea = new EmployeePlanner(employee, "Double shift", -1, hoursInfo);
                        _unavailable.Add(ea);
                    }

                    else if (index != -1 && Helper.DoubleShiftIsValid(busyShift, shift.ToString())) //employee has only one shift, and the second one is valid
                    {

                        EmployeePlanner ea = new EmployeePlanner(employee, busyShift, index, hoursInfo);
                        ea.PreferedShift = availabilitiesDAL.GetPrefferedShift(employee.Id, day.Date);
                        _available.Add(ea);
                    }
                    else // the double shift is invalid
                    {
                        EmployeePlanner ea = new EmployeePlanner(employee,busyShift.ToString(), -1, hoursInfo);
                        _unavailable.Add(ea);
                    }
                }

                else if (wd.Absence) //is absent
                {
                    EmployeePlanner ea = new EmployeePlanner(employee, wd.AbsenceReason.ToString(), -1, hoursInfo);
                    _unavailable.Add(ea);
                }
                busyEmployees.Add(employee);

            }

            foreach (Employee employee in _employees) //if the employee is not in the busyEmployee list, add availability
            {
                if (!IsBusy(employee.Id,busyEmployees))
                {
                    double hoursInfo = availabilitiesDAL.SelectWorkedHours(day.WeekId, employee.Id);
                    EmployeePlanner ea = new EmployeePlanner(employee, "None", -1, hoursInfo);
                    ea.PreferedShift = availabilitiesDAL.GetPrefferedShift(employee.Id, day.Date);
                    _available.Add(ea);
                }
            }
            _available.Sort();
            availabilitiesDAL.CloseConnection();
        }

        private bool IsBusy(int id, List<Employee> busyEmps)
        {
            foreach(Employee e in busyEmps)
            {
                if(e.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
