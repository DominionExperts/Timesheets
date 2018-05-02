namespace DE.Timesheets.Service.Models
{
    public class VerlofTellerModel
    {
        public int TypeId { get; set; }
        public string TypeText { get; set; }
        public decimal Beschikbaar { get; set; }
        public decimal Genomen { get; set; }
        public decimal InAanvraag { get; set; }
        public decimal Totaal { get; set; }
    }
}