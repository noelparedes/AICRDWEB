using AICRDWEB.Models;
using System.Web.Mvc;

namespace AICRDWEB.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly AICRDWEBDbContext dbContext;

        public BaseController()
        {
            dbContext = new AICRDWEBDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}