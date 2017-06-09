using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC.Repository;
using LibraryMVC.Models;

namespace LibraryMVC.Controllers
{
    public class HomeController : Controller
    {
        LibraryRepository<Book> BookRepo;

        public HomeController()
        {
            BookRepo = new LibraryRepository<Book>();
        }
        public ActionResult Index()
        {
            return View(BookRepo.GetAllBooks());
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