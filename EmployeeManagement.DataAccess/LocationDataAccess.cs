using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                SqlCommand command = new SqlCommand("Select * from Locations",connection);
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
              

                SqlCommand command = new SqlCommand("insert into Locations values(@id,@name)",connection);
                command.Parameters.AddWithValue("@id", location.LocationId);
                command.Parameters.AddWithValue("@name", location.LocationName);

                connection.Open();
                command.ExecuteNonQuery();

            }

               
            return true;
        }
    }
}
