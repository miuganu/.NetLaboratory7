using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BussinesLayer
{
    public class PoiRepository : IPoiRepository
    {
        private readonly CityContext _context;

        public PoiRepository(CityContext context)
        {
            _context = context;
        }

        public void CreatePoi(Poi poi)
        {
            _context.Pois.Add(poi);
            _context.SaveChanges();
        }

        public void DeletePoi(Guid id)
        {
            var poi = _context.Pois.FirstOrDefault(p => p.Id == id);
            if (poi != null)
            {
                _context.Remove(poi);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Poi> GetAllPois()
        {
            return _context.Pois.ToList();
        }

        public Poi GetPoiById(Guid? id)
        {
            var poi = _context.Pois.First(p => p.Id == id);
            return poi;
        }

        public void UpdatePoi(Poi poi)
        {
            var existingPoi = _context.Pois.First(p => p.Id == poi.Id);
            existingPoi.SetPropertyValue("Description", poi.Description);
            existingPoi.SetPropertyValue("Name", poi.Name);
            existingPoi.SetPropertyValue("City", poi.City);
            _context.SaveChanges();
        }
    }
}
