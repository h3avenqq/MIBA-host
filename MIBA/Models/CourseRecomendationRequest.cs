using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class CourseRecomendationRequest
    {
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        public string? PhotoUrl { get; set; }
        public IFormFile? Photo { get; set; }
        public CourseRecomendationRequest()
        {

        }
        public CourseRecomendationRequest(CourseRecomendation recomend)
        {
            Id = recomend.Id;
            CourseId = recomend.Course.Id;
            PhotoUrl = recomend.Photo;
        }
    }
}
