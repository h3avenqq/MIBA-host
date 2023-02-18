using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class RegistrationPhys
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Studies Studies { get; set; }
        public int StudiesId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime Birthday { get; set; } = DateTime.Today;
        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? About { get; set; }
    }
}
