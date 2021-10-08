using System.Web.Mvc;
using Persistence;

namespace Web
{
    public class RequiresDatabaseSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = SessionManager.GetCurrentSession();
            session.BeginTransaction();
        }

public override void OnActionExecuted(ActionExecutedContext filterContext)
{
    var session = SessionManager.GetCurrentSession();
    var transaction = session.Transaction;

    if (transaction.IsActive)
    {
        if (filterContext.Exception != null)
        {
            transaction.Rollback();
        }
        else
        {
            transaction.Commit();
        }
    }
    session.Close();
    session.Dispose();
}
    }
}