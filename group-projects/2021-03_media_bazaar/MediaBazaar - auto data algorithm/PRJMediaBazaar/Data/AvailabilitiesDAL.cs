using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Logic;
using MySql.Data.MySqlClient;

namespace PRJMediaBazaar.Data
{
    class AvailabilitiesDAL : BaseDAL
    {
        private List<Employee> _employees;

        public AvailabilitiesDAL(List<Employee> employees)
        {
            _employees = employees;
        }


        /// <summary>
        /// takes all employees workdays, by the given job position
        /// </summary>
        /// <returns></returns>
        public List<EmployeeWorkday> SelectEmployeesWorkdays(int weekId, int dayId, string jobPosition)
        {


            MySqlDataReader dr = null;
            try
            {
                string[] parameters = new string[] { weekId.ToString(), dayId.ToString(), jobPosition };
                string sql = "SELECT ew.*, wh.hours FROM employees_workdays ew INNER JOIN employees e ON ew.employee_id =e.id " +
                    "LEFT JOIN worked_hours wh ON ew.employee_id = wh.employee_id AND wh.week_id = @weekId" +
                    " WHERE day_id = @dayId AND e.job_position =@jobPosition";
                List<EmployeeWorkday> workdays = new List<EmployeeWorkday>();
                dr = executeReader(sql, parameters);
                while (dr.Read()) //add EmployeeWorkday objects to the list
                {
                    int empId = Convert.ToInt32(dr[1]);
                    Employee employee = _employees.FirstOrDefault(emp => emp.Id == empId);

                    Shift firstShift = (Shift)Enum.Parse(typeof(Shift), dr[2].ToString());
                    Shift secondShift = (Shift)Enum.Parse(typeof(Shift), dr[3].ToString());
                    bool absence = Convert.ToBoolean(dr[4]);
                    AbsenceReason absenceReason = (AbsenceReason)Enum.Parse(typeof(AbsenceReason), dr[5].ToString());
                    double hours;
                    if (dr[6] == DBNull.Value) { hours = 0; }
                    else { hours = Convert.ToDouble(dr[6]); }

                    workdays.Add(new EmployeeWorkday(dayId, employee, firstShift, secondShift, absence, absenceReason, hours));
                }
                CloseConnection();
                return workdays;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();

                }
                CloseConnection();
            }
        }

        public double SelectWorkedHours(int weekId, int employeeId)
        {

            try
            {
                string[] parameters = new string[] { weekId.ToString(), employeeId.ToString() };
                string sql = "SELECT hours FROM worked_hours WHERE week_id = @weekId AND employee_id = @employeeId";
                double result = Convert.ToDouble(executeScalar(sql, parameters));
                return result;
            }
            finally
            {
                CloseConnection();
            }

        }

        public string GetPrefferedShift(int employeeId, DateTime date)
        {
            try
            {
                string table = "";
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        table = "monday";
                        break;

                    case DayOfWeek.Tuesday:
                        table = "tuesday";
                        break;

                    case DayOfWeek.Wednesday:
                        table = "wednesday";
                        break;

                    case DayOfWeek.Thursday:
                        table = "thursday";
                        break;

                    case DayOfWeek.Friday:
                        table = "friday";
                        break;

                    case DayOfWeek.Saturday:
                        table = "saturday";
                        break;

                    case DayOfWeek.Sunday:
                        table = "sunday";
                        break;
                }
                string sql = $"SELECT {table} FROM employees_preferences WHERE employee_id = @id";
                string[] parameters = new string[] { employeeId.ToString() };
                Object result = executeScalar(sql, parameters);
                if (result != null)
                {
                    return result.ToString();
                }
                return "";
            }
            finally
            {
                CloseConnection();
            }
           
        }
    }
}
