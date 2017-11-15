using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestAppOrders.Models;

namespace TestAppOrders.Controllers
{
    [Authorize]
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
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit([Bind(Include = "Id, Number, CreateDate, EndDate, Manager, Annotation")]Order order)
        {
            var context = new OrderContext();

            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            context.Entry(order).State = EntityState.Modified;
            context.SaveChangesAsync();
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
            var context = new OrderContext();
            if (!ModelState.IsValid) return View(o);

            Order order = new Order()
            {
                Number = o.Number,
                CreateDate = o.CreateDate,
                EndDate = o.EndDate,
                Manager = o.Manager,
                Annotation = o.Annotation
            };

            context.Orders.Add(order);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }


    }
}