namespace MIBA.Models
{
    public class DocumentsRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }
        public IFormFile? File { get; set; }


        public DocumentsRequest()
        {

        }

        public DocumentsRequest(Documents documents)
        {
            Id = documents.Id;
            Name = documents.Name;
            Url = documents.Url;
        }
    }

}
