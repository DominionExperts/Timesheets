using System;

namespace DE.Timesheets.Domain.Entities
{
    public class VerlofHistoriek : IEntity
    {
        public Guid Id { get; set; }
        public DateTime ModificationDate { get; set; }

        public Guid UserId { get; set; }
        public int Type { get; set; }
        public DateTime Datum { get; set; }
        public int EenheidsType { get; set; }
        public int Status { get; set; }
        public string Opmerkingen { get; set; }
    }
}
