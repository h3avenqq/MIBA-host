namespace MIBA.Models
{
    public class CategoriesAndNews
    {
        public IEnumerable<StudyCategories> Categories { get; set; }
        public IEnumerable<News> News { get; set; }
    }
}
