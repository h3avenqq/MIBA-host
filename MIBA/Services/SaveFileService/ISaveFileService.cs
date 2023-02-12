namespace MIBA.Services.SaveFileService
{
    public interface ISaveFileService
    {
        public Task<string> SaveFile(string environmentPath, string filePath, IFormFile file);
    }
}
