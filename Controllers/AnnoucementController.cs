using imotoAPI.Entities;
using imotoAPI.Models;
using imotoAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public ActionResult<PageResult<AnnoucementReturnDto>> Get(
            [FromQuery] int? carClassId,
            [FromQuery] int? carBrandId,
            [FromQuery] int? carModelId,
            [FromQuery] int? carColorId,
            [FromQuery] int? carBodyworkId,
            [FromQuery] int? carCountryId,
            [FromQuery] int? yearStart,
            [FromQuery] int? yearEnd,
            [FromQuery] int? carFuelId,
            [FromQuery] int? carDriveId,
            [FromQuery] int? carTransmissionId,
            [FromQuery] int? voivodeshipId,
            [FromQuery] int? priceStart,
            [FromQuery] int? priceEnd,
            [FromQuery] int? mileageStart,
            [FromQuery] int? mileageEnd,
            [FromQuery] PaginationQuerry paginationQuerry,
            [FromQuery] SortQuerry sortQuerry
        )
        {
            var result = _service.Get(
                carClassId,
                carBrandId,
                carModelId,
                carColorId,
                carBodyworkId,
                carCountryId,
                yearStart,
                yearEnd,
                carFuelId,
                carDriveId,
                carTransmissionId,
                voivodeshipId,
                priceStart,
                priceEnd,
                mileageStart,
                mileageEnd,
                paginationQuerry,
                sortQuerry
                );
            return Ok(result);
        }

        [HttpGet("status/{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<AnnoucementReturnDto>> GetAnnoucementsWithStatus([FromRoute] int id)
        {
            var result = _service.GetAnnoucementsWithStatus(id);
            return Ok(result);
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<AnnoucementReturnDto>> GetById([FromRoute] int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [HttpGet("random")]
        [AllowAnonymous]
        public ActionResult GetRandom([FromQuery] CriteriaQuerry criteriaQuerry)
        {
            if (criteriaQuerry.IsValid())
            {
                var annoucements = _service.GetRandom(criteriaQuerry);
                return Ok(annoucements);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize(Roles = "użytkownik")]
        public ActionResult<Annoucement> AddAnnoucement([FromBody] AnnoucementGetDto dto)
        {
            var annoucement = _service.AddAnnoucement(dto);
            return Ok(annoucement);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "użytkownik")]
        public ActionResult<Annoucement> EditAnnoucement([FromRoute] int id, [FromBody] AnnoucementGetDto dto)
        {
            var annoucement = _service.EditAnnoucement(id, dto);
            return Ok(annoucement);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult DeleteAnnoucement([FromRoute] int id)
        {
            _service.DeleteAnnoucement(id);
            return Ok();
        }

        [HttpPost("{id}/status")]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult<Annoucement_CarStatus> AddStatusToAnnoucement([FromRoute] int id, [FromBody] CarStatusIdDto dto) 
        {
            var annoucementCarStatusObject = _service.AddCarStatusToAnnoucement(id, dto);
            return Ok(annoucementCarStatusObject);
        }

        [HttpDelete("{id}/status")]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult RemoveStatusFromAnnoucement([FromRoute] int id, [FromBody] CarStatusIdDto dto)
        {
            _service.DeleteCarStatusFromAnnoucement(id, dto);
            return Ok();
        }

        [HttpPost("{id}/equipment")]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult<Annoucement_CarStatus> AddEquipmentToAnnoucement([FromRoute] int id, [FromBody] CarEquipmentIdDto dto)
        {
            var annoucementCarEquipmentObject = _service.AddCarEquipmentToAnnoucement(id, dto);
            return Ok(annoucementCarEquipmentObject);
        }

        [HttpDelete("{id}/equipment")]
        [Authorize(Roles = "użytkownik, admin")]
        public ActionResult RemoveEquipmentFromAnnoucement([FromRoute] int id, [FromBody] CarEquipmentIdDto dto)
        {
            _service.DeleteCarEquipmentFromAnnoucement(id, dto);
            return Ok();
        }
    }
}
