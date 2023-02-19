using EntityFrameworkCore.Triggered;
using MIBA.Models;
using MIBA.Services.EmailService;

namespace MIBA.Services.DbTriggers
{
    public class FeedbackTrigger : IAfterSaveTrigger<Feedback>
    {
        private readonly IEmailService _email;

        public FeedbackTrigger(IEmailService email)
        {
            _email = email;
        }

        public Task AfterSave(ITriggerContext<Feedback> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType != ChangeType.Added)
                return Task.CompletedTask;

            var email = new Email();

            email.To = "disbugmsk@gmail.com";
            email.Subject = $"Отзыв от {context.Entity.Name} ({context.Entity.Email})";
            email.Body = "Отзыв: \n" + context.Entity.Description;

            _email.SendEmail(email);

            return Task.CompletedTask;
        }
    }
}
