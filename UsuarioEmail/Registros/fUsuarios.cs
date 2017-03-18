using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UsuarioEmail.Entidades;

namespace UsuarioEmail.Registros
{
    public partial class fUsuarios : Form
    {
        public fUsuarios()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Usuarios u = new Usuarios();
            //u.UsuarioId = Convert.ToInt32(textBoxId.Text);
            u.Nombre = textBoxUsuario.Text;

            if(BLL.UsuarioBLL.Guardar(u))
            {
                MessageBox.Show("Correcto");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            textBoxId.Clear();
            textBoxUsuario.Clear();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Usuarios u = BLL.UsuarioBLL.Buscar(Convert.ToInt32(textBoxId.Text));

            if(u!=null)
            {
                textBoxUsuario.Text = u.Nombre;
                MessageBox.Show("Correcto");
            }
            else
            {
                MessageBox.Show("Error");
            }

        }
    }
}
