using HaidaiTech.Notificator.Interfaces;
using HaidaiTech.Notificator.NotificationContextMessages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBank.MyAccount.Application.Commands;

namespace MyBank.MyAccount.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly INotificationContext<NotificationContextMessage> _notificationContext;

        public AccountController(
            IMediator mediator,
            INotificationContext<NotificationContextMessage> notificationContext
        )
        {
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        [HttpPost("/create")]
        public async Task<JsonResult> Post(InsertCustomerCommand command)
        {
            var response = await _mediator.Send(command);

            if (_notificationContext.HasNotifications())
            {
                return new JsonResult(_notificationContext.GetNotifications())
                {
                    StatusCode = 400
                };
            }

            return new JsonResult(response)
            {
                StatusCode = 200
            };
        }
    }
}
