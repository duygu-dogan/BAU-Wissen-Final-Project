﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVilla.Domain.Entities.Abstract
{
    public interface IMainEntity
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
