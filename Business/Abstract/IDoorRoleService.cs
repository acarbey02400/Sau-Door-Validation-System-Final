using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDoorRoleService
    { 
        public IResult add(DoorRole doorRole);
        public IResult update(DoorRole doorRole);
        public IResult delete(DoorRole doorRole);
        public IDataResult<List<DoorRole>> getAll();
        public IDataResult<DoorRole> getById(int id);
        public IDataResult<List<DoorRole>> getByDoorId(int doorId);
        public IResult Verification(string UId, int doorId);
    }
}
