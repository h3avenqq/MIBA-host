using MIBA.Data;
using MIBA.Enums;
using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class Studies
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public StudyFormat StudyFormat { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public string DocumentAfter { get; set; }
        [Required]
        public string InfoToKnow { get; set; }
        [Required]
        public string InfoToCan { get; set; }
        [Required]
        public string InfoToUse { get; set; }
        [Required]
        public string CourseProgramm { get; set; }
        public virtual StudyCategories Categories { get; set; }
        public virtual ICollection<Lectors>? Lectors { get; set; }
        public Studies()
        {
            Lectors = new List<Lectors>();
        }

        public Studies(CourseRequest request, ApplicationDbContext db)
        {
            Title = request.Title;
            Description= request.Description;
            StudyFormat = request.StudyFormat;
            StartTime = request.StartTime;
            EndTime = request.EndTime;
            Cost = request.Cost;
            DocumentAfter = request.DocumentAfter;
            InfoToKnow= request.InfoToKnow;
            InfoToCan = request.InfoToCan;
            InfoToUse = request.InfoToUse;
            CourseProgramm = request.CourseProgramm;
            Categories = db.StudyCategories.Find(request.CategoryId);
            string[] allLectors = request.Lectors.Split(' ');
            IList<Lectors> lectors = new List<Lectors>();
            foreach(string lector in allLectors)
            {
                lectors.Add(db.Lectors.Find(Convert.ToInt32(lector)));
            }
            Lectors = lectors;
        }
    }
}
