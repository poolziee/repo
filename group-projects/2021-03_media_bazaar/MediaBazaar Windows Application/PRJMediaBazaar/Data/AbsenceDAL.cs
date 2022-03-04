using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Logic;
using MySql.Data.MySqlClient;

namespace PRJMediaBazaar.Data
{
    class AbsenceDAL : BaseDAL
    {
        List<Employee> _employees;
        ScheduleControl _scheduleControl;
        public AbsenceDAL(List<Employee> employees, ScheduleControl scheduleControl)
        {
            _employees = employees;
            _scheduleControl = scheduleControl;
        }

        //public List<DayOff> SelectDayOffRequests()
        //{
        //    string sql = "SELECT * FROM dayoff_requests WHERE status = 'pending'; ";
        //    MySqlDataReader result = executeReader(sql, null);

        //    List<DayOff> pseudos = new List<DayOff>();
        //    while (result.Read())
        //    {
        //        int scheduleId = Convert.ToInt32(result[0]);

        //        int dayId = Convert.ToInt32(result[1]);
        //        Day day = GetSchedule(scheduleId).GetDay(dayId);

        //        int empId = Convert.ToInt32(result[2]);
        //        Employee employee = _employees.FirstOrDefault(emp => emp.Id == empId);

        //        bool urgent = Convert.ToBoolean(result[3]);
        //        string status = result[4].ToString();
        //        string reason = result[5].ToString();
        //        DayOff req = new DayOff(day, employee, urgent, status, reason);
        //        pseudos.Add(req);
        //    }
        //    CloseConnection();
        //    return pseudos;
        //}

        public List<DayOff> SelectDayOffRequests(string status)
        {
            string sql = "SELECT * FROM dayoff_requests WHERE status = @status; ";
            string[] parameters = new string[] { status };
            MySqlDataReader result = executeReader(sql, parameters);

            List<DayOff> pseudos = new List<DayOff>();
            while (result.Read())
            {
                int request_id = Convert.ToInt32(result[0]);
                int first_dayId = Convert.ToInt32(result[1]);
                int last_dayId = 0;
                if(result[2] != DBNull.Value)
                {
                    last_dayId = Convert.ToInt32(result[2]);
                }

                int empId = Convert.ToInt32(result[3]);
                Employee employee = _employees.FirstOrDefault(emp => emp.Id == empId);

                var shifts = GetShifts(first_dayId, last_dayId, empId);

                bool urgent = Convert.ToBoolean(result[4]);
                string reason = result[5].ToString();
                string objection = result[7].ToString();
                DayOff req = new DayOff( request_id, shifts,employee, urgent, status, reason, objection);
                pseudos.Add(req);
            }
            CloseConnection();
            return pseudos;
        }
        public bool ConfirmDayOffRequest(int requestId)
        {
            string[] parameters = new string[] { requestId.ToString() };
            string sql = "UPDATE `dayoff_requests` SET  `status`= 'confirmed', `emp_seen`= 0 " +
                "WHERE `request_id`= @requestId";

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public bool DenyDayOffRequest(int requestId, string objection) //1. reason, 2. status, 3. employee_id
        {
            String sql = "UPDATE `dayoff_requests` SET `objection`= @reason, `status`= 'denied', `emp_seen`= 0 " +
                "WHERE `request_id`= @requestId ; ";
            String[] parameters = new String[] { objection, requestId.ToString()};
            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }



        public List<SickReport> SelectSickReports(int seen)
        {
            string sql = "SELECT * FROM sick_reports WHERE hr_seen = @seen; ";
            MySqlDataReader result = executeReader(sql, new string[] { seen.ToString()});

            List<SickReport> pseudos = new List<SickReport>();
            while (result.Read())
            {
                int reportId = Convert.ToInt32(result[0]);
                int empId = Convert.ToInt32(result[3]);
                Employee employee = _employees.FirstOrDefault(emp => emp.Id == empId);
                string description = result[4].ToString();
                int first_dayId = Convert.ToInt32(result[1]);
                int last_dayId = Convert.ToInt32(result[2]);
                var shifts = GetShifts(first_dayId, last_dayId, empId);
                
                SickReport req = new SickReport(reportId,shifts, employee, description, Convert.ToBoolean(seen));
                pseudos.Add(req);
            }
            CloseConnection();
            return pseudos;
        }

       

        public bool ConfirmSickReport(int reportId)
        {
            string[] parameters = new string[] { reportId.ToString() };
            string sql = "UPDATE sick_reports SET hr_seen =  1 WHERE sick_report_id = @reportId";

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public bool UpdateAbsence(int dayId, int employeeId) // !
        {
            string[] parameters = new string[] { "None", "None", 1.ToString(), "DayOff", dayId.ToString(), employeeId.ToString() };
            string sql = "UPDATE employees_workdays SET first_shift = @shift1, second_shift = @shift2, absence = @absence, absence_reason = @absenceReason" +
                             " WHERE day_id = @dayId AND employee_id = @employeeId";

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public bool InsertAbsence(int dayId, int employeeId) // !
        {
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString(), "None", "None", 1.ToString(), "DayOff" };
            string sql = "INSERT INTO employees_workdays (day_id, employee_id, first_shift, second_shift, absence, absence_reason)" +
                    " VALUES(@dayId, @employeeId, @shift1, @shift2, @absence, @absenceReason);";

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public void UpdateDaysOffLeft(int employeeId, int daysOffLeft)
        {
            string[] parameters = new string[] {daysOffLeft.ToString(), employeeId.ToString()};
            string sql = "UPDATE employees SET DaysOffLeft = @daysOffLeft WHERE id = @empId";

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
            }
            CloseConnection();
        }

        public Day GetDay(int dayId)
        {
            foreach (Schedule s in _scheduleControl.Schedules)
            {
                foreach(Day d in s.Days)
                {
                    if(d.Id == dayId)
                    {
                        return d;
                    }
                }
            }
            return null;
        }


        private Dictionary<Day,EmployeeWorkday> GetShifts(int firstDay, int lastDay, int employeeId)
        {
            Dictionary<Day, EmployeeWorkday> shifts = new Dictionary<Day, EmployeeWorkday>();
            if (lastDay != 0)
            {
                for (int i = firstDay; i <= lastDay; i++)
                {
                    Day day = GetDay(i);
                    EmployeeWorkday wd = _scheduleControl.GetEmployeeShift(day.WeekId, day.Id, employeeId);
                    shifts.Add(day, wd);
                }
            }
            else
            {
                Day day = GetDay(firstDay);
                EmployeeWorkday wd = _scheduleControl.GetEmployeeShift(day.WeekId, day.Id, employeeId);
                shifts.Add(day, wd);
            }
            return shifts;
        }


    }
}
