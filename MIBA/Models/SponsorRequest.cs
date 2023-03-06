namespace MIBA.Models
{
    public class SponsorRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }
        public IFormFile? Photo { get; set; }


        public SponsorRequest()
        {

        }

        public SponsorRequest(Sponsor sponsor)
        {
            Id = sponsor.Id;
            Name = sponsor.Name;
            Url = sponsor.Url;
        }
    }
}
