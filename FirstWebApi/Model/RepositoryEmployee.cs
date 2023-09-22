using FirstWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace FirstWebApi.Model
{
    public class RepositoryEmployee
    {
        private NorthwindContext _context;
        public RepositoryEmployee(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> AllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee FindEmpoyeeById(int id)
        {
            Employee employeeId = _context.Employees.Find(id);
            return employeeId;
        }
        public int AddEmployee(Employee employee)
        {
            Employee? foundEmp=_context.Employees.Find(employee.EmployeeId);
            if (foundEmp != null)
            {
                throw new Exception("Duplicate Id");
            }
            EntityState es=_context.Entry(employee).State;
            Console.WriteLine($"EntityState B4Add:{es.GetDisplayName()}");
            _context.Employees.Add( employee ); 
            es=_context.Entry(employee).State;
            Console.WriteLine($"EntityState After Add:{es.GetDisplayName()}");
            int result = _context.SaveChanges();
            es = _context.Entry(employee).State;
            Console.WriteLine($"EntityState After saveChanges:{es.GetDisplayName()}");
            return result;
        }
        public int UpdateEmployee(Employee updatedEmployee)
        {
            EntityState es = _context.Entry(updatedEmployee).State;
            Console.WriteLine($"EntityState B4update:{es.GetDisplayName()}");
            _context.Employees.Update(updatedEmployee);
            es = _context.Entry(updatedEmployee).State;
            Console.WriteLine($"EntityState After Update:{es.GetDisplayName()}");
            int result = _context.SaveChanges();
            es = _context.Entry(updatedEmployee).State;
            Console.WriteLine($"EntityState After saveChanges:{es.GetDisplayName()}");
            return result;

        }
        public int DeleteEmployee(int id)
        {
            Employee empToDelete = _context.Employees.Find(id);
            EntityState es = EntityState.Detached;
            int result = 0;
            if (empToDelete != null)
            {
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState B4Update:{es.GetDisplayName()} ");
                _context.Employees.Remove(empToDelete);
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState After update:{es.GetDisplayName()} ");
                result = _context.SaveChanges();
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState After savechange:{es.GetDisplayName()} ");
            }
            return result;

        }
    }
}

