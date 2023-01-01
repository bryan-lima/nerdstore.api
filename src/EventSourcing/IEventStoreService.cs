using EventStore.ClientAPI;

namespace EventSourcing
{
    public interface IEventStoreService
    {
        #region Public Methods

        IEventStoreConnection GetConnection();

        #endregion Public Methods
    }
}
