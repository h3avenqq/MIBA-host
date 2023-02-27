using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public int StudiesId { get; set; }
        public Studies? Studies { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
