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
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CitiesController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<City>> Get()
        {
            return Ok(this._cityRepository.GetAllCities());
        }

        // POST: api/City
        [HttpPost]
        public ActionResult<City> Post([FromBody] CreateCityModel city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            City newcity = new City(new Guid(), city.Name,city.Description,city.Latitude,city.Longitude);
            this._cityRepository.CreateCity(newcity);

            return CreatedAtRoute("GetById", new {id = newcity.Id}, newcity);

        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<City> Get(Guid id)
        {
            return Ok(this._cityRepository.GetCityById(id));
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] City city)
        {
            
            City existingCity = _cityRepository.GetCityById(id);
            City newCity = new City(existingCity.Id, city.Name, city.Description, city.Latitude,city.Longitude);
            _cityRepository.UpdateCity(newCity);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _cityRepository.DeleteCity(id);
        }
    }
}