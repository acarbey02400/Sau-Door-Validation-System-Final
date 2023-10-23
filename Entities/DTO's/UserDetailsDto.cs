using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_s
{
    public class UserDetailsDto:IDto
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int userId { get; set; }
        public bool status { get; set; }
        public string? userType { get; set; }
        public string? UId { get; set; }
        public DateTime lastLogin { get; set; }

    }
}
