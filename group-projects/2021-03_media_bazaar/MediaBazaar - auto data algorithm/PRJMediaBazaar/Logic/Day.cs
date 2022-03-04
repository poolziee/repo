using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;

namespace PRJMediaBazaar.Logic
{
    class Day
    {
        private DayDAL dayDAL;
        public static string[] positions = new string[] { "Security", "Cashier", "Stocker","SalesAssistant","WarehouseManager"};
        public int Id { get; private set; }
        public int ScheduleId { get; private set; }
        public Duty Security { get; set; }
        public Duty Cashiers { get; set; }
        public Duty Stockers{ get; set; }
        public Duty SalesAssistants { get; set; }
        public Duty WarehouseManagers { get; set; }
        public DateTime Date { get; private set; }
        public int WeekId { get; private set; }

        public Duty[] AllPositions 
        {
            get
            {
                return new Duty[] { Security, Cashiers, Stockers, SalesAssistants, WarehouseManagers };
            }
        }


        public Day()
        {
            /* EMPTY DAY OBJECT CONSTRUCTOR */
        }

        public Day(int id, DateTime date,int scheduleId, string securityNeeded, string cashiersNeeded,
            string stockersNeeded, string salesAssistantsNeeded,
           string warehouseManagersNeeded, int weekId, string securityAssigned, string cashiersAssigned,
            string stockersAssigned, string salesAssistantsAssigned,
           string warehouseManagersAssigned)
        {
            string[] security = securityNeeded.Split(' ');
            string[] cashiers = cashiersNeeded.Split(' ');
            string[] stockers = stockersNeeded.Split(' ');
            string[] assistants = salesAssistantsNeeded.Split(' ');
            string[] managers = warehouseManagersNeeded.Split(' ');

            string[] security_assigned = securityAssigned.Split(' ');
            string[] cashiers_assigned = cashiersAssigned.Split(' ');
            string[] stockers_assigned = stockersAssigned.Split(' ');
            string[] assistants_assigned = salesAssistantsAssigned.Split(' ');
            string[] managers_assigned = warehouseManagersAssigned.Split(' ');

            Id = id;
            ScheduleId = scheduleId;
            Security = new Duty(Convert.ToInt32(security[0]), Convert.ToInt32(security[1]), Convert.ToInt32(security[2]), "Security", Convert.ToInt32(security_assigned[0]), Convert.ToInt32(security_assigned[1]), Convert.ToInt32(security_assigned[2]));
            Cashiers = new Duty(Convert.ToInt32(cashiers[0]), Convert.ToInt32(cashiers[1]), Convert.ToInt32(cashiers[2]), "Cashier", Convert.ToInt32(cashiers_assigned[0]), Convert.ToInt32(cashiers_assigned[1]), Convert.ToInt32(cashiers_assigned[2]));
            Stockers = new Duty(Convert.ToInt32(stockers[0]), Convert.ToInt32(stockers[1]), Convert.ToInt32(stockers[2]), "Stocker", Convert.ToInt32(stockers_assigned[0]), Convert.ToInt32(stockers_assigned[1]), Convert.ToInt32(stockers_assigned[2]));
            SalesAssistants = new Duty(Convert.ToInt32(assistants[0]), Convert.ToInt32(assistants[1]), Convert.ToInt32(assistants[2]), "SalesAssistant", Convert.ToInt32(assistants_assigned[0]), Convert.ToInt32(assistants_assigned[1]), Convert.ToInt32(assistants_assigned[2]));
            WarehouseManagers = new Duty(Convert.ToInt32(managers[0]), Convert.ToInt32(managers[1]), Convert.ToInt32(managers[2]), "WarehouseManager", Convert.ToInt32(managers_assigned[0]), Convert.ToInt32(managers_assigned[1]), Convert.ToInt32(managers_assigned[2]));
            Date = date;
            WeekId = weekId;
            dayDAL = new DayDAL();
            
        }

     

        public override string ToString()
        {
            return $"{Date.DayOfWeek} {Date.ToString("dd-MM-yyyy")}";
        }

        public Duty GetDuty(string jobPosition)
        {
            Duty duty = null;
            switch (jobPosition)
            {
                case "Security":
                    duty = Security;
                    break;
                case "Cashier":
                    duty = Cashiers;
                    break;
                case "Stocker":
                    duty = Stockers;
                    break;
                case "SalesAssistant":
                    duty = SalesAssistants;
                    break;
                case "WarehouseManager":
                    duty = WarehouseManagers;
                    break;

            }
            return duty;
        }

        public string GetNeededPositionInfo(string jobPosition)
        {
            Duty amount = GetDuty(jobPosition);
            return $"Needed {jobPosition}: {amount}";
        }

        public int TotalNeeded(string jobPosition, string shift)
        {
            return GetDuty(jobPosition).TotalLeftForShift(shift);
        }


      
        public bool ChangeNeededDuties(string jobPosition, int morning, int midday, int evening)
        {
          
            string amounts = $"{morning} {midday} {evening}";
            bool result = dayDAL.UpdateNeededPosition(jobPosition, amounts, Id);
           if(result)
            {
                Duty duty = GetDuty(jobPosition);
                duty.MorningNeeded = morning;
                duty.MiddayNeeded = midday;
                duty.EveningNeeded = evening;
                return true;
            }
            return false;
        }

        public bool ChangeAssignedDuties(string jobPosition, int morning, int midday, int evening)
        {
            string amounts = $"{morning} {midday} {evening}";
            bool result = dayDAL.UpdateAssignedPosition(jobPosition, amounts, Id);
           if(result)
            {
                Duty duty = GetDuty(jobPosition);
                duty.MorningAssigned = morning;
                duty.MiddayAssigned = midday;
                duty.EveningAssigned = evening;
                return true;
            }
            return false;
        }

        public Dictionary<string,int> DutyDifs
        {
            get
            {
                var tsukuyomi = new Dictionary<string, int>();

                foreach (Duty duty in AllPositions)
                {
                    tsukuyomi.Add(duty.Position, duty.TotalLeft);
                }
                return tsukuyomi;
            }
         
        }

        public string PositionStatus(string position)
        {
            int shikai = DutyDifs[position];
            int bankai = GetDuty(position).TotalNeeded;

            if (shikai == 0) return "complete";
            else if (shikai > 0 && shikai < bankai) return "started";
            return "empty";
        }





        //public void EmptyDuties()
        //{
        //   foreach(string jobPosition in positions)
        //    {
        //        Duty duty = GetDuty(jobPosition);
        //        duty.MorningAssigned =0;
        //        duty.MiddayAssigned = 0;
        //        duty.EveningAssigned = 0;
        //    }
        //}

    }
}
