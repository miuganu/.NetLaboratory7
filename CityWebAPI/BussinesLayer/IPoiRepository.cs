using System;
using System.Collections.Generic;
using DataLayer;

namespace BussinesLayer
{
    public interface IPoiRepository
    {
        void CreatePoi(Poi poi);
        void UpdatePoi(Poi poi);
        void DeletePoi(Guid id);
        Poi GetPoiById(Guid? id);
        IEnumerable<Poi> GetAllPois();
    }
}
