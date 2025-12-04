using System;
using System.Collections.Generic;

namespace UserApp.DataLayer.Entities
{
    public class Publisher : BaseEntity
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
