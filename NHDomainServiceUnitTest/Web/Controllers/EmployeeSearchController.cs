using System.Web.Mvc;
using DomainService;
using Web.Models;

namespace Web.Controllers
{
    public class EmployeeSearchController : Controller
    {
        private readonly EmployeeSearchService employeeSearchService;

        public EmployeeSearchController(EmployeeSearchService employeeSearchService)
        {
            this.employeeSearchService = employeeSearchService;
        }

        public ActionResult Index(EmployeeSearchCriteriaViewModel employeeSearchCriteriaViewModel)
        {
            var employees = employeeSearchService.Search(employeeSearchCriteriaViewModel.Name,
                employeeSearchCriteriaViewModel.RecordsPerPage,
                employeeSearchCriteriaViewModel.PageNumber,
                employeeSearchCriteriaViewModel.SortOn,
                employeeSearchCriteriaViewModel.SortOrder);
            var employeeSearchResultsViewModel = AutoMapper.Mapper.Map<EmployeeSearchResultsViewModel>(employees);
            return View(employeeSearchResultsViewModel);
        }
    }
}