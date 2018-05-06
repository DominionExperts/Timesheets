using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Domain.References;
using DE.Timesheets.Process.Helpers;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service.Builders
{
    internal sealed class TimesheetBuilder : ITimesheetBuilder
    {
        public TimesheetModel Build(int maand, int jaar, TimesheetDag[] timesheetDagen, VerlofHistoriek[] historiek, Feestdag[] feestdagen)
        {
            var model = new TimesheetModel(new CultureInfo("nl-BE"), maand, jaar);
            var verlof = historiek.Where(h => h.Status != VerlofStatus.Afgkeurd.Id && h.Status != VerlofStatus.Geannuleerd.Id).ToArray();

            foreach (var date in AllDatesInMonth(jaar, maand))
            {
                var existingdag = timesheetDagen.SingleOrDefault(d => d.Datum.Date == date);
                var histo = verlof.Where(h => h.Datum.Date == date).Sum();
                var feestdag = feestdagen.SingleOrDefault(f => f.Datum.Date == date);

                if (existingdag == null)
                {
                    model.AddDag(date, histo, feestdag != null);
                }
                else
                {
                    model.AddDag(existingdag, histo, feestdag != null);
                }
            }

            return model;
        }

        public static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
        {
            var days = DateTime.DaysInMonth(year, month);
            for (var day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }
    }
}
