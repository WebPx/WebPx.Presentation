using System;

namespace WebPx.Presentation
{
    static class RepositoryExtensions
    {
        public static void GetItemSelected<TEntity, TKey>(this IGetEntityKey<TEntity, TKey> keyed)
        {
            if (keyed.View is IGridView<TEntity, TKey> gridView)
                gridView.SelectedKey;
            else
                throw new NotSupportedException($"The Repository does not support a recognized Item Selection Pattern");
        }
    }
}
