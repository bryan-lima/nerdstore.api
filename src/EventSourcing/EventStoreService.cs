using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;

namespace EventSourcing
{
    public class EventStoreService : IEventStoreService
    { 
        #region Private Fields

        private readonly IEventStoreConnection _connection;

        #endregion Private Fields

        #region Public Constructors

        public EventStoreService(IConfiguration configuration)
        {
            _connection = EventStoreConnection.Create(configuration.GetConnectionString("EventStoreConnection"));

            _connection.ConnectAsync();
        }

        #endregion Public Constructors

        #region Public Methods

        public IEventStoreConnection GetConnection()
        {
            return _connection;
        }

        #endregion Public Methods
    }
}
