using System.ComponentModel.DataAnnotations;

namespace CityWebAPI.Models
{
    public class CreateCityModel
    {
        [Required]
        public string Name { set; get; }

        [Required]
        public string Description { set; get; }

        [Required]
        public int Latitude { set; get; }

        [Required]
        public int Longitude { set; get; }
    }
}
