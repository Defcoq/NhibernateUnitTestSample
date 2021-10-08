using Domain;
using DomainService.Capabilities;

namespace DomainService.Update.Detached
{
    public class UpdateEmplyeeService
    {
        private readonly IRepository<Employee> repository;

        public UpdateEmplyeeService(IRepository<Employee> repository)
        {
            this.repository = repository;
        }

        public void Update(int id, Employee employee)
        {
            repository.Update(id, employee);
        }
    }
}