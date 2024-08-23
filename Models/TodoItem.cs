using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeonMark.Models
{
    public class TodoItem : BaseEntity
    {        
        public string Title { get; set; } = string.Empty;
        public bool Completed { get; set; }
        public DateTime Due { get; set; }
    }
}
