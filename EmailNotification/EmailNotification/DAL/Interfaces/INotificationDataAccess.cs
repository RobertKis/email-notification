using EmailNotification.DTO;
using EmailNotification.Models;

namespace EmailNotification.DAL.Interfaces
{
    public interface INotificationDataAccess
    {
        Task<bool> SaveEmailData(Email request);

        Task<List<Email>> GetSentEmails();
    }
}