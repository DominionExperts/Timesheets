using System;

namespace DE.Timesheets.Service.Models
{
    public class TimesheetDagModel
    {
        public Guid Id { get; set; }

        public DateTime Datum { get; set; }
        public decimal Uren { get; set; }
        public decimal Overuren { get; set; }
        public bool Wachtvergoeding { get; set; }
        public string Opmerkingen { get; set; }

        public bool IsFeestdag { get; set; }

        public bool IsWeekend => Datum.DayOfWeek == DayOfWeek.Saturday || Datum.DayOfWeek == DayOfWeek.Saturday;
    }
}
