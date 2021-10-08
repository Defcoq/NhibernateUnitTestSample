using System.Collections.Generic;
using System.Linq;
using Domain;
using DomainService.Capabilities;
using NHibernate;
using NHibernate.Linq;

namespace Persistence
{
    public class Repository<T> : IRepository<T>
            where T :EntityBase<T>
    {
        private readonly ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public void Save(T entity)
        {
            session.SaveOrUpdate(entity);
        }

        public IEnumerable<Employee> FindAll(string name)
        {
            return session.Query<Employee>()
                .Where(e => e.Firstname == name || e.Lastname == name)
                .ToList();
        }

        public IEnumerable<Employee> FindAll(string name, int recordsPerPage, int pageNumber, string sortOn, string sortOrder)
        {
            return session.Query<Employee>()
                .Where(e => e.Firstname == name || e.Lastname == name)
                .Skip(pageNumber*recordsPerPage)
                .Take(recordsPerPage)
                .ToList();
        }

        public void Update(int id, Employee employee)
        {
            employee.Id = id;
            session.Merge(employee);
        }

        public T GetById(int id)
        {
            return session.Load<T>(id);
        }
    }
}