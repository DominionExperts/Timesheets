using DE.Timesheets.Domain.References;

namespace DE.Timesheets.Domain
{
    public class VerlofTeller
    {
        public VerlofType Type { get; set; }

        public decimal Beschikbaar { get; set; }
        public decimal Genomen { get; set; }
        public decimal InAanvraag { get; set; }

        public decimal Totaal => Beschikbaar + Genomen + InAanvraag;
    }
}