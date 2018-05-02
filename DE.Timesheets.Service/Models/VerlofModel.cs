using System;
using System.Collections.Generic;

namespace DE.Timesheets.Service.Models
{
    public class VerlofModel
    {
        public Guid UserId { get; set; }
        public IEnumerable<VerlofHistoriekModel> Historiek { get; set; } = new VerlofHistoriekModel[0];
        public IEnumerable<VerlofTellerModel> Tellers { get; set; } = new VerlofTellerModel[0];
    }
}
