﻿using System;
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
            String sql = "select textUsuario,textPass from textUsuarios where textUsuario = '" + usuario + "' AND textPass = '" + password + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
        }
    }
}
