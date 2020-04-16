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
using System.IO;

namespace Sistema_para_restaurante.Modulos.Productos
{
    public partial class Grupos_de_productos : Form
    {
        public Grupos_de_productos()
        {
            InitializeComponent();
        }
        string estado_imagen;

        private void Grupos_de_productos_Load(object sender, EventArgs e)
        {
            estado_imagen = "VACIO";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Insertar_Grupo_de_Productos();
            Dispose();
        }
        
        private void Insertar_Grupo_de_Productos()
        {
            try
            {
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Grupo_de_Productos", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Grupo", txtmesaedicion.Text);
                cmd.Parameters.AddWithValue("@Por_defecto","NO");
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@Estado_de_icono", estado_imagen);
                MemoryStream ms = new MemoryStream();
                ImagenGrupo.Image.Save(ms, ImagenGrupo.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());

                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.cerrar();
            }
            catch(Exception ex)
            {
                Conexion.ConexionMaestra.cerrar();
                MessageBox.Show(ex.Message);
            }
        }
        private void agregar_imagen()
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "imagenes|*.jpg;*.png;*.gif;*.jpeg";
            dlg.FilterIndex = 3;
            dlg.Title = "Cargador de Imagenes";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImagenGrupo.BackgroundImage = null;
                ImagenGrupo.Image = new Bitmap(dlg.FileName);
                Panel3.Visible = false;
                estado_imagen = "LLENO";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Close();
        }
    }
}
