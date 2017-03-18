using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsuarioEmail.DAL;

namespace UsuarioEmail.BLL
{
    public class UsuarioBLL
    {
        public static bool Guardar(Entidades.Usuarios n)
        {
            bool retono = false;
            using (var db = new DetalleDb())
            {
                try
                {


                    db.usuario.Add(n);
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

        public static Entidades.Usuarios Buscar(int id)
        {

            Entidades.Usuarios nuevo;
            using (var db = new DetalleDb())
            {
                try
                {
                    nuevo = db.usuario.Find(id);


                }
                catch (Exception)
                {

                    throw;
                }
                return nuevo;
            }
        }

        public static bool Eliminar(Entidades.Usuarios id)
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

        public static List<Entidades.Usuarios> GetListodo()
        {
            List<Entidades.Usuarios> lista = new List<Entidades.Usuarios>();
            using (var db = new DetalleDb())
            {
                try
                {
                    lista = db.usuario.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }

        public static List<Entidades.Usuarios> GetListNombre(string nombre)
        {
            List<Entidades.Usuarios> lista = new List<Entidades.Usuarios>();
            using (var db = new DetalleDb())
            {
                try
                {
                    lista = db.usuario.Where(p => p.Nombre == nombre).ToList();
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
