using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UsuarioEmail.DAL;

namespace UsuarioEmail.BLL
{
    public class UsuariosEmailsBLL
    {
        public static bool Guardar(Entidades.UsuariosEmails n)
        {
            bool retono = false;
            using (var db = new DetalleDb())
            {
                try
                {


                    db.usuariosEmails.Add(n);
                    db.SaveChanges();
                    retono = true;

                }
                catch (Exception)
                {

                    throw;
                }
                return retono;
            }

        }

        public static Entidades.UsuariosEmails Buscar(int id)
        {

            Entidades.UsuariosEmails nuevo;
            using (var db = new DetalleDb())
            {
                try
                {
                    nuevo = db.usuariosEmails.Find(id);


                }
                catch (Exception)
                {

                    throw;
                }
                return nuevo;
            }
        }

        public static bool Eliminar(Entidades.UsuariosEmails id)
        {
            using (var db = new DetalleDb())
            {
                try
                {
                    db.Entry(id).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<Entidades.UsuariosEmails> GetList()
        {
            List<Entidades.UsuariosEmails> lista = new List<Entidades.UsuariosEmails>();
            using (var db = new DetalleDb())
            {
                try
                {
                    lista = db.usuariosEmails.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }

        public static List<Entidades.UsuariosEmails> GetList(Expression<Func<Entidades.UsuariosEmails, bool>> criterioBusqueda)
        {
            List<Entidades.UsuariosEmails> lista = new List<Entidades.UsuariosEmails>();
            using (var db = new DetalleDb())
            {
                try
                {
                    lista = db.usuariosEmails.Where(criterioBusqueda).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }
    }
}
