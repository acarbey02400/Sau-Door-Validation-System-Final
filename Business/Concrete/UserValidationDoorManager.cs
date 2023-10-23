using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserValidationDoorManager : IUserValidationDoorService
    {
        IUserValidationDoorDal _userValidationDoorDal;
       
        public UserValidationDoorManager(IUserValidationDoorDal userValidationDoorDal)
        {
            _userValidationDoorDal = userValidationDoorDal;
          
        }
        public IResult add(UserValidationDoor userValidationDoor)
        {
            _userValidationDoorDal.Add(userValidationDoor);
            return new SuccessResult();
        }

        public IResult delete(UserValidationDoor userValidationDoor)
        {
            _userValidationDoorDal.Delete(userValidationDoor);
            return new SuccessResult();
        }

        public IDataResult<List<UserValidationDoor>> getAll()
        {
            return new SuccessDataResult<List<UserValidationDoor>>(_userValidationDoorDal.GetAll());
        }

        public IDataResult<UserValidationDoor> getById(int id)
        {
            return new SuccessDataResult<UserValidationDoor>(_userValidationDoorDal.Get(p => p.id == id));
        }

        public IResult update(UserValidationDoor userValidationDoor)
        {
            _userValidationDoorDal.Update(userValidationDoor);
            return new SuccessResult();
        }

        public IDataResult<List<UserValidationDoor>> UserAuthDoor(string UId, int doorId)
        {
            
            return new SuccessDataResult <List<UserValidationDoor>>(_userValidationDoorDal.UserAuthDoor(UId, doorId));
        }
    }
}
