using System;
using System.Reflection;


namespace DataLayer
{
    public class Poi
    {
            public Poi()
            {
                //EF
            }

            public Poi(Guid Id,string Name, string Description,City City)
            {
                this.Id = Id;
                this.Name = Name;
                this.Description = Description;
                this.City = City;
            }

            public Guid Id { get; private set; }

            public string Name { get; private set; }

            public string Description { get; private set; }
            
            public City City { get; private set; }
               
        
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

