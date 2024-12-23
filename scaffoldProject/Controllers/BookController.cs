using Microsoft.AspNetCore.Mvc;
using scaffoldProject.Data;

namespace scaffoldProject.Controllers
{
    public class BookController : Controller
    {
        scaffoldContext _Db = new scaffoldContext();
        public IActionResult Index()
        {
            var List =_Db.Books.ToList();
            return View(List);
        }
    }
}
