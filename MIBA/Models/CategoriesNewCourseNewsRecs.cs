namespace MIBA.Models
{
    public class CategoriesNewCourseNewsRecs
    {
        public IEnumerable<StudyCategories> Categories { get; set; }
        public IEnumerable<News> News { get; set; }
        public NewCourse NewCourse { get; set; }
        public IEnumerable<Documents> Documents { get; set; }
        public IEnumerable<CourseRecomendation> Recs { get; set; }
        public IEnumerable<Sponsor> Sponsors { get; set; }
        public IList<Mission> Missions { get; set; }
    }
}
