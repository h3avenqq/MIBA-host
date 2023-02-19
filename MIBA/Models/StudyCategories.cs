using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class StudyCategories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Studies>? Studies { get; set; }
        public StudyCategories()
        {
            Studies = new List<Studies>();
        }
        public string Photo { get; set; }

        public StudyCategories(StudyCategoriesRequest request)
        {
            Name = request.Name;
        }
    }
}
