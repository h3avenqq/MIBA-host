namespace MIBA.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string PhotoUrl { get; set; }

        public Mission()
        {

        }

        public Mission(MissionRequest request)
        {
            Id = request.Id;
            Title = request.Title;
            SubTitle = request.SubTitle;
        }
    }
}
