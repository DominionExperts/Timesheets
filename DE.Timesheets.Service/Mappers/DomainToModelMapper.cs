using System.Globalization;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Domain.References;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service.Mappers
{
    public static class DomaintToModelMapper
    {
        public static UserModel Map(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Naam = user.Naam,
                JaarlijksVerlof = user.JaarlijksVerlof
            };
        }

        public static VerlofHistoriekModel Map(VerlofHistoriek historiek)
        {
            var type = VerlofType.GetById(historiek.Type);
            var eenheid = EenheidsType.GetById(historiek.EenheidsType);
            var status = VerlofStatus.GetById(historiek.Status);

            return new VerlofHistoriekModel
            {
                Id = historiek.Id,
                TypeText = type.Text,
                Datum = historiek.Datum.ToString("dd/MM/yyyy", CultureInfo.CurrentUICulture),
                EenheidsText = eenheid == EenheidsType.Dag ? $"{eenheid.Eenheid}" : $"{eenheid.Eenheid} - {eenheid.ShortText}",
                Eenheid = eenheid.Eenheid,
                StatusText = status.Text,
                Status = status.Id,
                Opmerkingen = historiek.Opmerkingen
            };
        }

        public static VerlofTellerModel Map(VerlofTeller teller)
        {
            return new VerlofTellerModel
            {
                TypeId = teller.Type.Id,
                TypeText = teller.Type.Text,
                Beschikbaar = teller.Beschikbaar,
                Genomen = teller.Genomen,
                InAanvraag = teller.InAanvraag,
                Totaal = teller.Totaal
            };
        }
    }
}