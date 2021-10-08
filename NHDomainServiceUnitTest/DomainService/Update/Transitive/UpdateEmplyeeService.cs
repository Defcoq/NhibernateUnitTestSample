using Domain;
using DomainService.Capabilities;

namespace DomainService.Update.Transitive
{
    public class UpdateEmplyeeService
    {
        private readonly IRepository<Employee> repository;

        public UpdateEmplyeeService(IRepository<Employee> repository)
        {
            this.repository = repository;
        }

        public void Execute(int employeeId, Address newAddress)
        {
            var employee = repository.GetById(employeeId);
            employee.ResidentialAddress = newAddress;
        }
    }
}