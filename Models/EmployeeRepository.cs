using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementDbContext _employeelManagementSystemDbContext;

        public EmployeeRepository(EmployeeManagementDbContext employeeManagementSystemDbContext)
        {

            _employeelManagementSystemDbContext = employeeManagementSystemDbContext;
        }
        public void AddEmployee(Employee employee)
        {

            _employeelManagementSystemDbContext.Employee.Add(employee);
            _employeelManagementSystemDbContext.SaveChanges();
        }
        //retrieve ko lagi
        public IEnumerable<Employee> AllEmployee
        {
            get
            {
                return _employeelManagementSystemDbContext.Employee;
            }
        }
        //yeha samma

        //edit ko lagi
        public Employee? GetEmployeeById(int employeeId)
        {

            return _employeelManagementSystemDbContext.Employee.FirstOrDefault(p => p.EmployeeId == employeeId);
        }

        public void UpdateEmployee(Employee employee)
        {

            var employeePart = _employeelManagementSystemDbContext.Employee.FirstOrDefault(p => p.EmployeeId == employee.EmployeeId);
            if (employeePart == null)
            {
                throw new ArgumentException("employee not found");
            }


            employeePart.Name = employee.Name;
            employeePart.Email = employee.Email;
            employeePart.Picture = employee.Picture;
            employeePart.PhoneNumber = employee.PhoneNumber;
            employeePart.Address = employee.Address;

            _employeelManagementSystemDbContext.Entry(employeePart).State = EntityState.Modified;
            _employeelManagementSystemDbContext.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {

            var employee = _employeelManagementSystemDbContext.Employee.Find(id);

            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }


            _employeelManagementSystemDbContext.Employee.Remove(employee);
            _employeelManagementSystemDbContext.SaveChanges();

        }
    }
}