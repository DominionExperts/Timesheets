using System;
using System.Collections.Generic;
using System.Linq;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Service.Mappers;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service.Builders
{
    internal sealed class VerlofBuilder : IVerlofBuilder
    {
        public VerlofModel Build(Guid userId, IEnumerable<VerlofHistoriek> historiek, IEnumerable<VerlofTeller> tellers)
        {
            var model = new VerlofModel
            {
                UserId = userId,
            };

            if (historiek != null)
            {
                model.Historiek = historiek
                    .OrderBy(h => h.Datum)
                    .Select(DomaintToModelMapper.Map).ToList();
            }

            if (tellers != null)
            {
                model.Tellers = tellers
                    .OrderBy(h => h.Type.Text)
                    .Select(DomaintToModelMapper.Map).ToList();
            }

            return model;
        }
    }
}