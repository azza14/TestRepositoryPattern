using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestRepositoryPattern.Models;
using TestRepositoryPattern.Repositories;

namespace TestRepositoryPattern.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public HomeController()
        {
            _employeeRepository = new EmployeeRepository(new TestRepositoryPattenEntities());
        }
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ActionResult Index()
        {
            return View(_employeeRepository.GetEmployees());

        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.CreateEmplyoee(employee);
                _employeeRepository.Save();
                return RedirectToAction("Index");
            }
            return View();

        }

        public ActionResult Details(int id)
        {

            var res = _employeeRepository.GetEmployeeById(id);
            return View(res);

        }

        public ActionResult Edit(int id)
        {
            var emp = _employeeRepository.GetEmployeeById(id);
            return View(emp);

        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.UpdateEmployee(employee);
                _employeeRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var emp = _employeeRepository.GetEmployeeById(id);
            return View(emp);

        }
        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            _employeeRepository.Save();

            return RedirectToAction("Index", "Home");


        }
    }
}