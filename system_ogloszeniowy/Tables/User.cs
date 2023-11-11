using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy.Tables;

namespace system_ogloszeniowy.classes
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int User_id { get; set; }
        [ForeignKey(nameof(User_role))]
        public int Role_id { get; set; }
        [MaxLength(35)]
        public string Email { get; set; }
        [MaxLength(25)]
        public string Password { get; set; }
    }
}
