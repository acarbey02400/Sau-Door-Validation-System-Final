using Core.DataAccess.EntityFramework.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserValidationDoorDal : EfEntityRepositoryBase<UserValidationDoor, SauDbContext>, IUserValidationDoorDal
    {
        public List<UserValidationDoor> UserAuthDoor(string UId,int doorId)
        {
            using (SauDbContext context = new SauDbContext())
            {
                var result = from p in context.Users
                             where p.UId == UId
                             join ur in context.UserValidationDoor
                             on p.id equals ur.userId
                             where ur.doorId == doorId
                             select new UserValidationDoor { id=ur.id, name=ur.name, doorId=doorId, userId=p.id, startDate=ur.startDate, stopDate=ur.stopDate, status=ur.status };

                return result.ToList();
            }
        }
    }
}
