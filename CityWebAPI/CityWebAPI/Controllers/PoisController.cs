using System;
using System.Collections.Generic;
using BussinesLayer;
using CityWebAPI.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace CityWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoisController : ControllerBase
    {
        private readonly IPoiRepository _poiRepository;

        public PoisController(IPoiRepository poiRepository)
        {
            _poiRepository = poiRepository;
        }

        [HttpGet]
        [Route("cities/{cityID}/pois")]
        public ActionResult<IReadOnlyList<Poi>> Get()
        {
            return Ok(this._poiRepository.GetAllPois());
        }

        [HttpPost]
        public ActionResult<City> Post([FromBody] CreatePoiModel poi)
        {
            if (poi == null)
            {
                return BadRequest();
            }

            Poi newpoi = new Poi(new Guid(),poi.Name, poi.Description, poi.City);
            this._poiRepository.CreatePoi(newpoi);

            return CreatedAtRoute("GetPoiById", new { id = newpoi.Id }, newpoi);

        }

        [HttpGet("{id}", Name = "GetPoiById")]
        public ActionResult<City> Get(Guid id)
        {
            return Ok(this._poiRepository.GetPoiById(id));
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CreatePoiModel poi)
        {
            Poi existingPoi = _poiRepository.GetPoiById(id);
            Poi newPoi = new Poi(existingPoi.Id,poi.Name,poi.Description,poi.City);
            _poiRepository.UpdatePoi(newPoi);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _poiRepository.DeletePoi(id);
        }
    }
}