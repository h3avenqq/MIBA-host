using MIBA.Enums;
using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class RegistrationJudic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Studies Studies { get; set; }
        public int StudiesId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public int PeopleCount { get; set; }
        [Required]
        public StudyPlace StudyPlace { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? About { get; set; }
    }
}
