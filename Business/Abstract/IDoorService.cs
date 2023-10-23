using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDoorService
    {
        public IResult add(Door door);
        public IResult update(Door door);
        public IResult delete(Door door);
        public IDataResult<List<Door>> getAll();
        public IDataResult<Door> getById(int id);
    }
}
