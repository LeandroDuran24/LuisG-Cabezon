using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UsuarioEmail.Entidades
{
   public class Emails
    {
        [Key]
        public int EmailId { get; set; }
        public string Nombre { get; set; }
    }
}
