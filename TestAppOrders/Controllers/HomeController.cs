using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppOrders.Models;

namespace TestAppOrders.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repo;

        public HomeController(IRepository r)
        {
            repo = r;
        }
        
        public ActionResult Index()
        {
            return View(repo.List());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var order = repo.Get(id);
            if (order == null) return HttpNotFound();
            else return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order o)
        {
            if (!ModelState.IsValid)
            {
                throw new NullReferenceException();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order o)
        {
            if (!ModelState.IsValid) throw new NullReferenceException();
            repo.Create(o);

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }


    }
}