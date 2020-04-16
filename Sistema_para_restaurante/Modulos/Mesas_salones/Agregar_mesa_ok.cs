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

namespace Sistema_para_restaurante.Modulos.Mesas_salones
{
    public partial class Agregar_mesa_ok : Form
    {
        public Agregar_mesa_ok()
        {
            InitializeComponent();
        }

        private void Agregar_mesa_ok_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            txtmesaedicion.Text = Configurar_mesas.nombreMesa;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtmesaedicion.Text != "")
            {
                editar_mesa();
            }
        }
        private void editar_mesa()
        {
            try
            {
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("editar_mesa", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mesa", txtmesaedicion.Text);
                cmd.Parameters.AddWithValue("@id_mesa", Configurar_mesas.idMesa);
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.cerrar();
                Close();
            }
            catch(Exception ex)
            {
                Conexion.ConexionMaestra.cerrar();
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
