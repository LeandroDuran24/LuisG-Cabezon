using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UsuarioEmail.Entidades
{
    public class UsuariosEmails
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EmailId { get; set; }

        public UsuariosEmails()
        {

        }

        public UsuariosEmails(int id, int usuarioId, int emailId)
        {
            Id = id;
            UsuarioId = usuarioId;
            EmailId = emailId;
        }
    }
}
