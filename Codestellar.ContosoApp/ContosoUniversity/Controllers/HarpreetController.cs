using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class HarpreetController : Controller
    {
        // GET: Jasbir
        public ActionResult Index()
        {
            return View("../Jasbir/Index");
        }

        // GET: Jasbir/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jasbir/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jasbir/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jasbir/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jasbir/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jasbir/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jasbir/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
