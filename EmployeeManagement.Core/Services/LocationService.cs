using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Services
{
    public class LocationService:ILocationService
    {
        private ILocationDataAccess locationDataAccess;
        public LocationService(ILocationDataAccess _locationDataAccess) {
            this.locationDataAccess = _locationDataAccess;
        }
        List<LocationModel>? locationList;
        public bool Add(LocationModel location)
        {
            locationList = locationDataAccess.GetAll();
            if (locationList == null)
            {
                locationList = new List<LocationModel>();
            }
            locationList.Add(location);
            return locationDataAccess.Set(locationList); ;
        }

        public List<LocationModel> ViewAll()
        {
            return locationDataAccess.GetAll();
        }
    }
}
