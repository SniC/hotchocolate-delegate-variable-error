using System;

namespace SourceOne
{
    public class Query
    {
        public Item Item()
        {
            return new Item() { id = Guid.Parse("6fc8ff09-695b-4666-abc9-5f6b2d25dc3f") };
        }
    }

    public class Item
    {
        public Guid id { get; set; }
    }
}
