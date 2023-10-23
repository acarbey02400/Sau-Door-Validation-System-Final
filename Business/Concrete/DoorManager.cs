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
    public class DoorManager : IDoorService
    {
        IDoorDal _doorDal;
        public DoorManager(IDoorDal doorDal)
        {
            _doorDal = doorDal;
        }

        [ValidationAspect(typeof(DoorValidator))]
        public IResult add(Door door)
        {
             _doorDal.Add(door);
            return new SuccessResult();
        }

        public IResult delete(Door door)
        {
            _doorDal.Delete(door);
            return new SuccessResult();
        }

        public IDataResult<List<Door>> getAll()
        {
            return new SuccessDataResult<List<Door>>(_doorDal.GetAll());
        }

        public IDataResult<Door> getById(int id)
        {
            return new SuccessDataResult<Door>(_doorDal.Get(p=>p.id== id));
        }

        public IResult update(Door door)
        {
            _doorDal.Update(door);
            return new SuccessResult();
        }
    }
}
