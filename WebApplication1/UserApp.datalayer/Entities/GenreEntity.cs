using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace UserApp.DataLayer.Entities
{
    public class Genre : BaseEntity
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}

