using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


        public List<RoleModel> GetAll()
        {
            List<RoleModel> roles = new List<RoleModel>(); // Initialize the list

            using (SqlConnection connection = new SqlConnection(Configuration.Configuration.Build()))
            {
                SqlCommand cmd = new SqlCommand("select * from Roles", connection);

                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    // Create a new RoleModel object for each row
                    RoleModel role = new RoleModel
                    {
                        RoleName = Convert.ToString(sdr["RoleName"])!,
                        Department = Convert.ToString(sdr["Department"])!,
                        Description = Convert.ToString(sdr["Description"])!,
                        LocationId = Convert.ToInt32(sdr["LocationID"])
                    };

                    roles.Add(role); // Add the new RoleModel object to the list
                }
            }
            return roles;
        }


        public bool Set(RoleModel role)
        {
            using (SqlConnection connection =new SqlConnection(Configuration.Configuration.Build()))
            {
                SqlCommand cmd = new SqlCommand("insert into Roles values(@rolename,@department,@description,@locationid)", connection);

                cmd.Parameters.AddWithValue("@rolename", role.RoleName);
                cmd.Parameters.AddWithValue("@department",role.Department);
                cmd.Parameters.AddWithValue("@description", role.Description);
                cmd.Parameters.AddWithValue("@locationid", role.LocationId);

                connection.Open();
                cmd.ExecuteNonQuery();

            }
                return true;
        }

    }
}
