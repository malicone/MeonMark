using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeonMark.Models
{
    public class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public void SetCreateStamp()
        {
            CreatedAt = DateTime.Now;
        }
        public void SetUpdateStamp()
        {
            UpdatedAt = DateTime.Now;
        }
        public void SetDeleteStamp()
        {
            DeletedAt = DateTime.Now;
        }
    }
}
