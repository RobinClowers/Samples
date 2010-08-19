using System.Web.Mvc;

namespace DependencyInjectionDemo
{
    public class HomeController : Controller
    {
        readonly ShoppingCart cart;

        public HomeController(ShoppingCart cart)
        {
            this.cart = cart;
        }

        public ActionResult Index()
        {
            cart.AddTo("item");
            return View();
        }
    }
}
