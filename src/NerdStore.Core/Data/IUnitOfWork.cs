namespace NerdStore.Core.Data
{
    public interface IUnitOfWork
    {
        #region Public Methods

        Task<bool> Commit();

        #endregion Public Methods
    }
}
