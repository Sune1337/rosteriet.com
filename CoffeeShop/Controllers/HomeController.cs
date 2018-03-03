namespace CoffeeShop.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        #region Public Methods and Operators

        public ActionResult Index()
        {
            ViewBag.SusnetCounterID = Properties.Settings.Default.SusnetCounterID;
            return View();
        }

        #endregion
    }
}