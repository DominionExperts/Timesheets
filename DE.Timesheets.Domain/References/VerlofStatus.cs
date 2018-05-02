using System.Collections.Generic;
using System.Linq;

namespace DE.Timesheets.Domain.References
{
    public class VerlofStatus
    {
        public static readonly VerlofStatus InAanvraag = new VerlofStatus(1, "In aanvraag");
        public static readonly VerlofStatus Goedgekeurd = new VerlofStatus(2, "Goedgekeurd");
        public static readonly VerlofStatus Afgkeurd = new VerlofStatus(3, "Afgekeurd");
        public static readonly VerlofStatus Geannuleerd = new VerlofStatus(4, "Geannuleerd");

        public static readonly IEnumerable<VerlofStatus> List = new[]
        {
            InAanvraag,
            Goedgekeurd,
            Afgkeurd,
            Geannuleerd
        };

        public int Id { get; set; }
        public string Text { get; set; }

        private VerlofStatus(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public static VerlofStatus GetById(int id)
        {
            return List.First(v => v.Id == id);
        }

    }
}