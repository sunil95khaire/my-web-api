using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class EmployeeModel
    {
        public static List<EmployeeModel> Employees = new List<EmployeeModel>
            {
                new EmployeeModel
                {
                    ID = 101,Name = "Seam",Email = "seam@gmail.com",Address = "Dhaka,Bangladesh"
                },
                new EmployeeModel
                {
                    ID = 102,Name = "Mitila",Email = "mitila@gmail.com",Address = "Dhaka,Bangladesh"
                },
                new EmployeeModel
                {
                    ID = 104,Name = "Popy",Email = "popy@yahoo.com",Address = "Dhaka,Bangladesh"
                }
            };
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }            

        public static List<EmployeeModel> GetEmployees()
        {
            return Employees;
        }
    }

    public class ResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public object Data { set; get; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}