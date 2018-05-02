using System;
using System.Collections.Generic;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAll();
        UserModel Get(Guid id);

    }
}
