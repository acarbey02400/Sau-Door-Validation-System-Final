using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserType:IEntity
    {
        public int id { get; set; }
        public string? name { get; set; }

    }
}
