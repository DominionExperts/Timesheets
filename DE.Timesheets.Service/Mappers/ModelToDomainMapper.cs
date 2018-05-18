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

        public static TimesheetDag Map(SaveTimesheetDagModel dag)
        {
            return new TimesheetDag
            {
                Id = dag.Id,
                Datum = dag.Datum,
                UserId = dag.UserId,
                Uren = dag.Uren,
                Overuren = dag.Overuren,
                Wachtvergoeding = dag.Wachtvergoeding,
                Opmerkingen = dag.Opmerkingen
            };
        }
    }
}
