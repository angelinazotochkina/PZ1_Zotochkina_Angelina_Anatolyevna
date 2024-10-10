using System;
using System.Collections.Generic;

namespace PZ1_Zotochkina_Angelina_Anatolyevna.Models
{
    public partial class Users
    {
        public Users()
        {
            UsersFetails = new HashSet<UsersDetail>();
        }

        public long Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<UsersDetail> UsersFetails { get; set; }
    }
}
