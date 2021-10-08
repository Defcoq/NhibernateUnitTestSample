using System.Web;
using Persistence;

namespace Web
{
    public class DatabaseSessionModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        private void Context_EndRequest(object sender, System.EventArgs e)
        {
            var session = SessionManager.GetCurrentSession();
        }

        private void Context_BeginRequest(object sender, System.EventArgs e)
        {
            var session = SessionManager.GetCurrentSession();
            session.Close();
            session.Dispose();
        }

        public void Dispose()
        {
            
        }
    }
}