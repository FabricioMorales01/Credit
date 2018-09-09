using Credit.Data.Infrastructure;
using System.Web.Mvc;

namespace Credit.Controllers
{
    public class BaseController : Controller
    {

        #region

        internal UnitOfWork UnitOfWork = new UnitOfWork();

        #endregion
        
    }
}