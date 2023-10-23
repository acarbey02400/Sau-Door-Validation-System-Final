using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class DoorRoleManager : IDoorRoleService
    {
        IDoorRoleDal _doorRoleDal;

        public DoorRoleManager(IDoorRoleDal userClaimDal)
        {
            _doorRoleDal = userClaimDal;
        }
        [ValidationAspect(typeof(DoorRoleValidator))]
        public IResult add(DoorRole doorRole)
        {
            _doorRoleDal.Add(doorRole);
            return new SuccessResult();
        }

        public IResult delete(DoorRole doorRole)
        {
            _doorRoleDal.Delete(doorRole);
            return new SuccessResult();
        }

        public IDataResult<List<DoorRole>> getAll()
        {
            return new SuccessDataResult<List<DoorRole>>(_doorRoleDal.GetAll());
        }
        public IDataResult<DoorRole> getById(int id)
        {
            return new SuccessDataResult<DoorRole>(_doorRoleDal.Get(p => p.id == id));
        }

        public IResult update(DoorRole userClaim)
        {
            _doorRoleDal.Update(userClaim);
            return new SuccessResult();
        }

        public IResult Verification(string UId,int doorId)
        {
           var result= _doorRoleDal.AuthVerification(UId,doorId).Any();
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        public IDataResult<List<DoorRole>> getByDoorId(int doorId)
        {
            return new SuccessDataResult<List<DoorRole>>(_doorRoleDal.GetAll(p => p.doorId == doorId));
        }
    }
}
