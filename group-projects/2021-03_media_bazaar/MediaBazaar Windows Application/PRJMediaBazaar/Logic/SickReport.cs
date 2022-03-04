using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Data;

namespace PRJMediaBazaar.Logic
{
    class SickReport
    {


        public int ReportId { get; private set; }
        public Employee Employee { get; private set; }
        public String Description { get; private set; }
        public Dictionary<Day, EmployeeWorkday> Shifts { get; private set; }
        public bool Seen { get; private set; }

        public SickReport(int reportId, Dictionary<Day, EmployeeWorkday> shifts, Employee employee, String description, bool seen)
        {
            ReportId = reportId;
            Shifts = shifts;
            Employee = employee;
            Description = description;
            Seen = seen;
        }


        public void MarkAsSeen()
        {
            this.Seen = true;
        }

        public override string ToString()
        {
            string date = "";
            if (Shifts.Count == 1)
            {
                date = Shifts.Keys.First().Date.ToString("dd-MM-yyyy");
            }
            else
            {
                date = $"{Shifts.Keys.First().Date.ToString("dd-MM-yyyy")} - {Shifts.Keys.Last().Date.ToString("dd-MM-yyyy")} ";

            }


            string info = $"{Employee.FullName} --> Date/s: {date} | Description: {Description} | ";
           

            if (Shifts.Count == 1)
                {
                   
                    if (Shifts.Values.First() != null)
                    {
                        info += $" Dismissed shift at:{Shifts.Values.First().GetOccupation()}";
                    }
                }

                else
                {
                 
                    bool notNull = Shifts.Any(pair => pair.Value != null);

                    if (notNull)
                    {
                        string occupation = "Dismissed shifts at: ";
                        foreach (KeyValuePair<Day, EmployeeWorkday> kv in Shifts)
                        {
                            if (kv.Value != null)
                            {
                                if (Shifts.Values.Last() == kv.Value)
                                {
                                    occupation += $"{kv.Key.Date.ToString("dd-MM")}.";
                                }
                                else
                                {
                                    occupation += $"{kv.Key.Date.ToString("dd-MM")}, ";
                                }

                            }
                        }
                        info += occupation;
                    }

                }
           
            return info;
        }
    }
    
}