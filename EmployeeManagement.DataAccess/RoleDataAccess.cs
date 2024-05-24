using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Newtonsoft.Json;

namespace EmployeeManagement.DataAccess
{
    public class RoleDataAccess:IRoleDataAccess
    {
        public static string path = @"C:\Users\arpit.m\OneDrive - Technovert\Desktop\Tezo-tasks\classroom\Task-5\Roles.json";

        public List<RoleModel> GetAll()
        {
            var data = File.ReadAllText(path);
                
                List<RoleModel> roles = JsonConvert.DeserializeObject<List<RoleModel>>(data)!;
            if (roles != null) { 
                return roles;
            }

            return null!;


        }

        public bool Set(List<RoleModel> roleList)
        {
            var data = File.ReadAllText(path);
            string roles = JsonConvert.SerializeObject(roleList)!;
            File.WriteAllText(path, roles);
            return true;
        }

    }
}
