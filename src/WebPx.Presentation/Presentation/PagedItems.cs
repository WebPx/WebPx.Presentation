using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebPx.Presentation
{
    [Serializable]
    public class PagedItems<T>
    {
        public PagedItems(IEnumerable<T> tuples = null, int totalRowCount = 0)
        {
            this.Tuples = tuples;
            this.TotalRowCount = totalRowCount;
        }

        [XmlElement]
        public IEnumerable<T> Tuples { get; set; }

        [XmlAttribute]
        public int TotalRowCount { get; set; }
    }

    public static class PagedItems
    {
        public static PagedItems<T> Execute<T>(this IQueryable<T> query, int startRowIndex = 0, int maximumRows = 0)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));
            int count = query.Count();
            if (startRowIndex > 0)
                query = query.Skip(startRowIndex);
            if (maximumRows > 0)
                query = query.Take(maximumRows);
            return new PagedItems<T>(query.ToArray(), count);
        }
    }
}
