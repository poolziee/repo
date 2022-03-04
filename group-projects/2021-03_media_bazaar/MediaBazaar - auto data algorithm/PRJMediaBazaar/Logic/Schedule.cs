using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class Schedule
    {
        private List<Day> _days;


        public Schedule(int scheduleId, DateTime startDate, DateTime endDate, bool isOutdated)
        {
            Id = scheduleId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void AddDays(List<Day> days)
        {
            _days = days;
        }

        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsOutdated { get; private set; }
        public Day[] Days { get { return _days.ToArray(); } }

        public Day GetDay(int dayId)
        {
            foreach(Day d in _days)
            {
                if (d.Id == dayId)
                    return d;
            }
            return null;
        }


        public override string ToString()
        {
            return $"{StartDate.ToString("dd-MM-yyyy")} - {EndDate.ToString("dd-MM-yyyy")}";
        }
    }
}
