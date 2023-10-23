using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class SauDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SauDb;Trusted_Connection=true");
        }

        public DbSet<User> ?Users { get; set; }
        public DbSet<UserType> ?UserTypes { get; set; }
        public DbSet<Door> ?Doors { get; set; }
        public DbSet<DoorRole> ?DoorRoles { get; set; }
        public DbSet<UserValidationDoor> ?UserValidationDoor { get; set; }

    }
}
