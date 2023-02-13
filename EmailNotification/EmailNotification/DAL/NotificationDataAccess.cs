using EmailNotification.DAL.Interfaces;
using EmailNotification.DTO;
using EmailNotification.Models;

namespace EmailNotification.DAL
{
    public class NotificationDataAccess : INotificationDataAccess
    {
        private readonly EmailDbContext _emailContext;

        public NotificationDataAccess(EmailDbContext emailContext)
        {
            _emailContext = emailContext;
        }

        public async Task<bool> SaveEmailData(Email request)
        {
            try
            {
                _emailContext.Add(request);
                await _emailContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Email>> GetSentEmails()
        {
            try
            {
                return _emailContext.Emails.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
