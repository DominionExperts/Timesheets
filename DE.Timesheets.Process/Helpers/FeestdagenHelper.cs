using System;
using System.Collections.Generic;

namespace DE.Timesheets.Process.Helpers
{
    public class Feestdag
    {
        public string Naam { get; }
        public DateTime Datum { get; }

        public bool InWeekend => Datum.DayOfWeek == DayOfWeek.Saturday || Datum.DayOfWeek == DayOfWeek.Sunday;        

        public Feestdag(string naam, DateTime datum)
        {
            Naam = naam;
            Datum = datum;
        }
    }

    public class FeestdagenHelper
    {
        private readonly int _jaar;

        public FeestdagenHelper(int jaar)
        {
            _jaar = jaar;
        }

        // Vaste dagen
        public DateTime Nieuwjaar => new DateTime(_jaar, 1, 1);
        public DateTime DagVdArbeid => new DateTime(_jaar, 5, 1);
        public DateTime NationaleFeestdag => new DateTime(_jaar, 7, 21);
        public DateTime OLVHemelvaart => new DateTime(_jaar, 8, 15);
        public DateTime Allerheiligen => new DateTime(_jaar, 11, 1);
        public DateTime Wapenstilstand => new DateTime(_jaar, 11, 11);
        public DateTime Kerstmis => new DateTime(_jaar, 12, 25);

        //Berekend
        public DateTime PaasMaandag => EasterSunday(_jaar).AddDays(1);
        public DateTime OLHHemelvaart => EasterSunday(_jaar).AddDays(39);
        public DateTime PinksterMaandag => Pinksteren.AddDays(1);


        public DateTime Pasen => EasterSunday(_jaar);
        public DateTime Pinksteren => OLHHemelvaart.AddDays(10);

        public IEnumerable<Feestdag> WettelijkeFeestdagen()
        {
            var helper = new FeestdagenHelper(_jaar);

            return new List<Feestdag>
            {
                new Feestdag("Nieuwjaar", helper.Nieuwjaar),
                new Feestdag("Paasmaandag", helper.PaasMaandag),
                new Feestdag("Dag van de Arbeid", helper.DagVdArbeid),
                new Feestdag("O.L.H. Hemelvaart", helper.OLHHemelvaart),
                new Feestdag("Pinkstermaandag", helper.PinksterMaandag),
                new Feestdag("Nationale feestdag", helper.NationaleFeestdag),
                new Feestdag("O.L.V. Hemelvaart", helper.OLVHemelvaart),
                new Feestdag("Allerheiligen", helper.Allerheiligen),
                new Feestdag("Wapenstilstand", helper.Wapenstilstand),
                new Feestdag("Kerstmis", helper.Kerstmis)
            };
        }

        private static DateTime EasterSunday(int year)
        {
            //g is the position within the 19 year lunar cycle; known as the golden number. 
            //c is the century. 
            //h is the number of days between the equinox and the next full moon. 
            //i is the number of days between the full moon after the equinox and the first sunday after that full moon

            var g = year % 19;
            var c = year / 100;
            var h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            var i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            var day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            var month = 3;

            if (day <= 31) return new DateTime(year, month, day);

            month++;
            day -= 31;

            return new DateTime(year, month, day);
        }
    }
}
