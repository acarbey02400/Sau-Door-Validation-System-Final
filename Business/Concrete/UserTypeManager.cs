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
    public class UserTypeManager : IUserTypeService
    {
        IUserTypeDal _userTypeDal;
        public UserTypeManager(IUserTypeDal userTypeDal)
        {
            _userTypeDal = userTypeDal;
        }
        public IResult add(UserType userType)
        {
            _userTypeDal.Add(userType);
            return new SuccessResult();
        }

        public IResult delete(UserType userType)
        {
            _userTypeDal.Delete(userType);
            return new SuccessResult();
        }

        public IDataResult<List<UserType>> getAll()
        {
            return new SuccessDataResult<List<UserType>>(_userTypeDal.GetAll());
        }

        public IDataResult<UserType> getById(int id)
        {
            return new SuccessDataResult<UserType>(_userTypeDal.Get(p => p.id == id));
        }

        
        public IResult update(UserType userType)
        {
            _userTypeDal.Update(userType);
            return new SuccessResult();
        }
    }
}
