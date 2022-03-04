using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Data;

namespace PRJMediaBazaar.Logic
{
    class DayOff
    {
        public int RequestId { get; private set; }
        public Employee Employee { get; private set; }
        public bool Urgent { get; private set; }
        public String Status { get; private set; }
        public String Reason { get; set; }
        public String Objection { get; private set; }
        public Dictionary<Day,EmployeeWorkday> Shifts { get; private set; }

        public DayOff (int requestId, Dictionary<Day,EmployeeWorkday> shifts, Employee employee, bool urgent, String status, String reason, String objection)
        {
            RequestId = requestId;
            Shifts = shifts;
            Employee = employee;
            Urgent = urgent;
            Status = status;
            Reason = reason;
            Objection = objection;
        }



        public override string ToString()
        {
            string info = "";
            string urgent;
            if (Urgent == false)
            {
                urgent = "Not urgent";
            }
            else
            {
                urgent = "Urgent";
            }

            if (Status == "pending")
            {
                if (Reason != "")
                {
                    info += $"{Employee.FullName} --> {urgent} --> Reason:{Reason} | ";
                }
                else
                {
                    info += $"{Employee.FullName} --> {urgent} | ";
                }

                if (Shifts.Count == 1)
                {
                    info += Shifts.Keys.First().Date.ToString("dd-MM-yyyy");
                    if (Shifts.Values.First() != null)
                    {
                        info += $" Shift:{Shifts.Values.First().GetOccupation()}";
                    }
                }
                else
                {
                    info += $"{Shifts.Keys.First().Date.ToString("dd-MM-yyyy")} - {Shifts.Keys.Last().Date.ToString("dd-MM-yyyy")} ";

                    bool notNull = Shifts.Any(pair => pair.Value != null);

                    if (notNull)
                    {
                        string occupation = "Shifts at: ";
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
            }
            
            else if (Status == "denied")
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
                if (Reason != "")
                {
                    info = $"{Employee.FullName} --> Date/s--> {date} --> {urgent} --> Reason:{Reason} --> Objection: {Objection}";
                }
                else
                {
                    info = $"{Employee.FullName} --> Date/s--> {date} --> {urgent} --> Objection: {Objection}";
                }
                
            }

            else
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
                if (Reason != "")
                {
                    info = $"{Employee.FullName} --> Date/s--> {date} --> {urgent} --> Reason:{Reason}";
                }
                else
                {
                    info = $"{Employee.FullName} --> Date/s--> {date} --> {urgent}";
                }

               
            }


            return info;
        }
    }
}
