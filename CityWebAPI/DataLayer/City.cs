using System;
using System.Collections.Generic;
using System.Reflection;

namespace DataLayer
{
    public class City
    {
            public Guid Id { set; get; }

            public string Name { set; get; }

            public string Description { set; get; }

            public int Latitude { set; get; }

            public int Longitude { set; get; }

            public List<Poi> Pois { get; set; }

            private City()
            {

            }

            public City(Guid id, string name, string description, int latitude, int longitude)
            {
                this.Id = id;
                this.Name = name;
                this.Description = description;
                this.Latitude = latitude;
                this.Longitude = longitude;
            }

        public void SetPropertyValue(string propertyName, object val)
        {
            Type objType = this.GetType();
            PropertyInfo propertyInfo = GetFieldInfo(objType, propertyName);
            propertyInfo.SetValue(this, val);
        }

        private PropertyInfo GetFieldInfo(Type type, string propertyName)
        {
            PropertyInfo propertyInfo;
            // for searching fields in upper classes (in case of inheritance)
            do
            {
                propertyInfo = type.GetProperty(propertyName);
                type = type.BaseType;
            } while (propertyInfo == null && type != null);
            return propertyInfo;
        }
    }
}
