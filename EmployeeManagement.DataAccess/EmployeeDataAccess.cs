using System.Data.SqlClient;
using System.Text;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
namespace EmployeeManagement.DataAccess
{
    public class EmployeeDataAccess:IEmployeeDataAccess
    {

       
        public  List<EmployeeModel> GetAll()
        {
            List<EmployeeModel> employees = [];
           

            using (SqlConnection connection = new SqlConnection(Configuration.Configuration.Build()))
                {
                    // Creating SqlCommand object   
                    SqlCommand cm = new SqlCommand("select * from Employee", connection);
                

                   
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    SqlDataReader sdr = cm.ExecuteReader();
                 
                    while (sdr.Read())
                    {
                    EmployeeModel employee = new EmployeeModel
                    {
                        EmpNo = Convert.ToString(sdr["EmpNo"])!
                   ,
                        FirstName = Convert.ToString(sdr["FirstName"])!
                   ,
                        LastName = Convert.ToString(sdr["LastName"])!
                   ,
                        DateOfBirth = Convert.ToString(sdr["DateOfBirth"])!
                   ,
                        Email = Convert.ToString(sdr["Email"])!
                   ,
                        MobileNumber = Convert.ToString(sdr["MobileNumber"])!
                   ,
                        JoiningDate = Convert.ToString(sdr["JoiningDate"])!
                   ,
                        LocationId = Convert.ToInt32(sdr["LocationID"])
                   ,
                        JobTitle = Convert.ToString(sdr["JobTitle"])!
                   ,
                        Department = Convert.ToString(sdr["Department"])!
                   ,
                        Manager = Convert.ToString(sdr["Manager"])!
                   ,
                        Project = Convert.ToString(sdr["Project"])!
                    }
               ;
                  
                        employees.Add(employee);
                    }
                    
               
                  return employees; 
            }



            
            
        }

        public EmployeeModel GetOne(string employeeNumber)
        {

            EmployeeModel employee = new EmployeeModel
            {
                EmpNo = ""
                    ,
                FirstName = ""
                    ,
                LastName = ""
                    ,
                DateOfBirth = ""
                    ,
                Email = ""
                    ,
                MobileNumber = ""
                    ,
                JoiningDate = ""
                    ,
                LocationId = -1
                    ,
                JobTitle = ""
                    ,
                Department = ""
                    ,
                Manager = ""
                    ,
                Project = ""
            }
                ;


            using (SqlConnection connection = new SqlConnection(Configuration.Configuration.Build()))
            {
                // Creating SqlCommand object   
                SqlCommand cm = new SqlCommand("select * from Employee where EmpNo=@Emp", connection);
                cm.Parameters.AddWithValue("@Emp", employeeNumber);
                

               
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    SqlDataReader sdr = cm.ExecuteReader();
               
                    while (sdr.Read())
                    {
                        employee.EmpNo = (string)sdr["EmpNo"];
                        employee.FirstName = (string)sdr["FirstName"];
                        employee.LastName = (string)sdr["LastName"];
                        employee.DateOfBirth = (string)sdr["DateOfBirth"];
                        employee.Email = (string)sdr["Email"];
                        employee.MobileNumber = (string)sdr["MobileNumber"];
                        employee.JoiningDate = (string)sdr["JoiningDate"];
                        employee.LocationId = (int)sdr["LocationID"];
                        employee.JobTitle = (string)sdr["JobTitle"];
                        employee.Department = (string)sdr["Department"];
                        employee.Manager = (string)sdr["Manager"];
                        employee.Project = (string)sdr["Project"];

                    }
                    

                    return employee;
                

            }
            
            
        }

        public bool Update(EmployeeModel updatedEmployee,string EmpNo)
        {

            using (SqlConnection connection = new SqlConnection(Configuration.Configuration.Build()))
            {
                

                SqlCommand cmd = new SqlCommand("UPDATE Employee SET FirstName = @FirstName, LastName = @LastName,DateOfBirth=@DateOfBirth,Email=@Email,MobileNumber=@MobileNumber,JoiningDate=@JoiningDate,LocationId=@LocationId,JobTitle=@JobTitle,Department = @Department, Manager=@Manager, Project=@Project WHERE EmpNo = @EmployeeID", connection);

                cmd.Parameters.AddWithValue("@EmployeeID", EmpNo);
                cmd.Parameters.AddWithValue("@FirstName", updatedEmployee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", updatedEmployee.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", updatedEmployee.DateOfBirth);
                cmd.Parameters.AddWithValue("@Email", updatedEmployee.Email);
                cmd.Parameters.AddWithValue("@MobileNumber", updatedEmployee.MobileNumber);
                cmd.Parameters.AddWithValue("@JoiningDate", updatedEmployee.JoiningDate);
                cmd.Parameters.AddWithValue("@LocationID", updatedEmployee.LocationId);
                cmd.Parameters.AddWithValue("@JobTitle", updatedEmployee.JobTitle);
                cmd.Parameters.AddWithValue("@Department", updatedEmployee.Department);
                cmd.Parameters.AddWithValue("@Manager", updatedEmployee.Manager);
                cmd.Parameters.AddWithValue("@Project", updatedEmployee.Project);
                connection.Open();

                int rowsAffected=cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public bool Delete(string employeeNumber)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.Configuration.Build()))
            {
                SqlCommand cm = new SqlCommand("delete from Employee where EmpNo=@Emp", connection);
            cm.Parameters.AddWithValue("@Emp", employeeNumber);
                
                connection.Open();
                cm.ExecuteNonQuery();

            }
            

            return true;
        }
        public bool Set(EmployeeModel employee)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.Configuration.Build()))
            {  
                
                // Opening Connection  
                connection.Open();
                // Executing the SQL query
                int i = 0;
                
                    SqlCommand cm = new SqlCommand("insert into Employee values(@Emp,@FirstName,@LastName,@Dob,@Email,@Mobile,@JoiningDate,@LocationId,@JobTitle,@Department,@Manager,@Project) ", connection);
                    cm.Parameters.AddWithValue("@Emp", employee.EmpNo);
                    cm.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cm.Parameters.AddWithValue("@LastName", employee.LastName);
                    cm.Parameters.AddWithValue("@Dob", employee.DateOfBirth);
                    cm.Parameters.AddWithValue("@Email", employee.Email);
                    cm.Parameters.AddWithValue("@Mobile", employee.MobileNumber);
                    cm.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                    cm.Parameters.AddWithValue("@LocationId", employee.LocationId);
                    cm.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
                    cm.Parameters.AddWithValue("@Department", employee.Department);
                    cm.Parameters.AddWithValue("@Manager", employee.Manager);
                    cm.Parameters.AddWithValue("@Project", employee.Project);
                    cm.ExecuteNonQuery();
                    i++;
                
               

            }

            return true;
        }
    }
}
