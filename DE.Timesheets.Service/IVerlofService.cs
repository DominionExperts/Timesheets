using System;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service
{
    public interface IVerlofService
    {
        VerlofModel Get(Guid userId, int jaar);
    }
}
