using System;
using System.Collections.Generic;
using System.Linq;
using DE.Timesheets.Process;
using DE.Timesheets.Service.Mappers;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service
{
    internal sealed class UserService : IUserService
    {
        private readonly IUserProcess _process;

        public UserService(IUserProcess process)
        {
            _process = process;
        }

        public IEnumerable<UserModel> GetAll()
        {
            var users = _process.GetAll();
            return users.Select(DomaintToModelMapper.Map);

        }

        public UserModel Get(Guid id)
        {
            var user = _process.Get(id);
            return DomaintToModelMapper.Map(user);
        }
    }
}
