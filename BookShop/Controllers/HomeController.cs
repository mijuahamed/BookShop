using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class HomeController: Controller
    {
        public string Index()
        {
            return "Home Page Message";
        }
    }
}
