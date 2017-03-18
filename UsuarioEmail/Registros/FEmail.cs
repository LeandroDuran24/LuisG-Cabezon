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
    public partial class FEmail : Form
    {
        public FEmail()
        {
            InitializeComponent();
        }

       

        private void FEmail_Load(object sender, EventArgs e)
        {
          

        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            emailidTextBox.Clear();
            nombreTextBox.Clear();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Emails em = new Emails();
            //em.EmailId = Convert.ToInt32(emailidTextBox.Text);
            em.Nombre = nombreTextBox.Text;

            if (BLL.EmailBLL.Guardar(em))
            {
                MessageBox.Show("Correcto");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Emails u = BLL.EmailBLL.Buscar(Convert.ToInt32(emailidTextBox.Text));

            if (u != null)
            {
                nombreTextBox.Text = u.Nombre;
                MessageBox.Show("Correcto");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
