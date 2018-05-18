using System;

namespace DE.Timesheets.Service.Models
{
    public class SaveTimesheetDagModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public DateTime Datum { get; set; }
        public decimal Uren { get; set; }
        public decimal Overuren { get; set; }
        public bool Wachtvergoeding { get; set; }
        public string Opmerkingen { get; set; }
    }
}
