using System;
using System.Collections.Generic;

namespace DE.Timesheets.Service.Models
{
    public class TimesheetModel
    {
        public Guid UserId { get; set; }

        public IEnumerable<TimesheetDagModel> Dagen { get; set; }
    }
}
