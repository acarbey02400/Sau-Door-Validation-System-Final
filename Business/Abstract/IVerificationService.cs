using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVerificationService
    {
        public IResult Validate(string UId, int doorId);
        public IDataResult<List<string>> OfflineValidate(int doorId);
    }
}
