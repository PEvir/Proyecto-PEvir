using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Seminario.Models;

namespace Proyecto_Seminario.Controllers
{
    public class LoginController : Controller
    {
        private PPVIREntities db = new PPVIREntities();

        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(USUARIO usuario)
        {
            Models.LoginConsulta log = new Models.LoginConsulta();
            if (log.Validar(usuario))
            {
                usuario.id = log.getID(usuario);
                ViewBag.Validado = true;
                ViewBag.Usuario = usuario;
                LoginConsulta.idUsuarioActivo = usuario.id;
                return View("Accept");
            }
            else
            {
                ViewBag.Validado = false;
                ViewBag.Usuario = null;
                LoginConsulta.idUsuarioActivo = -1;
                return View("Error");
            }
        }

        //
        // GET: /Login/Details/5

        public ActionResult Details(int id = 0)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Login/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Login/Create

        [HttpPost]
        public ActionResult Create(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //
        // GET: /Login/Edit/5

        public ActionResult Edit(int id = 0)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Login/Edit/5

        [HttpPost]
        public ActionResult Edit(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //
        // GET: /Login/Delete/5

        public ActionResult Delete(int id = 0)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Login/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            db.USUARIO.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}