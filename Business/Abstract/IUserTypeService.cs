using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserTypeService
    {
        public IResult add(UserType userType);
        public IResult update(UserType userType);
        public IResult delete(UserType userType);
        public IDataResult<List<UserType>> getAll();
        public IDataResult<UserType> getById(int id);
    }
}
