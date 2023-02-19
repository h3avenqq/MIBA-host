using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class StudyCategoriesRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhotoUrl { get; set; }
        public IFormFile? Photo { get; set; }


        public StudyCategoriesRequest()
        {

        }

        public StudyCategoriesRequest(StudyCategories obj)
        {
            Id = obj.Id;
            Name = obj.Name;
            PhotoUrl = obj.Photo;
        }
    }
}
