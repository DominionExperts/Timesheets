using System;
using System.Globalization;

namespace DE.Timesheets.Service.Models
{
    public class TimesheetDagModel
    {
        public Guid Id { get; set; }

        public DateTime Datum { get; set; }
        public string DagText => _format.GetShortestDayName(Datum.DayOfWeek);
        public int DagNr => Datum.Day;
        public int WeekNr => GetIso8601WeekOfYear(Datum);

        public decimal Uren { get; set; }
        public decimal Overuren { get; set; }
        public bool Wachtvergoeding { get; set; }
        public string Opmerkingen { get; set; }

        public bool IsFeestdag { get; set; }
        public decimal Verlof { get; set; }

        public bool IsWeekend => Datum.DayOfWeek == DayOfWeek.Saturday || Datum.DayOfWeek == DayOfWeek.Sunday;        

        private readonly DateTimeFormatInfo _format;

        public TimesheetDagModel(DateTimeFormatInfo dateTimeFormat)
        {
            _format = dateTimeFormat;
        }

        private static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            var day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
