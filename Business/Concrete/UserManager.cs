using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        [ValidationAspect(typeof(UserValidator))]
        public IResult add(User user)
        {
            var result = BusinessRules.Run(CheckIfUIdUnique(user.UId));
            if (result!=null)
            {
                return result;
            }
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult delete(User user)
        {
           
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> getAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> getById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.id == id));
        }

        public IDataResult<List<User>> getByTypeId(int UserType)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(p => p.userTypeId == UserType));
        }

        public IDataResult<User> getByUId(string UId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p=>p.UId==UId));
        }

        public IResult update(User user)
        {
           
            _userDal.Update(user);
            return new SuccessResult();
        }

        private IResult CheckIfUIdUnique(string UId)
        {
            var result = _userDal.GetAll(p => p.UId == UId).Any();
            if (result)
            {
                return new ErrorResult("Bu kart zaten kayıtlı veya daha önce kullanılmış.");
            }
            return new SuccessResult();
        }
        
    }
}
