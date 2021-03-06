﻿using System;
using DE.Timesheets.Service;
using DE.Timesheets.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace DE.Timesheets.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Timesheet")]
    public class TimesheetController : Controller
    {
        private readonly ITimesheetService _service;

        public TimesheetController(ITimesheetService service)
        {
            _service = service;
        }

        [HttpGet("{userId:Guid}/month/{maand:int}")]
        public TimesheetModel Get(Guid userId, int maand)
        {
            var jaar = DateTime.Now.Year;
            return _service.Get(userId, maand, jaar);
        }

        [HttpPut("")]
        public void Update([FromBody]SaveTimesheetDagModel dag)
        {
            var jaar = DateTime.Now.Year;
            _service.Update(dag);

        }        
    }
}