using System.Collections;
using System.Collections.Generic;
using Domain;
using DomainService.Capabilities;

namespace DomainService
{
    public class EmployeeSearchService
    {
        private readonly IRepository<Employee> repository;

        public EmployeeSearchService(IRepository<Employee> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Employee> Search(string name)
        {
            return repository.FindAll(name);
        }

        public IEnumerable<Employee> Search(string name, int recordsPerPage, int pageNumber, string sortOn, string sortOrder)
        {
            return repository.FindAll(name, recordsPerPage, pageNumber, sortOn, sortOrder);
        }
    }
}