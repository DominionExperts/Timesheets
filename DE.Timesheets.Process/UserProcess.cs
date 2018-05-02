using System;
using System.Collections.Generic;
using DE.Timesheets.Data;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;

namespace DE.Timesheets.Process
{
    internal sealed class UserProcess : IUserProcess
    {
        private readonly IUserRepository _repository;

        public UserProcess(IUserRepository repository)
        {
            _repository = repository;
        }

        public IList<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User Get(Guid id)
        {
            return _repository.Get(id);
        }
    }
}
