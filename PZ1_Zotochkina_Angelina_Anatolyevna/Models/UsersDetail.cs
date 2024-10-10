using System;
using System.Collections.Generic;

namespace PZ1_Zotochkina_Angelina_Anatolyevna.Models
{
    public partial class UsersDetail
    {
        public int Id { get; set; }
        public long Userid { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Patronymic { get; set; }

        public virtual Users User { get; set; } = null!;
    }
}
