using MIBA.Data;
using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class CourseRecomendation
    {
        [Key]
        public int Id { get; set; }
        public Studies? Course { get; set; }
        public string? Photo { get; set; }
    }
}
