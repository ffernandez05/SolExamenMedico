using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmpresaController : Controller
    {
        ServiceEmpresa.ServiceEmpresaClient _proxy = new ServiceEmpresa.ServiceEmpresaClient();
        //
        // GET: /Empresa/
        public ActionResult Index()
        {
            var data = _proxy.Listar();
            return View(data);
        }

        //
        // GET: /Empresa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Empresa/Create
        [HttpPost]
        public ActionResult Create(ServiceEmpresa.Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                    _proxy.Registro(empresa);
                    return RedirectToAction("Index");                
            }

            return View(empresa);
        }

        //
        // GET: /Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Empresa/Edit/5
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
        // GET: /Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Empresa/Delete/5
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
