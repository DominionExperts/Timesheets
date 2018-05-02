using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service.Mappers
{
    public static class ModelToDomainMapper
    {
        public static User Map(UserModel user)
        {
            return new User
            {
                Id = user.Id,
                Naam = user.Naam,
                JaarlijksVerlof = user.JaarlijksVerlof
            };
        }

    }
}
