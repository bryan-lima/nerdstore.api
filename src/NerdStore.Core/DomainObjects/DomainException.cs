namespace NerdStore.Core.DomainObjects
{
    public class DomainException : Exception
    {
        #region Public Constructors

        public DomainException()
        {

        }

        public DomainException(string message) : base(message)
        {

        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
            
        }

        #endregion Public Constructors
    }
}
