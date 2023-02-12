using MIBA.Models;

namespace MIBA.Services.EmailService
{
    public interface IEmailService
    {
        public void SendEmail(Email request);
    }
}
