using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class RatingLevel
    {
        [Key]
        public int RatingLevelId { get; set; }

        [Required]
        public string RatingLevelDescription { get; set; }

    }
}