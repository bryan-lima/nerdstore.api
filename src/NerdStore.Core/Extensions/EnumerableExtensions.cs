namespace NerdStore.Core.Extensions
{
    public static class EnumerableExtensions
    {
        #region Public Methods

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> itemAction)
        {
            foreach (T item in items)
                itemAction(item);
        }

        #endregion Public Methods
    }
}
