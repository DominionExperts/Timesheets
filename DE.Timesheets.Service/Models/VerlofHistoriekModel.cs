using System;

namespace DE.Timesheets.Service.Models
{
    public class VerlofHistoriekModel
    {
        public Guid Id { get; set; }
        public string TypeText { get; set; }
        public string Datum { get; set; }
        public string EenheidsText { get; set; }
        public decimal Eenheid { get; set; }
        public string StatusText { get; set; }
        public int Status { get; set; }
        public string Opmerkingen { get; set; }

    }
}
