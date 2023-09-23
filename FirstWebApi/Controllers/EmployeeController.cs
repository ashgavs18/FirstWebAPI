using FirstWebApi.Model;
using FirstWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private RepositoryEmployee _repositoryEmployee;
        public EmployeeController(RepositoryEmployee repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/GetAllEmployees")]
        public IEnumerable<EmpViewModel> GetAllEmployees()
        {
            List<Employee> employees = _repositoryEmployee.AllEmployees();
            var empList = (
                from emp in employees
                select new EmpViewModel()
                {
                    EmpId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    BirthDate = emp.BirthDate,
                    HireDate = emp.HireDate,
                    Title = emp.Title,
                    City = emp.City,
                    ReportsTo = emp.ReportsTo
                }).ToList();
            return empList;
        }
        [HttpGet("/ListAllEmployees")]
        public List<Employee> ListAllEmployees()
        {
            List<Employee> employeesList = _repositoryEmployee.AllEmployees();
            return employeesList;
        }

        [HttpGet("/FindEmployee")]
        public Employee FindEmployee(int id)
        {
            Employee employeeById = _repositoryEmployee.FindEmpoyeeById(id);
            return employeeById;
        }
        //[HttpPost("/AddEmployee")]
        //public string AddEmployee(Employee newEmployee)
        //{
        //    int employeestatus = _repositoryEmployee.AddEmployee(newEmployee);
        //    if (employeestatus == 0)
        //    {
        //        return "Employee Not Added To Database Since it already exist";
        //    }
        //    else
        //    {
        //        return "Employee Added To Database";
        //    }
        //}
        [HttpPost("/AddNewEmployees")]
        public int AddEmployee(EmpViewModel newemp)
        {



            Employee employee = new Employee()
            {
                // EmpId = emp.EmployeeId, IT WONT work
                FirstName = newemp.FirstName,
                LastName = newemp.LastName,
                BirthDate = newemp.BirthDate,
                HireDate = newemp.HireDate,
                Title = newemp.Title,
                City = newemp.City,
                ReportsTo = newemp.ReportsTo > 0 ? newemp.ReportsTo : null,



            };
            _repositoryEmployee.AddEmployee(employee);
            return 1;
        }

        [HttpPut("/EditEmployee")]
        public int EditEmployee(int id, [FromBody] EmpViewModel emp)
        {
            Employee employee = new Employee();
            employee.EmployeeId = emp.EmpId;
            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;



            _repositoryEmployee.UpdateEmployee(employee);



            return 1;



        }

      
         [HttpGet("/DeleteEmployee")]
        public string DeleteEmployee(int id)
        {
            var employeestatus = _repositoryEmployee.DeleteEmployee(id);
            if (employeestatus == 0)
            {
                return "Employee does not exist in the Database";
            }
            else
            {
                return "Employee Successfully Deleted";
            }

        }
    }

}

