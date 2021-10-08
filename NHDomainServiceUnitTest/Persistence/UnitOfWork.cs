using System.Diagnostics;
using NHibernate;

namespace Persistence
{
    public class UnitOfWork
    {
        private readonly ITransaction transaction;

        public UnitOfWork(ISession session)
        {
            transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction.IsActive) transaction.Commit();
        }

        public void Rollback()
        {
            if (transaction.IsActive) transaction.Rollback();
        }
    }
}