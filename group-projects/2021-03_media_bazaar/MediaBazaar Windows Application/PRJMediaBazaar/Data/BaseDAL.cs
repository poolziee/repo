using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;

namespace PRJMediaBazaar.Data
{
     abstract class BaseDAL
    {
        MySqlConnection con;

        protected MySqlCommand defaultDatabaseConnection(string sql, string[] parameters = null)
        {
            try
            {
                //@"server=127.0.0.1;database=dbi460221;user=root;password=;"
                //@"server=studmysql01.fhict.local;database=dbi460221;uid=dbi460221;password=lol;AllowUserVariables=true"
                con = new MySqlConnection(@"server=127.0.0.1;database=backup;user=root;password=;");
                MySqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                List<string> fields = new List<string>();
                MatchCollection mcol = Regex.Matches(sql, @"@\b\S+?\b");

                foreach (Match m in mcol)
                {
                    fields.Add(m.ToString());
                }

                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(fields[i], MySqlDbType.VarChar).Value = parameters[i];
                    }
                }
                return cmd;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return null;

        }


        protected MySqlDataReader executeReader(string sql, string[] parameters)
        {
            return defaultDatabaseConnection(sql, parameters).ExecuteReader();
        }

        protected  Object executeScalar(string sql, string[] parameters)
        {
            return defaultDatabaseConnection(sql, parameters).ExecuteScalar();
        }

        protected  Object executeNonQuery(string sql, string[] parameters)
        {
            return defaultDatabaseConnection(sql, parameters).ExecuteNonQuery();
        }

        public void CloseConnection()
        {
            if(con != null)
            {
                con.Close();
            }
          
        }

    }
}
