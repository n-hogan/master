using System.Web.Mvc;
using Hcs.Data.Entities;
using Hcs.Data.Repository;


namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRepository<Person> repo)
        {
            //repo.CreateOrUpdate(new Person(){Name = "Nick"});
        }

        public ActionResult Index()
        {
            


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}