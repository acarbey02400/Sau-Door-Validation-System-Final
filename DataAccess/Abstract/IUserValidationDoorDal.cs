using Core.DataAccess.EntityFramework.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserValidationDoorDal:IEntityRepository<UserValidationDoor>
    {
        public List<UserValidationDoor> UserAuthDoor(string UId,int doorId);
    }
}
