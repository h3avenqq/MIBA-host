namespace MIBA.Models
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }

        public Sponsor()
        {

        }

        public Sponsor(SponsorRequest request)
        {
            Id = request.Id;
            Name = request.Name;
            Url = request.Url;
        }
    }
}
