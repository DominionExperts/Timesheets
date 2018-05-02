using System.Collections.Generic;
using System.Linq;

namespace DE.Timesheets.Domain.References
{
    public class VerlofType
    {
        public enum VerlofTypeId
        {
            Verlof = 1,
            VerlofVorigJaar = 2,
            Adv = 3,
            KleinVerlet = 4,
            Recup = 5,
            RecupFeestdagen = 6,
            Ziekte = 7
        }

        public static readonly VerlofType Verlof = new VerlofType((int)VerlofTypeId.Verlof, "Verlof");
        public static readonly VerlofType VerlofVorigJaar = new VerlofType((int)VerlofTypeId.VerlofVorigJaar, "Verlof vorig jaar");
        public static readonly VerlofType Adv = new VerlofType((int)VerlofTypeId.Adv, "ADV");
        public static readonly VerlofType KleinVerlet = new VerlofType((int)VerlofTypeId.KleinVerlet, "Klein verlet");
        public static readonly VerlofType Recup = new VerlofType((int)VerlofTypeId.Recup, "Recup");
        public static readonly VerlofType RecupFeestdagen = new VerlofType((int)VerlofTypeId.RecupFeestdagen, "Recup feestdagen");
        public static readonly VerlofType Ziekte = new VerlofType((int)VerlofTypeId.Ziekte, "Ziekte");

        public static readonly IEnumerable<VerlofType> List = new[]
        {
            Verlof,
            VerlofVorigJaar,
            Adv,
            KleinVerlet,
            Recup,
            RecupFeestdagen,
            Ziekte
        };


        public int Id { get; set; }
        public string Text { get; set; }

        private VerlofType(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public static VerlofType GetById(int id)
        {
            return List.First(v => v.Id == id);
        }
    }
}