using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using UsuarioEmail.Entidades;

namespace UsuarioEmail.DAL
{
    public class DetalleDb:DbContext
    {
        public DetalleDb():base("ConStr")
        {

        }
        public DbSet<Entidades.Usuarios> usuario { get; set; }
        public DbSet<Emails> email{ get; set; }
        public DbSet<Entidades.UsuariosEmails> usuariosEmails { get; set; }
    }
}
