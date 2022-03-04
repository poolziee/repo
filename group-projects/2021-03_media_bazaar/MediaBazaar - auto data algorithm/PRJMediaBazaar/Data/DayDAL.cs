using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Logic;


namespace PRJMediaBazaar.Data
{
    class DayDAL : BaseDAL
    {
        /// <summary>
        /// the three amounts should be separated by ' '
        /// </summary>
        /// <param name="jobPosition"></param>
        /// <param name="amount"></param>
        /// <param name="dayId"></param>
        /// <returns></returns>
        public bool UpdateNeededPosition(string jobPosition, string amounts, int dayId)
        {
            string sql = "";
            string[] parameters = new string[] { amounts, dayId.ToString() };
            switch (jobPosition)
            {
                case "Security":
                    sql = "UPDATE days SET security_needed = @amount WHERE id = @dayId";
                    break;
                case "Cashier":
                    sql = "UPDATE days SET cashiers_needed = @amount WHERE id = @dayId";
                    break;
                case "Stocker":
                    sql = "UPDATE days SET stockers_needed = @amount WHERE id = @dayId";

                    break;
                case "SalesAssistant":
                    sql = "UPDATE days SET sales_assistants_needed = @amount WHERE id = @dayId";

                    break;
                case "WarehouseManager":
                    sql = "UPDATE days SET warehouse_managers_needed = @amount WHERE id = @dayId";
                    break;

            }
           if( executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public bool UpdateAssignedPosition(string jobPosition, string amounts, int dayId)
        {
            string sql = "";
            string[] parameters = new string[] { amounts, dayId.ToString() };
            switch (jobPosition)
            {
                case "Security":
                    sql = "UPDATE days SET security_assigned = @amount WHERE id = @dayId";
                    break;
                case "Cashier":
                    sql = "UPDATE days SET cashiers_assigned = @amount WHERE id = @dayId";
                    break;
                case "Stocker":
                    sql = "UPDATE days SET stockers_assigned = @amount WHERE id = @dayId";

                    break;
                case "SalesAssistant":
                    sql = "UPDATE days SET sales_assistants_assigned = @amount WHERE id = @dayId";

                    break;
                case "WarehouseManager":
                    sql = "UPDATE days SET warehouse_managers_assigned = @amount WHERE id = @dayId";
                    break;

            }
            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }
    }

}

