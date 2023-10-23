using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserValidationDoor:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public int doorId { get; set; }
        public int userId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime stopDate { get; set; }
        public bool status { get; set; }

    }
}
