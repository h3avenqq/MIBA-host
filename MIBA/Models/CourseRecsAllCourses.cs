namespace MIBA.Models
{
    public class CourseRecsAllCourses
    {
        public CourseRecomendationRequest Rec { get; set; }
        public IEnumerable<Studies> AllCourses { get; set; }
    }
}
