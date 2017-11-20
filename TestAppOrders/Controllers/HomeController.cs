using Ninject;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            var orders = repo.List().ToPagedList(pageNumber, pageSize);
            return View(orders);
        }

        
        public ActionResult Filter(int? page, string search, string type)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            
            var filteredList = new List<Order>();

            if (type.Contains("Number")) filteredList = repo.List().Where(x => x.Number == search).ToList();

            else if (type.Contains("Manager")) filteredList = repo.List().Where(x => x.Manager.ToString().Contains(search)).ToList();
            
            else if (type.Contains("Annotation")) filteredList = repo.List().Where(x => x.Annotation.ToLower().Contains(search)).ToList();

            return View("Index",filteredList.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var order = await repo.Get(id);
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
            if (ModelState.IsValid)
            {
                repo.Edit(order); 
            }
            else return HttpNotFound();

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
            else repo.Create(order);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var order = await repo.Get(id);
            if (order == null) return HttpNotFound();
            return PartialView(order);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid) repo.Delete(id);
            else return HttpNotFound();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }


    }
}