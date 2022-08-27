using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignIn
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Compleated { get; set; }
        public string ToDo { get; set; }
        public string Date { get; set; }
        public virtual Users Users { get; set; }
    }
}
