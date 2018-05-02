using System;
using System.Collections.Generic;
using System.Linq;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;

namespace DE.Timesheets.Data
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Get(Guid id)
        {
            return _context.Users.Single(u => u.Id == id);
        }

    }
}
