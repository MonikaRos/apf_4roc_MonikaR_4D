using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace UserApp.DataLayer.Entities
{
    public class Language : BaseEntity
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}

