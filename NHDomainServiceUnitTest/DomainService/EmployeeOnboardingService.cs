using Domain;
using DomainService.Capabilities;

namespace DomainService
{
    public class EmployeeOnboardingService
    {
        private readonly IRepository<Employee> employeeRepository;

        public EmployeeOnboardingService(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Execute(Employee employee)
        {
            employee.Onboard();
            employeeRepository.Save(employee);
        }
    }
}
