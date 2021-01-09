using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Human.Resources.Domain.Core.Notification
{
    public class DomainNotification
    {
        private readonly List<Notification> _notifications;
        public bool HasNotifications => _notifications.Any();

		public DomainNotification()
		{
			_notifications = new List<Notification>();
		}

		public virtual List<Notification> GetNotifications()
		{
			return _notifications;
		}

		public void AddNotification(string key, string message)
		{
			_notifications.Add(new Notification(key, message));
		}

		public void AddNotifications(IReadOnlyCollection<Notification> notifications)
		{
			_notifications.AddRange(notifications);
		}

		public void AddNotifications(ICollection<Notification> notifications)
		{
			_notifications.AddRange(notifications);
		}

		public void AddNotifications(ValidationResult validationResult)
		{
			foreach (var error in validationResult.Errors)
			{
				AddNotification(error.ErrorCode, error.ErrorMessage);
			}
		}
	}
}
