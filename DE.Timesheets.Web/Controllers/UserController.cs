using System;
using System.Collections.Generic;
using DE.Timesheets.Service;
using DE.Timesheets.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace DE.Timesheets.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id:Guid}")]
        public UserModel Get(Guid id)
        {
            return _service.Get(id);
        }

    }
}