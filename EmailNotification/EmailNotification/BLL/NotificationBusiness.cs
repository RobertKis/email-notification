using AutoMapper;
using EmailNotification.BLL.Interfaces;
using EmailNotification.DAL.Interfaces;
using EmailNotification.DTO;
using EmailNotification.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace EmailNotification.BLL
{
    public class NotificationBusiness : INotificationBusiness
    {
        private readonly INotificationDataAccess _notificationDataAccess;
        private readonly IMapper _mapper;
        public NotificationBusiness(INotificationDataAccess notificationDataAccess, IMapper mapper)
        {
            _notificationDataAccess = notificationDataAccess;
            _mapper = mapper;
        }
    
        public async Task<bool> SendEmail(EmailDto request)
        {
            Email email = new Email
            {
                CC = string.Join(';', request.CC),
                From = request.From,
                To = request.To,
                Subject = request.Subject,
                Importance = (int)Enum.Parse<Importance>(request.Importance),
                Content = request.Content,
            };
            bool success = await _notificationDataAccess.SaveEmailData(email);
            return success;
        }

        public async Task<List<EmailDto>> GetSentEmails()
        {
            try
            {
                var emails = await _notificationDataAccess.GetSentEmails();
                return emails.Select(s => _mapper.Map<EmailDto>(s)).ToList();
            } catch (Exception ex)
            {
                return new List<EmailDto>();
            }
        }

        public ValidationErrors ValidateEmailFields(EmailDto request)
        {
            if (request == null)
                return ValidationErrors.NoData;

            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            foreach (string email in request.CC)
            {
                if (!Regex.IsMatch(email, regex, RegexOptions.IgnoreCase))
                    return ValidationErrors.InvalidCC;
            }

            if (string.IsNullOrEmpty(request.From))
                return ValidationErrors.NoFrom;

            if (string.IsNullOrEmpty(request.To))
                return ValidationErrors.NoTo;

            if (string.IsNullOrEmpty(request.Subject))
                return ValidationErrors.NoSubject;

            if (!Regex.IsMatch(request.From, regex, RegexOptions.IgnoreCase))
                return ValidationErrors.InvalidFrom;

            if (!Regex.IsMatch(request.To, regex, RegexOptions.IgnoreCase))
                return ValidationErrors.InvalidTo;

            return ValidationErrors.NoError;
        }
    }
}
