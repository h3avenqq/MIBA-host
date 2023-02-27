using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class NewCourse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsChecked { get; set; }
    }
}
