using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User:IEntity
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? UId { get; set; }
        public bool status { get; set; }
        public int userTypeId { get; set; }
        public DateTime? lastLogin { get; set; }
    }
}
