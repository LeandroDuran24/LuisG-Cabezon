﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsuarioEmail.DAL;

namespace UsuarioEmail.BLL
{
    public class EmailBLL
    {
        public static bool Guardar(Entidades.Emails n)
        {
            bool retono = false;
            using (var db = new DetalleDb())
            {
                try
                {


                    db.email.Add(n);
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

        public static Entidades.Emails Buscar(int id)
        {

            Entidades.Emails nuevo;
            using (var db = new DetalleDb())
            {
                try
                {
                    nuevo = db.email.Find(id);


                }
                catch (Exception)
                {

                    throw;
                }
                return nuevo;
            }
        }

        public static bool Eliminar(Entidades.Emails id)
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

        public static List<Entidades.Emails> GetListodo()
        {
            List<Entidades.Emails> lista = new List<Entidades.Emails>();
            using (var db = new DetalleDb())
            {
                try
                {
                    lista = db.email.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }

        public static List<Entidades.Emails> GetListNombre(string nombre)
        {
            List<Entidades.Emails> lista = new List<Entidades.Emails>();
            using (var db = new DetalleDb())
            {
                try
                {
                    lista = db.email.Where(p => p.Nombre == nombre).ToList();
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