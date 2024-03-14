
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using EmployeeManagementSystem.ViewModel;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult AddEmployee()
        {
            var viewModel = new AddEmployeeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(AddEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Employee newEmployee = new Employee
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Picture = viewModel.Picture,
                    PhoneNumber = viewModel.PhoneNumber,
                    Address = viewModel.Address,
                };
                _employeeRepository.AddEmployee(newEmployee);
            }
            return RedirectToAction("EmployeeList");
        }

        //retrive controller ma
        [HttpGet]
        public IActionResult EmployeeList()
        {

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel(_employeeRepository.AllEmployee);
            return View(employeeListViewModel);
        }

        //update ko lagi

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);

            var editEmployee = new UpdateEmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Email = employee.Email,
                Picture = employee.Picture,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
            };


            return View(editEmployee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmployee(UpdateEmployeeViewModel model)
        {
            var employee = _employeeRepository.GetEmployeeById(model.EmployeeId);

            employee.Name = model.Name;
            employee.Email = model.Email;
            employee.Picture = model.Picture;
            employee.PhoneNumber = model.PhoneNumber;
            employee.Address = model.Address;

            _employeeRepository.UpdateEmployee(employee);
            return RedirectToAction("EmployeeList");
        }

        public IActionResult DeleteEmployee(int id)
        {

            _employeeRepository.DeleteEmployee(id);

            return RedirectToAction("EmployeeList");


        }


    }
}