using EntityFrameworkCore.Triggered;
using MIBA.Models;
using MIBA.Services.EmailService;

namespace MIBA.Services.DbTriggers
{
    public class RegistrationJudicTrigger : IAfterSaveTrigger<RegistrationJudic>
    {
        private readonly IEmailService _email;

        public RegistrationJudicTrigger(IEmailService email)
        {
            _email = email;
        }

        public Task AfterSave(ITriggerContext<RegistrationJudic> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType != ChangeType.Added)
                return Task.CompletedTask;

            var email = new Email();

            email.To = context.Entity.Email;
            email.Subject = "Заявка на регистрацию в Международную Академию Бизнеса РХТУ"; 
            email.Body = "Ваша заявка была успешно принята.";

            _email.SendEmail(email);

            return Task.CompletedTask;
        }
    }
}
