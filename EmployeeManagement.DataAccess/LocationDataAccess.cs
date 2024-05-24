using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class LocationDataAccess:ILocationDataAccess
    {
        public static string path = @"C:\Users\arpit.m\OneDrive - Technovert\Desktop\Tezo-tasks\classroom\Task-5\Locations.json";

        public List<LocationModel> GetAll()
        {
            var data = File.ReadAllText(path);

            List<LocationModel> locations = JsonConvert.DeserializeObject<List<LocationModel>>(data)!;
            if (locations != null) { 
            return locations;
            }

            return null!;

        }

        public bool Set(List<LocationModel> locationList)
        {
            var data = File.ReadAllText(path);
            string locations = JsonConvert.SerializeObject(locationList)!;
            File.WriteAllText(path, locations);
            return true;
        }
    }
}
