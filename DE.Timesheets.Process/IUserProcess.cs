using System;
using System.Collections.Generic;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;

namespace DE.Timesheets.Process
{
    public interface IUserProcess
    {
        IList<User> GetAll();
        User Get(Guid id);
    }
}
