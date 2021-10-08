using System.Collections.Generic;
using Domain;

namespace DomainService.Capabilities
{
    public interface IRepository<T> where T : EntityBase<T>
    {
        void Save(T entity);
        void Update(int id, Employee employee);
        T GetById(int id);
        IEnumerable<Employee> FindAll(string name);
        IEnumerable<Employee> FindAll(string name, int recordsPerPage, int pageNumber, string sortOn, string sortOrder);
    }
}