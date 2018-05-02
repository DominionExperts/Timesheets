using System.Collections.Generic;
using System.Linq;

namespace DE.Timesheets.Domain.References
{
    public class EenheidsType
    {
        public static readonly EenheidsType Voormiddag = new EenheidsType(1, "Voormiddag", "VM", 0.5m);
        public static readonly EenheidsType Namiddag = new EenheidsType(2, "Namiddag", "VM", 0.5m);
        public static readonly EenheidsType Dag = new EenheidsType(3, "Dag", "D", 1);

        public static readonly IEnumerable<EenheidsType> List = new []
        {
            Voormiddag,
            Namiddag,
            Dag
        };

        public int Id { get; set; }
        public string Text { get; set; }
        public string ShortText { get; set; }
        public decimal Eenheid { get; set; }

        private EenheidsType(int id, string text, string shortText, decimal eenheid)
        {
            Id = id;
            Text = text;
            ShortText = shortText;
            Eenheid = eenheid;
        }

        public static EenheidsType GetById(int id)
        {
            return List.First(e => e.Id == id);
        }
    }
}