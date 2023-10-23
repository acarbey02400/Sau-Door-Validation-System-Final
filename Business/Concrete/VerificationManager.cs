using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VerificationManager : IVerificationService
    {
        IUserValidationDoorService _userValidationDoorService;
        IDoorRoleService _doorRoleService;
        IUserService _userService;
        public VerificationManager(IUserValidationDoorService userValidationDoor, IDoorRoleService doorRoleDal, IUserService userService)
        {
            _userValidationDoorService = userValidationDoor;
            _doorRoleService = doorRoleDal;
            _userService = userService;
        }

        public IDataResult<List<string>> OfflineValidate(int doorId)
        {
            List<string> UIdList = new List<string>();
           
           var result= _doorRoleService.getByDoorId(doorId);
            var _result = _userService.getAll();
            foreach (var item in _result.Data)
            {
                if (result.Data.Where(p=>p.userTypeId==item.userTypeId)!=null)
                {
                  var result2=  Validate(item.UId, doorId);
                    if (result2.Success)
                    {
                        UIdList.Add(item.UId);
                    }
                }
            }
            return new SuccessDataResult<List<string>>(UIdList.ToList(),UIdList.Count().ToString());
        }

        public IResult Validate(string UId, int doorId)
        {
            DateTime dateTime = DateTime.Now;
            var result = _userValidationDoorService.UserAuthDoor(UId, doorId);

            if (result.Data.Any())
            {
                foreach (var item in result.Data)
                {
                    if ((item.doorId == doorId) && (item.startDate <= dateTime)
                        && (item.stopDate >= dateTime) && (item.status == true))
                    {
                        return new SuccessResult("doğrulandı(ekstra yetki)");
                    }
                    else if ((item.doorId == doorId) && (item.startDate <= dateTime)
                        && (item.stopDate >= dateTime) && (item.status == false))
                    {
                        return new ErrorResult("Doğrulanamadı(yetkisel hata)");
                    }
                }
            }

            var _result = _doorRoleService.Verification(UId, doorId);
            if (_result.Success)
            {
                return new SuccessResult("doğrulandı");
            }
            return new ErrorResult("doğrulanamadı");
        }

        
    }
}
