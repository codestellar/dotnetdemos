using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace codestellar.bolierplate.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : bolierplateControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}