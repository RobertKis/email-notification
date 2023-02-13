using EmailNotification.DTO;
using EmailNotification.Models;

namespace EmailNotification.BLL.Interfaces
{
    public interface INotificationBusiness
    {
        Task<bool> SendEmail(EmailDto request);
        Task<List<EmailDto>> GetSentEmails();
        ValidationErrors ValidateEmailFields(EmailDto request);
    }
}