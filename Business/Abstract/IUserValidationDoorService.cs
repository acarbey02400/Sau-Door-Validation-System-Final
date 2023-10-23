using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserValidationDoorService
    {
        public IResult add(UserValidationDoor userValidationDoor);
        public IResult update(UserValidationDoor userValidationDoor);
        public IResult delete(UserValidationDoor userValidationDoor);
        public IDataResult<List<UserValidationDoor>> getAll();
        public IDataResult<UserValidationDoor> getById(int id);
        public IDataResult<List<UserValidationDoor>> UserAuthDoor(string UId, int doorId);
    }
}
