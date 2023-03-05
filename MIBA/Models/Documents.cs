namespace MIBA.Models
{
    public class Documents
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Documents()
        {

        }

        public Documents(DocumentsRequest request)
        {
            Id = request.Id;
            Name = request.Name;
        }
    }
}
