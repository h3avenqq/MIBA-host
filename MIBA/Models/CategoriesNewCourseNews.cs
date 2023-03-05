namespace MIBA.Models
{
    public class CategoriesNewCourseNews
    {
        public IEnumerable<StudyCategories> Categories { get; set; }
        public IEnumerable<News> News { get; set; }
        public NewCourse NewCourse { get; set; }
        public IEnumerable<Documents> Documents { get; set; }
    }
}
