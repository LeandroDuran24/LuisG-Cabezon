using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UsuarioEmail.Registros;

namespace UsuarioEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEmail ef = new FEmail();
            ef.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fUsuarios fu = new fUsuarios();
            fu.Show();
        }
    }
}
