using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AtencionController : Controller
    {
        //
        // GET: /Atencion/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Atencion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Atencion/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Atencion/Create
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

        //
        // GET: /Atencion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Atencion/Edit/5
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

        //
        // GET: /Atencion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Atencion/Delete/5
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
