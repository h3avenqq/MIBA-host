using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string BriefDescription { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public News()
        {

        }

        public News(NewsRequest request)
        {
            Title = request.Title;
            BriefDescription = request.BriefDescription;
            Description = request.Description;
        }
    }
}
