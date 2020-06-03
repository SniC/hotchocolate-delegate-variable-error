using System;

namespace SourceTwo
{
    public class Query
    {
        public string DataForItem(Filter filter)
        {
            // Get extra data for item

            if (filter.Id != null)
            {
                return "extra data";
            }
            return "failure";
        }
    }

    public class Filter
    {
        public Guid? Id { get; set; }
    }
}
