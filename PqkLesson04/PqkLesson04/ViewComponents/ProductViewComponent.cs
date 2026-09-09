using Microsoft.AspNetCore.Mvc;

namespace PqkLesson04.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
