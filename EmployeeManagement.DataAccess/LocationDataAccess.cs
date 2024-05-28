using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class LocationDataAccess:ILocationDataAccess
    {
        

        public List<LocationModel> GetAll()
        {
            
            List<LocationModel> locations = [];
            using (SqlConnection connection = new SqlConnection(Configuration.Configuration.Build()))
            {
                SqlCommand command = new SqlCommand("USP_GetLocation",connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    LocationModel location = new LocationModel
                    {
                        LocationId = Convert.ToInt32(sdr["LocationID"])
                ,
                        LocationName = Convert.ToString(sdr["LocationName"])!
                    };
                    
                    locations.Add(location);
                }
            }

             return locations;

        }

        public bool Set(LocationModel location)
        {
            using (SqlConnection connection =new SqlConnection(Configuration.Configuration.Build()))
            {
              

                SqlCommand command = new SqlCommand("USP_AddLocation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LocationID", location.LocationId);
                command.Parameters.AddWithValue("@LocationName", location.LocationName);

                connection.Open();
                command.ExecuteNonQuery();

            }

               
            return true;
        }
    }
}
