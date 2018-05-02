using System;

namespace DE.Timesheets.Service.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Naam { get; set; }
        public int JaarlijksVerlof { get; set; }
    }
}
