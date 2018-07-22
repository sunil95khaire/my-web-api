using System.Linq;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {
        public EmployeeController()
        {
            EmployeeModel e = new EmployeeModel();
        }

        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            var employees = EmployeeModel.GetEmployees();
            return Ok(employees);
        }

        [HttpGet]
        public IHttpActionResult GetEmployeeDetails(int id)
        {
            var employee = EmployeeModel.GetEmployees().FirstOrDefault((p) => p.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IHttpActionResult AddEmployee([FromBody]EmployeeModel employee)
        {
            EmployeeModel.Employees.Add(new EmployeeModel
            {
                ID = employee.ID,
                Name = employee.Name,
                Email = employee.Email,
                Address = employee.Address
            });

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateEmployee([FromBody]EmployeeModel employee)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var existingItem = EmployeeModel.GetEmployees().FirstOrDefault(p => p.ID == employee.ID);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.ID = employee.ID;
            existingItem.Name = employee.Name;
            existingItem.Address = employee.Address;
            existingItem.Email = employee.Email;

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid item id");

            var item = EmployeeModel.GetEmployees().FirstOrDefault(p => p.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            EmployeeModel.GetEmployees().Remove(item);

            return Ok();
        }
    }
}
