using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BussinesLayer
{
    public class CityRepository : ICityRepository
    {
        private readonly CityContext _context;

        public CityRepository(CityContext context)
        {
            _context = context;
        }

        public void CreateCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }

        public void DeleteCity(Guid id)
        {
            var city = _context.Cities.FirstOrDefault(p => p.Id == id);
            if (city != null)
            {
                _context.Remove(city);
                _context.SaveChanges();
            }
        }

        public IReadOnlyList<City> GetAllCities()
        {
            return _context.Cities.ToList();
        }

        public City GetCityById(Guid? id)
        {
            var city = _context.Cities.First(p => p.Id == id);
            return city;
        }

        public void UpdateCity(City city)
        {
            var existingCity = _context.Cities.First(p => p.Id == city.Id);
            existingCity.SetPropertyValue("Description", city.Description);
            existingCity.SetPropertyValue("Name", city.Name);
            existingCity.SetPropertyValue("Longitude", city.Longitude);
            existingCity.SetPropertyValue("Latitude", city.Latitude);

            _context.SaveChanges();
        }
       
    }
}
