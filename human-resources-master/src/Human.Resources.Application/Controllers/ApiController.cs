using System;
using System.Collections.Generic;
using System.Linq;
using Human.Resources.Domain.Core.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Human.Resources.Application.Controllers
{
    public abstract class ApiController : Controller
    {
        private readonly DomainNotification _notifications;

        public ApiController(DomainNotification notifications)
        {
            _notifications = notifications;
        }

        protected IEnumerable<Notification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications);
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Message)
            });
        }
    }
}