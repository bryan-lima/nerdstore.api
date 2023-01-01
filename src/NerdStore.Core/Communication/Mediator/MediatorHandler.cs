using MediatR;
using NerdStore.Core.Data.EventSourcing;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.DomainEvents;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        #region Private Fields

        private readonly IEventSourcingRepository _eventSourcingRepository;
        private readonly IMediator _mediator;

        #endregion Private Fields

        #region Public Constructors

        public MediatorHandler(IEventSourcingRepository eventSourcingRepository,
                               IMediator mediator)
        {
            _eventSourcingRepository = eventSourcingRepository;
            _mediator = mediator;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
            await _eventSourcingRepository.SalvarEvento(evento);
        }

        public async Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }

        public async Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent
        {
            await _mediator.Publish(notificacao);
        }

        #endregion Public Methods
    }
}
