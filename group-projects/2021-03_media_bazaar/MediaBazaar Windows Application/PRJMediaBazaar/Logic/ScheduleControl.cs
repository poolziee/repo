using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace PRJMediaBazaar.Logic
{
    class ScheduleControl
    {

        protected List<Schedule> _schedules;
        protected EmployeeControl _empControl;
        protected ScheduleDAL scheduleDAL;

        public ScheduleControl(EmployeeControl employeeControl)
        {
            _schedules = new List<Schedule>();
            _empControl = employeeControl;
            scheduleDAL = new ScheduleDAL(_empControl.GetAllEmployees());
            LoadSchedules();
        }

        public EmployeeControl EmployeeControl{ get { return _empControl; } }

        public Schedule[] Schedules { get { return _schedules.ToArray(); } }

        private void LoadSchedules()
        {
            _schedules = scheduleDAL.SelectSchedules();
        }


        public Day[] GetDays(int scheduleId)
        {
            foreach (Schedule s in _schedules)
            {
                if (s.Id == scheduleId)
                {
                    return s.Days;
                }
            }
            return null;
        }



        public void DecreaseAssignedPosition(Day day, string jobPosition, string shift)
        {
            Duty duty = day.GetDuty(jobPosition);
            int morning = duty.MorningAssigned;
            int midday = duty.MiddayAssigned;
            int evening = duty.EveningAssigned;
            switch (shift)
            {
                case "Morning":
                    morning -= 1;
                    break;
                case "Midday":
                    midday -= 1;
                    break;
                case "Evening":
                    evening -= 1;
                    break;
            }
            day.ChangeAssignedDuties(jobPosition, morning, midday, evening);
        }

        public void IncreaseAssignedPosition(Day day, string jobPosition, string shift)
        {
            Duty duty = day.GetDuty(jobPosition);
            int morning = duty.MorningAssigned;
            int midday = duty.MiddayAssigned;
            int evening = duty.EveningAssigned;
            switch (shift)
            {
                case "Morning":
                    morning += 1;
                    break;
                case "Midday":
                    midday += 1;
                    break;
                case "Evening":
                    evening += 1;
                    break;
            }
            day.ChangeAssignedDuties(jobPosition, morning, midday, evening);
        }

        public bool UpdateHours(double hours,int weekId,int employeeId)
        {
           return  scheduleDAL.UpdateHours(hours, weekId, employeeId);
        }

        public EmployeeWorkday[] GetEmployeesShifts(int weekId, int dayId, string jobPosition)
        {

            return scheduleDAL.SelectEmployeesShifts(weekId, dayId, jobPosition).ToArray();

        }

        public void RemoveShift(string shift, Day day, Employee employee, bool all = false)
        {
            EmployeeWorkday result = scheduleDAL.SelectEmployeeShift(day.WeekId,day.Id, employee.Id);
            if (result != null)
            {
                int emptyShiftIndex = Helper.GetEmptyShiftIndex(result.FirstShift.ToString(), result.SecondShift.ToString());
                if (emptyShiftIndex != -1 && !result.Absence) //if there is an empty shift, remove the row
                {
                    scheduleDAL.DeleteShift(day.Id, employee.Id);
                    DecreaseAssignedPosition(day, employee.JobPosition, shift);
                    scheduleDAL.UpdateHours(result.Hours - 4.5, day.ScheduleId, employee.Id);

                }
                else if (emptyShiftIndex == -1 && !result.Absence)//if there is a double shift,insert None on the chosen one
                {
                   if(all == false)
                    {
                        if (result.FirstShift.ToString() == shift)
                        {
                            scheduleDAL.UpdateShift(2, "None", day.Id, employee.Id);

                        }
                        else if (result.SecondShift.ToString() == shift)
                        {

                            scheduleDAL.UpdateShift(3, "None", day.Id, employee.Id);

                        }
                        DecreaseAssignedPosition(day, employee.JobPosition, shift);
                        scheduleDAL.UpdateHours(result.Hours - 4.5, day.ScheduleId, employee.Id);
                    }
                    else
                    {
                        scheduleDAL.DeleteShift(day.Id, employee.Id);
                        DecreaseAssignedPosition(day, employee.JobPosition, result.FirstShift.ToString());
                        DecreaseAssignedPosition(day, employee.JobPosition, result.SecondShift.ToString());
                        scheduleDAL.UpdateHours(result.Hours - 9, day.ScheduleId, employee.Id);
                    }

                }
               

            }
        }

        public EmployeeWorkday GetEmployeeShift(int weekId, int dayId, int employeeId)
        {
            return scheduleDAL.SelectEmployeeShift(weekId, dayId, employeeId);
        }
     
        public void AssignShift(string shift, Employee employee, Day day, int emptyShiftIndex, double hours)
        {
            EmployeeWorkday wd = scheduleDAL.SelectEmployeeShift(day.WeekId,day.Id, employee.Id);
            if (wd != null)
            {
                scheduleDAL.UpdateShift(emptyShiftIndex, shift, day.Id, employee.Id);
            }
            else
            {
                scheduleDAL.InsertShift(day.Id, employee.Id, shift);
            }

            if (hours == 4.5)
            {
                scheduleDAL.InsertHours(hours, day.WeekId, employee.Id);
            }
            else
            {
                scheduleDAL.UpdateHours(hours, day.WeekId, employee.Id);
            }

            IncreaseAssignedPosition(day, employee.JobPosition, shift);

        }




        public string DayStatus(Day d)
        {
            int count = d.AllPositions.Count();
            int complete = 0;
            int empty = 0;

            foreach (Duty np in d.AllPositions)
            {
               
                if (np.MorningAssigned == np.MorningNeeded && np.MiddayAssigned == np.MiddayNeeded  && np.EveningAssigned == np.EveningNeeded)
                {
                    complete++;
                    if(complete == count)
                    {
                        return "complete";
                    }
                }
                else if (np.MorningAssigned == 0 && np.MiddayAssigned == 0 && np.EveningAssigned == 0)
                {
                    empty++;
                    if(empty == count)
                    {
                        return "empty";
                    }
                   
                }
            }
            return "started";
        }
        public string ScheduleStatus(Schedule s)
        {
            return ScheduleStatus(s.Days);

        }


        private string ScheduleStatus(Day[] days)
        {
            int complete = 0;
            int started = 0;
            int empty = 0;
            foreach (Day d in days)
            {
                if (DayStatus(d) == "complete")
                {
                    complete++;
                }
                else if (DayStatus(d) == "started")
                {
                    started++;
                }
                else
                {
                    empty++;
                }
            }

            if (empty == 14)
            {
                return "empty";
            }
            if (complete == 14)
            {
                return "complete";
            }
            return "started";

        }


        public void GenerateSchedule(Day day)
        {

            Duty[] positions = day.AllPositions;

            foreach (Duty p in positions)
            {

                while (p.MaxValue() > p.MaxAssigned())
                {
                    if (p.MorningNeeded > p.MorningAssigned)
                    {
                        EmployeePlanner available = GetFirstAvailableEmployeePlanner(day, Shift.Morning, p.Position);
                        if(available != null)
                        {
                            double workedHours = available.HoursWorked;
                            AssignShift(Shift.Morning.ToString(), available.Employee, day, available.EmptyShiftIndex, workedHours + 4.5);
                        }
                      
                    }

                    if (p.MiddayNeeded > p.MiddayAssigned)
                    {
                        EmployeePlanner available = GetFirstAvailableEmployeePlanner(day, Shift.Midday, p.Position);
                        if(available != null)
                        {
                            double workedHours = available.HoursWorked;
                            AssignShift(Shift.Midday.ToString(), available.Employee, day, available.EmptyShiftIndex, workedHours + 4.5);
                        }
                        
                    }

                    if (p.EveningNeeded > p.EveningAssigned)
                    {
                        EmployeePlanner available = GetFirstAvailableEmployeePlanner(day, Shift.Evening, p.Position);

                        if(available != null)
                        {
                            double workedHours = available.HoursWorked;
                            AssignShift(Shift.Evening.ToString(), available.Employee, day, available.EmptyShiftIndex, workedHours + 4.5);
                        }
                       
                    }
                }
            }
        }

        public void RemoveSchedule(Day day)
        {
            
            //day.EmptyDuties();
            foreach (string position in Day.positions)
            {
                foreach (EmployeeWorkday wd in scheduleDAL.SelectEmployeesShifts(day.WeekId,day.Id, position))
                {
                    
                    RemoveShift(wd.GetShift(),day,wd.Employee, true);
                }
            }
        }

        private EmployeePlanner GetFirstAvailableEmployeePlanner(Day day, Shift shift, string position)
        {
            
            EmployeePlanner ep = scheduleDAL.SelectFirstAvailableEmployeePlanner(position, day.WeekId, day.Id);
            if (ep != null)
            {
                return ep;
            }
            return scheduleDAL.SelectAvailableEmployeePlanner(day.Id, position, day.WeekId, shift);
        }
    }
}
