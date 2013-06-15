using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Seminario.Models;

namespace Proyecto_Seminario.Controllers
{
    public class EstudianteLoggedController : Controller
    {
        private PPVIREntities db = new PPVIREntities();
        //
        // GET: /EstudianteLogged/
        
        public ActionResult Index()
        {
            return View(db.CURSO.ToList());
        }

    }
}
