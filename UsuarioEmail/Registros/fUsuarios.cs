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
        private static Entidades.Usuarios usuario = null;
        private static List<Entidades.UsuariosEmails> listaRelaciones = new List<UsuariosEmails>();
        private static List<Entidades.Emails> listaEmails = new List<Emails>();

        public fUsuarios()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            dataGridView1.DataSource = null;
            usuario = null;
            listaRelaciones = new List<UsuariosEmails>();
            listaEmails = new List<Emails>();
            textBoxId.Clear();
            textBoxUsuario.Clear();
        }

        private void LlenarInstancia()
        {
            string nombre = textBoxUsuario.Text;
            usuario = new Usuarios(0, nombre);
        }

        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaEmails;
            dataGridView1.Columns["EmailId"].Visible = false;
            dataGridView1.Columns["Nombre"].HeaderText = "Email";
            /*dataGridView1.Columns.Add("EmailColumn", "Email");
            dataGridView1.Rows.Add();
            dataGridView1.Rows.*/
        }

        private void LlenarCombo()
        {
            comboBox1.DataSource = BLL.EmailBLL.GetListodo();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "EmailId";
        }
        
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            LlenarInstancia();
            if (usuario != null)
            {
                bool guardadoRelacion = true;

                usuario = BLL.UsuarioBLL.Guardar(usuario);
                foreach (var relacion in listaRelaciones)
                {
                    relacion.UsuarioId = usuario.UsuarioId;
                    if (BLL.UsuariosEmailsBLL.Guardar(relacion) == false)
                    {
                        guardadoRelacion = false;
                        break;
                    }
                }

                if (usuario != null && guardadoRelacion)
                {
                    MessageBox.Show("Correcto");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }

        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            usuario = BLL.UsuarioBLL.Buscar(Convert.ToInt32(textBoxId.Text));

            if(usuario != null)
            {
                listaRelaciones = null;
                listaEmails = null;
                listaEmails = new List<Emails>();
                listaRelaciones = BLL.UsuariosEmailsBLL.GetList(R => R.UsuarioId == usuario.UsuarioId);
                foreach (var relacion in listaRelaciones)
                {
                    listaEmails.Add(BLL.EmailBLL.Buscar(relacion.EmailId));
                }
                RefreshDataGridView();
                
                textBoxUsuario.Text = usuario.Nombre;
                MessageBox.Show("Correcto");
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void fUsuarios_Load(object sender, EventArgs e)
        {
            LlenarCombo();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            listaRelaciones.Add(new UsuariosEmails(0, 0, comboBox1.SelectedIndex + 1));
            listaEmails.Add(BLL.EmailBLL.Buscar(comboBox1.SelectedIndex + 1));
            RefreshDataGridView();
        }

        private void fUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            listaRelaciones = null;
            listaEmails = null;
        }
    }
}
