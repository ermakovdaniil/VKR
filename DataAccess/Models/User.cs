using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public long TypeId { get; set; }

        public virtual UserType Type { get; set; } = null!;
    }
}
