using NerdStore.Core.DomainObjects;

namespace NerdStore.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        #region Public Methods

        IUnitOfWork UnitOfWork { get; }

        #endregion Public Methods
    }
}
