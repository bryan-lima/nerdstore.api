using EventStore.ClientAPI;
using NerdStore.Core.Data.EventSourcing;
using NerdStore.Core.Messages;
using System.Text;
using System.Text.Json;

namespace EventSourcing
{
    public class EventSourcingRepository : IEventSourcingRepository
    {
        #region Private Fields

        private readonly IEventStoreService _eventStoreService;

        #endregion Private Fields

        #region Public Constructors

        public EventSourcingRepository(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task SalvarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            await _eventStoreService.GetConnection()
                                    .AppendToStreamAsync(stream: evento.AggregateId.ToString(),
                                                         expectedVersion: ExpectedVersion.Any,
                                                         events: FormatarEvento(evento));
        }

        public async Task<IEnumerable<StoredEvent>> ObterEventos(Guid aggregateId)
        {
            StreamEventsSlice _eventos = await _eventStoreService.GetConnection()
                                                                 .ReadStreamEventsForwardAsync(stream: aggregateId.ToString(),
                                                                                               start: 0,
                                                                                               count: 500,
                                                                                               resolveLinkTos: false);

            List<StoredEvent> _listaEventos = new();

            foreach (ResolvedEvent resolvedEvent in _eventos.Events)
            {
                string _dataEncoded = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
                BaseEvent _jsonData = JsonSerializer.Deserialize<BaseEvent>(_dataEncoded);

                StoredEvent _evento = new(id: resolvedEvent.Event.EventId,
                                          tipo: resolvedEvent.Event.EventType,
                                          dataOcorrencia: _jsonData.Timestamp,
                                          dados: _dataEncoded);

                _listaEventos.Add(_evento);
            }

            return _listaEventos.OrderBy(storedEvent => storedEvent.DataOcorrencia);
        }

        #endregion Public Methods

        #region Private Methods

        private static IEnumerable<EventData> FormatarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            yield return new EventData(eventId: Guid.NewGuid(),
                                       type: evento.MessageType,
                                       isJson: true,
                                       data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(evento)),
                                       metadata: null);
        }

        #endregion Private Methods
    }

    internal class BaseEvent
    {
        #region Public Properties

        public DateTime Timestamp { get; set; }

        #endregion Public Properties
    }
}
