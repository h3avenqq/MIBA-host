using MIBA.Enums;
using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class CourseRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StudyFormat StudyFormat { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now;
        public int Cost { get; set; }
        public string DocumentAfter { get; set; }
        public string InfoToKnow { get; set; }
        public string InfoToCan { get; set; }
        public string InfoToUse { get; set; }
        public string CourseProgramm { get; set; }
        public int CategoryId { get; set; }
        public string Lectors { get; set; }

        public CourseRequest() { }

        public CourseRequest(Studies obj) {
            Id = obj.Id;
            Title = obj.Title;
            Description = obj.Description;
            StudyFormat = obj.StudyFormat;
            StartTime = obj.StartTime;
            EndTime = obj.EndTime;
            Cost = obj.Cost;
            DocumentAfter = obj.DocumentAfter;
            InfoToKnow = obj.InfoToKnow;
            InfoToCan = obj.InfoToCan;
            InfoToUse = obj.InfoToUse;
            CourseProgramm = obj.CourseProgramm;
            CategoryId = obj.Categories.Id;
            string row = "";
            foreach (Lectors item in obj.Lectors)
            {
                if (row != "")
                    row += " ";
                row += item.Id;
            }
            Lectors = row;

        }
    }
}
