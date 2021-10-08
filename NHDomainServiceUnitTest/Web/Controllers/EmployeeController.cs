using System.Web.Mvc;
using Domain;
using DomainService;
using Web.Models;

namespace Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeOnboardingService employeeOnboardingService;

        public EmployeeController(EmployeeOnboardingService employeeOnboardingService)
        {
            this.employeeOnboardingService = employeeOnboardingService;
        }

        public ActionResult Onboard(NewEmployeeViewModel newEmployeeViewModel)
        {
            var employee = AutoMapper.Mapper.Map<Employee>(newEmployeeViewModel);
            employeeOnboardingService.Execute(employee);
            return View();
        }
    }
}