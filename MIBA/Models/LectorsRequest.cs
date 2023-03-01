using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class LectorsRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string? About { get; set; }
        public string? PhotoUrl { get; set; }
        public IFormFile? Photo { get; set; }
        public virtual ICollection<Studies>? Studies { get; set; }
        public LectorsRequest()
        {
            Studies = new List<Studies>();
        }

        public LectorsRequest(Lectors lectors)
        {
            Id = lectors.Id;
            FullName = lectors.FullName;
            About = lectors.About;
            PhotoUrl = lectors.PhotoUrl;
            Studies = lectors.Studies;
        }
    }
}
