using System;

namespace DE.Timesheets.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public DateTime ModificationDate { get; set; }

        public string Naam { get; set; }
        public int JaarlijksVerlof { get; set; }
    }
}
