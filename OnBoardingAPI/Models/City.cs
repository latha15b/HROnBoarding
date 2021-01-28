using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }

        public int StateId { get; set; }

    }
}