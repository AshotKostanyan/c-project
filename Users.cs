using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignIn
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection<ToDoList> ToDoList { get; set; }
    }
}
