using System.ComponentModel.DataAnnotations;
using DataLayer;

namespace CityWebAPI.Models
{
    public class CreatePoiModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public City City { get; set; }
    }
}
