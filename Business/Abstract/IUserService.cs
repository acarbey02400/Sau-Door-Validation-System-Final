using Core.Entities.Concrete;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IResult add(User user);
        public IResult update(User user);
        public IResult delete(User user);
        public IDataResult<List<User>> getAll();
        public IDataResult<List<User>> getByTypeId(int UserType);
        public IDataResult<User> getById(int id);
        public IDataResult<User> getByUId(string UId);
    }
}
