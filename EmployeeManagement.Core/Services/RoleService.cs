using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;

namespace EmployeeManagement.Core.Services
{
    public class RoleService : IRoleService
    {
        private IRoleDataAccess roleDataAccess;
        public RoleService(IRoleDataAccess _roleDataAccess) { 
            this.roleDataAccess = _roleDataAccess;
        }
        List<RoleModel>? roleList;
        public bool Add(RoleModel role)
        {
            roleList = roleDataAccess.GetAll();
            if (roleList == null)
            {
                roleList = new List<RoleModel>();
            }
            roleList.Add(role);
            return roleDataAccess.Set(roleList); ;
        }

        public List<RoleModel> ViewAll()
        {
            return roleDataAccess.GetAll();
        }
    }
}
