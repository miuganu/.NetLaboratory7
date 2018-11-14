using System;
using DataLayer;
using System.Collections.Generic;

namespace BussinesLayer
{
    public interface ICityRepository
    { 
            void CreateCity(City city);
            void UpdateCity(City city);
            void DeleteCity(Guid Id);
            City GetCityById(Guid? Id);
            IReadOnlyList<City> GetAllCities();
    }
}

