namespace MIBA.Models
{
    public class NewsRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? PhotoUrl { get; set; }
        public IFormFile? Photo { get; set; }
        public string BriefDescription { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }


        public NewsRequest()
        {

        }

        public NewsRequest(News news)
        {
            Id = news.Id;
            Title = news.Title;
            BriefDescription = news.BriefDescription;
            Description = news.Description;
            PhotoUrl = news.Photo;
        }
    }
}
