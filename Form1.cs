using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace inicio_de_sesion_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonIngreso_Click(object sender, EventArgs e)
        {
            String usuario, password;
            usuario = textUsuario.Text;
            password = textPass.Text;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-7LDGQBD;Initial Catalog=login;Integrated Security=True");
            try
            {
                con.Open();
                MessageBox.Show("conexion exitosa");
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error" + ex.ToString());
                throw;
            }
            String sql = "select user_log,pass_log from inicio_sesion where user_log = '" + usuario + "' AND textPass = '" + password + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                MessageBox.Show("Bienvenido " + usuario);
            }
            else
            {
                MessageBox.Show("No existe  este usuario" + usuario);
            }
        }

        private void textUsuario_Leave(object sender, EventArgs e)
        {
            if (textUsuario.Text == "")
            {
                textUsuario.Text = "ingrese su usuario";
                textUsuario.ForeColor = Color.Black;
            }
        }

        private void textUsuario_Enter(object sender, EventArgs e)
        {
            if (textUsuario.Text == "ingrese su usuario")
            {
                textUsuario.Text = "";
                textUsuario.ForeColor = Color.Black;
            }
        }

        private void textPass_Leave(object sender, EventArgs e)
        {
            if (textPass.Text == "")
            {
                textPass.Text = "ingrese su usuario";
                textPass.ForeColor = Color.Black;
                textPass.UseSystemPasswordChar = false;
            }
        }

        private void textPass_Enter(object sender, EventArgs e)
        {
            if (textPass.Text == "ingrese su usuario")
            {
                textPass.Text = "";
                textPass.ForeColor = Color.Black;
                textPass.UseSystemPasswordChar = true;
            }
        }

        private void Muestra_CheckedChanged(object sender, EventArgs e)
        {
            if(Muestra.Checked == true)
            {
                textPass.UseSystemPasswordChar = false;
            }
            else
            {
                textPass.UseSystemPasswordChar = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRegistro_Click(object sender, EventArgs e)
        {
            
        }
    }
}
