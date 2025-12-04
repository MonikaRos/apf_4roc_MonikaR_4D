using System;
using System.Collections.Generic;

namespace UserApp.DataLayer.Entities
{
    public class Role : BaseEntity
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
