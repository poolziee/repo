using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Logic;

namespace PRJMediaBazaar.Data
{
      class EmployeeDAL : BaseDAL
    {
        public List<Employee> SelectAll()
        {
            MySqlDataReader dr = executeReader("SELECT * FROM `employees` WHERE `job_position` != 'HRManager';", null);
            List<Employee> employees = new List<Employee>();
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr[0]);
                String firstName = dr[1].ToString();
                String lastName = dr[2].ToString();
                DateTime birthDate = Convert.ToDateTime(dr[3]);
                String email = dr[4].ToString();
                String password = dr[5].ToString();
                String jobPosition = dr[6].ToString();
                int phoneNumber = Convert.ToInt32(dr[7]);
                String address = dr[8].ToString();
                double salary = Convert.ToDouble(dr[9]);
                String gender = dr[10].ToString();
                String education = dr[11].ToString();
                String contract = dr[12].ToString();
                int daysOff = Convert.ToInt32(dr[13]);
                int contractHours = Convert.ToInt32(dr[14]);
                String note = dr[15].ToString();
                int daysOffLeft = Convert.ToInt32(dr[16]);
                Employee temp = new Employee(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition, phoneNumber, address, education, contract, daysOff, contractHours, daysOffLeft);
                temp.Note = note;
                employees.Add(temp);
            }
            CloseConnection();
            return employees;
            
        }
        public bool AddEmployee(String firstName, String lastName,DateTime birthDate,String email,String password,String jobPosition,int phoneNumber,String address,int salary,String gender,String education,String contract,int daysOff,int contractHours, int daysOffLeft)
        {
            String format = "yyyy-MM-dd";
            String sql = "INSERT INTO `employees` (`id`,`first_name`,`last_name`,`birthDate`,`email`,`password`,`job_position`,`phoneNumber`,`address`,`salary`,`gender`,`education`,`Contract`,`DaysOff`,`ContractHours`, `DaysOffLeft`) "
                        + "VALUES(NULL,@firstName,@lastName,@birthDate,@email,@password,@jobPosition,@phoneNumber,@address,@salary,@gender,@education,@contract,@daysOff,@contractHours,@daysOffLeft);";
            String[] parameters = new String[] {firstName, lastName, birthDate.ToString(format), email, password, jobPosition, phoneNumber.ToString(), address, salary.ToString(), gender, education, contract, daysOff.ToString(), contractHours.ToString(), daysOffLeft.ToString() };
            if(executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
           
        }
        public int GetIDByEmail(String Email)
        {
            String sql = "SELECT id FROM employees WHERE email=@email;";
            String[] parameters = new String[] { Email };
            int id = Convert.ToInt32(executeScalar(sql, parameters));
            CloseConnection();
            return id;
        }
        public String LogInWithEmailAndPassword(String email,String password)
        {
            String sql = "SELECT job_position FROM employees WHERE email=@email AND password=@password;";
            String[] parameters = new string[] { email, password };
            if (executeScalar(sql, parameters) == null)
            {
                CloseConnection();
                return "lol";
            }
            else
            {
                CloseConnection();
                String job = executeScalar(sql, parameters).ToString();
                CloseConnection();
                return job;
            }
            
        }
        public bool AddNoteToEmployee(String email,String note)
        {
            String sql = "UPDATE `employees` SET `Notes`= @note WHERE `email`= @email;";
            String[] parameters = new String[] { email, note };
            if( executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }
        public Employee GetHRManagerByEmailAndPassword(String email, String password)
        {
            String[] parameters = new String[] { email, password };
            MySqlDataReader dr = executeReader("SELECT * FROM employees WHERE email=@email AND password=@password;",parameters);
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr[0]);
                String firstName = dr[1].ToString();
                String lastName = dr[2].ToString();
                DateTime birthDate = Convert.ToDateTime(dr[3]);
                String jobPosition = dr[6].ToString();
                int phoneNumber = Convert.ToInt32(dr[7]);
                String address = dr[8].ToString();
                double salary = Convert.ToDouble(dr[9]);
                String gender = dr[10].ToString();
                String education = dr[11].ToString();
                String contract = dr[12].ToString();
                int daysOff = Convert.ToInt32(dr[13]);
                int contractHours = Convert.ToInt32(dr[14]);
                String note = dr[15].ToString();
                int daysOffLeft = Convert.ToInt32(dr[16]);
                Employee temp = new Employee(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition, phoneNumber, address, education, contract, daysOff, contractHours, daysOffLeft);
                temp.Note = note;
                return temp;
            }
            return null;
        }
    }
}
