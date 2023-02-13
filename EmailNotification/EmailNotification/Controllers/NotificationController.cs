using EmailNotification.BLL.Interfaces;
using EmailNotification.DAL.Interfaces;
using EmailNotification.DTO;
using EmailNotification.ErrorHandling;
using EmailNotification.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailNotification.Controllers
{
    [Route("notification")]
    [ApiController] 
    public class NotificationController : Controller
    {
        private readonly INotificationBusiness _notificationBusiess;
        public NotificationController(INotificationBusiness notificationBusiess)
        {
            _notificationBusiess = notificationBusiess;
        }

        [HttpPost("email")]
        public async Task<IActionResult> SendEmail(EmailDto request)
        {
            ValidationErrors validationResult = _notificationBusiess.ValidateEmailFields(request);
            if (validationResult != ValidationErrors.NoError)
            {
                string errorMessage = ValidationErrorMessages.GetErrorMessage(validationResult);
                return BadRequest(errorMessage);
            }

            await _notificationBusiess.SendEmail(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetSentEmails()
        {
            var response = await _notificationBusiess.GetSentEmails();
            return Ok(response);
        }
    }
}
