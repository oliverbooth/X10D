namespace X10D.WinForms
{
    #region Using Directives

    using System.Windows.Forms;

    #endregion

    /// <summary>
    /// A set of extension methods for <see cref="ListView"/> and <see cref="ListViewItem"/>.
    /// </summary>
    public static class ListViewExtensions
    {
        /// <summary>
        /// Moves the <see cref="ListViewItem"/> to the top of the specified <see cref="ListView"/>.
        /// </summary>
        /// <param name="item">The <see cref="ListViewItem"/> to move.</param>
        /// <param name="listView">Optional. The parent <see cref="ListView"/>. Defaults to the current parent.</param>
        public static void MoveToTop(this ListViewItem item, ListView listView = null)
        {
            if (listView == null)
            {
                listView = item.ListView;
            }

            if (listView.Items.Contains(item))
            {
                int i = listView.Items.IndexOf(item);
                listView.Items.RemoveAt(i);
            }

            listView.Items.Insert(0, item);
        }
    }
}
