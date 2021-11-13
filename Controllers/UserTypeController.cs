using imotoAPI.Entities;
using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Controllers
{
    [Route("api/userType")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _service;

        public UserTypeController(IUserTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<UserType>> GetAll()
        {
            var userTypes = _service.GetAll();
            return Ok(userTypes);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<UserType> GetAll([FromRoute] int id)
        {
            var userType = _service.GetById(id);
            return Ok(userType);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult<UserType> Post([FromBody] UserTypeDto dto)
        {
            var userType = _service.Add(dto);
            return Ok(userType);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<UserType> Update([FromRoute] int id, [FromBody] UserTypeDto dto)
        {
            var userType = _service.Edit(id, dto);
            return Ok(userType);
        }

    }
}
