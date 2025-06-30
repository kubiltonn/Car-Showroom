using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Car_izma.web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }


    }
}