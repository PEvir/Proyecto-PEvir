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
    public class CursoPController : Controller
    {
        private PPVIREntities db = new PPVIREntities();

        //
        // GET: /CursoP/

        public ActionResult Index()
        {
            return View(db.CURSO.ToList());
        }

        //
        // GET: /CursoP/Details/5

        public ActionResult Details(int id = 0)
        {
            CURSO curso = db.CURSO.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        //
        // GET: /CursoP/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CursoP/Create

        [HttpPost]
        public ActionResult Create(CURSO curso)
        {
            if (ModelState.IsValid)
            {
                db.CURSO.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curso);
        }

        //
        // GET: /CursoP/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CURSO curso = db.CURSO.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        //
        // POST: /CursoP/Edit/5

        [HttpPost]
        public ActionResult Edit(CURSO curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        //
        // GET: /CursoP/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CURSO curso = db.CURSO.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        //
        // POST: /CursoP/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CURSO curso = db.CURSO.Find(id);
            db.CURSO.Remove(curso);
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