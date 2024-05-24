using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Configuration
{
    public class Configuration
    {
        public static string  Build() {
            string ConString;
            try
            {
                var configuration = new ConfigurationBuilder()
             .SetBasePath(AppContext.BaseDirectory)
             .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
             .Build();
               ConString = configuration.GetConnectionString("DefaultConnectionString")!;
                return ConString;
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            return "";
        }
        }
}
