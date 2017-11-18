using Ninject;
using PagedList;
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

            //INSERT TEST DATA IN DATABASE
            //repo.RemoveData();
            //repo.CreateTestData();
        }
        
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(repo.List().ToPagedList(pageNumber, pageSize));
        }

        
        public ActionResult Filter(int? page, string search, string type)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            
            var filteredList = new List<Order>();

            if (type.Contains("Number")) filteredList = repo.List().Where(x => x.Number == search).ToList();

            else if (type.Contains("Manager")) filteredList = repo.List().Where(x => x.Manager.ToString().Contains(search)).ToList();
            
            else if (type.Contains("Annotation")) filteredList = repo.List().Where(x => x.Annotation.ToLower().Contains(search)).ToList();

            
            return View("Index",filteredList.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var order = repo.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit",order);
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
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(Order order)
        {
            if (!ModelState.IsValid) return View(order);

            var context = new OrderContext();
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