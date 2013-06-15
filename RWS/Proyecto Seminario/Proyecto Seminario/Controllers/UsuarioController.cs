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
    public class UsuarioController : Controller
    {
        private PPVIREntities db = new PPVIREntities();
        

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            LoginConsulta log = new LoginConsulta();
            if (log.estaOnline(id))
            {
                ViewBag.Usuario = log.getUsuarioById(id);
                ViewBag.Validado = true;
            }
            else
            {
                return View("SesionExpirada");
            }
            USUARIO usuario = db.USUARIO.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(USUARIO usuario)
        {
            usuario.fecharegistro = DateTime.Now;
            SESION sesion = new SESION();
            LoginConsulta log = new LoginConsulta();

            if (ModelState.IsValid)
            {
                db.USUARIO.Add(usuario);
                db.SaveChanges();

                sesion.idusuario = log.getIdUsarioLast();
                sesion.estado = "online";
                db.SESION.Add(sesion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

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
        // POST: /Usuario/Edit/5

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
        // GET: /Usuario/Delete/5

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
        // POST: /Usuario/Delete/5

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