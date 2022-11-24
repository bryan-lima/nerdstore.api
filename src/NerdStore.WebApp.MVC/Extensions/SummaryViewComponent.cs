using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;

        public SummaryViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<DomainNotification> _notificacoes = await Task.FromResult(_notifications.ObterNotificacoes());
            _notificacoes.ForEach(domaiNotification => ViewData.ModelState.AddModelError(key: string.Empty,
                                                                                         errorMessage: domaiNotification.Value));

            return View();
        }
    }
}
