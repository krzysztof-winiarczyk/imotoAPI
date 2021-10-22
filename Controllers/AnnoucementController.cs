using imotoAPI.Entities;
using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Controllers
{
    [Route("api/annoucement")]
    [Controller]
    public class AnnoucementController : ControllerBase
    {
        private readonly IAnnoucementService _service;

        public AnnoucementController(IAnnoucementService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnnoucementReturnDto>> Get()
        {
            var result = _service.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<AnnoucementReturnDto>> GetById([FromRoute] int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Annoucement> AddAnnoucement([FromBody] AnnoucementGetDto dto)
        {
            var annoucement = _service.AddAnnoucement(dto);
            return Ok(annoucement);
        }

        [HttpPut("{id}")]
        public ActionResult<Annoucement> EditAnnoucement([FromRoute] int id, [FromBody] AnnoucementGetDto dto)
        {
            var annoucement = _service.EditAnnoucement(id, dto);
            return Ok(annoucement);
        }

        [HttpPost("{id}/status")]
        public ActionResult<Annoucement_CarStatus> AddStatusToAnnoucement([FromRoute] int id, [FromBody] CarStatusIdDto dto) 
        {
            var annoucementCarStatusObject = _service.AddStatusToAnnoucement(id, dto);
            return Ok(annoucementCarStatusObject);
        }

        [HttpPost("{id}/equipment")]
        public ActionResult<Annoucement_CarStatus> AddEquipmentToAnnoucement([FromRoute] int id, [FromBody] CarEquipmentIdDto dto)
        {
            var annoucementCarEquipmentObject = _service.AddEquipmentToAnnoucement(id, dto);
            return Ok(annoucementCarEquipmentObject);
        }

    }
}
