using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class Duty
    {
        public string Position { get; private set; }

        public int MorningNeeded { get; set; }
        public int MiddayNeeded { get;  set; }
        public int EveningNeeded { get; set; }

        public int MorningAssigned { get; set; }
        public int MiddayAssigned { get; set; }
        public int EveningAssigned { get; set; }

        public Duty(int morning, int midday, int evening, string position, int morning_assigned, int midday_assigned, int evening_assigned)
        {
            MorningNeeded = morning;
            MiddayNeeded = midday;
            EveningNeeded = evening;
            Position = position;

            MorningAssigned = morning_assigned;
            MiddayAssigned = midday_assigned;
            EveningAssigned = evening_assigned;
        }

        public int MaxValue()
        {
            if(MorningNeeded >= EveningNeeded && MorningNeeded >= MiddayNeeded)
            {
                return MorningNeeded;
            }

            else if (MiddayNeeded >= MorningNeeded && MiddayNeeded >= EveningNeeded)
            {
                return MiddayNeeded;
            }

            return EveningNeeded;
        }

        public int MaxAssigned()
        {
            if (MorningAssigned >= EveningAssigned && MorningAssigned >= MiddayAssigned)
            {
                return MorningAssigned;
            }

            else if (MiddayAssigned >= MorningAssigned && MiddayAssigned >= EveningAssigned)
            {
                return MiddayAssigned;
            }

            return EveningAssigned;
        }

        public int TotalLeft
        {  
        get
            {
                int totalNeeded = MorningNeeded + MiddayNeeded + EveningNeeded;
                int totalAssigned = MorningAssigned + MiddayAssigned + EveningAssigned;
                return totalNeeded - totalAssigned;
            }
        }

        public int TotalLeftForShift(string shift)
        {
            switch (shift)
            {
                case "Morning":
                    return MorningNeeded - MorningAssigned;
                case "Midday":
                    return MiddayNeeded - MiddayAssigned;
                case "Evening":
                    return EveningNeeded - EveningAssigned;
            }
            return -1;
        }

        public int TotalNeeded { get {return MorningNeeded + MiddayNeeded + EveningNeeded; } }

    } 
}
