namespace MIBA.Models
{
    public class CourseAndLectors
    {
        public CourseRequest Studies { get; set; }
        public IEnumerable<Lectors> Lectors { get; set; }
    }
}
