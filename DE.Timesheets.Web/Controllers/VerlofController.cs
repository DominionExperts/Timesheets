using System;
using DE.Timesheets.Service;
using DE.Timesheets.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace DE.Timesheets.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/verlof")]
    public class VerlofController : Controller
    {
        private readonly IVerlofService _service;

        public VerlofController(IVerlofService service)
        {
            _service = service;
        }

        [HttpGet("{userId:guid}")]
        public VerlofModel Get(Guid userId)
        {
            var jaar = DateTime.Now.Year;
            return _service.Get(userId, jaar);
        }
    }
}