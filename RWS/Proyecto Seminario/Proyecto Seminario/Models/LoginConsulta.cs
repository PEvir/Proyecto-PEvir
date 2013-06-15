using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Seminario.Models
{
    public class LoginConsulta
    {
        public static USUARIO userActivo;
        public static Boolean activo;
        public static int idUsuarioActivo = -1;

        public Boolean Validar(USUARIO inUser)
        {
            PPVIREntities db = new PPVIREntities();
            int cont = (from usu in db.USUARIO where usu.nick == inUser.nick && usu.contrasena == inUser.contrasena select usu).Count();
            if (cont == 1)
            {
                return true;
            }
            return false;
        }
        public int getID(USUARIO inUser)
        {
            PPVIREntities db = new PPVIREntities();
            int id = -1;
            id = (from usu in db.USUARIO where usu.nick == inUser.nick && usu.contrasena == inUser.contrasena select usu).First().id;
            return id;
        }
        public void iniciarSesion(USUARIO usuario)
        {
            PPVIREntities db = new PPVIREntities();

        }

        public int getIdUsarioLast()
        {
            PPVIREntities db = new PPVIREntities();
            // Expression myExpression = new Expression(db.USUARIO,);
            List<USUARIO> listUsuario = (from usu in db.USUARIO select usu).ToList();
            return listUsuario[listUsuario.Count() - 1].id;
        }

        public Boolean estaOnline(int idUsuarioIn)
        {
            PPVIREntities db = new PPVIREntities();
            int c = (from usu in db.SESION where usu.idusuario == idUsuarioIn select usu).Count();
            if (c > 0)
            {
                return true;
            }
            return false;
        }

        public USUARIO getUsuarioById(int id)
        {
            PPVIREntities db = new PPVIREntities();
            USUARIO user = null;
            user = (from usu in db.USUARIO where usu.id == id select usu).First();
            return user;
        }
    }
}