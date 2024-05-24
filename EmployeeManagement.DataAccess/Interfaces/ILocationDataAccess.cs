﻿using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Interfaces
{
    public interface ILocationDataAccess
    {
        public List<LocationModel> GetAll();
        public bool Set(List<LocationModel> locationList);
    }
}
