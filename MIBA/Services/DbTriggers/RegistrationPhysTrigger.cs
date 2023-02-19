using EntityFrameworkCore.Triggered;
using MIBA.Models;
using MIBA.Services.EmailService;

namespace MIBA.Services.DbTriggers
{
    public class RegistrationPhysTrigger : IAfterSaveTrigger<RegistrationPhys>
    {
        private readonly IEmailService _email;

        public RegistrationPhysTrigger(IEmailService email)
        {
            _email = email;
        }

        public Task AfterSave(ITriggerContext<RegistrationPhys> context, CancellationToken cancellationToken)
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
