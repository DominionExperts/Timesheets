using System;
using System.Collections.Generic;
using System.Globalization;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Process.Helpers;

namespace DE.Timesheets.Service.Models
{
    public class TimesheetModel
    {
        private readonly DateTimeFormatInfo _format;

        public decimal DagTijd => 7.6m; //TODO Move to settings

        public TimesheetModel(CultureInfo culture, int maand, int jaar)
        {
            _format = culture.DateTimeFormat;

            var daysInMonth = DateTime.DaysInMonth(jaar, maand);

            Dagen = new List<TimesheetDagModel>(daysInMonth);
            Maand = maand;
            Jaar = jaar;
        }

        public Guid UserId { get; set; }
        public int Maand { get; set; }
        public string MaandText => _format.GetMonthName(Maand);
        public int Jaar { get; set; }        

        public IList<TimesheetDagModel> Dagen { get; set; }

        public void AddDag(TimesheetDag existingdag, decimal verlof, bool isFeestdag)
        {
            var dag = new TimesheetDagModel(_format){
                Id = existingdag.Id,
                Datum = existingdag.Datum,
                Uren = existingdag.Uren,
                Overuren = existingdag.Overuren,
                Wachtvergoeding = existingdag.Wachtvergoeding,
                Opmerkingen = existingdag.Opmerkingen,               
                IsFeestdag = isFeestdag,
                Verlof = verlof
            };

            Dagen.Add(dag);
        }

        public void AddDag(DateTime datum, decimal verlof, bool isFeestdag)
        {
            var dag = new TimesheetDagModel(_format)
            {
                Id = Guid.NewGuid(),
                Datum = datum,
                IsFeestdag = isFeestdag,
                Verlof = verlof
            };

            Dagen.Add(dag);
        }

    }
}
