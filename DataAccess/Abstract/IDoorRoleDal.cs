﻿using Core.DataAccess.EntityFramework.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDoorRoleDal:IEntityRepository<DoorRole>
    {
        public List<DoorRole> AuthVerification(string UID, int doorId);
    }
}
