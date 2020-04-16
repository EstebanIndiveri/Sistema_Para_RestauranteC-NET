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
    public partial class Registro_de_productos : Form
    {
        public Registro_de_productos()
        {
            InitializeComponent();
        }
        String Estado_imagen;

        private void Registro_de_productos_Load(object sender, EventArgs e)
        {
            Estado_imagen = "VACIO";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtDescripcion.Text != "")
            {
                if (txtPrecioVenta.Text != "")
                {
                    Insertar_producto1();
                }

            }
        }
        private void Insertar_producto1()
        {
            try
            {
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Producto", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@Id_grupo", Productos_rest.id_grupo);
                cmd.Parameters.AddWithValue("@Precio_de_venta", txtPrecioVenta.Text);
                cmd.Parameters.AddWithValue("@Estado_imagen", Estado_imagen);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenProducto.Image.Save(ms, ImagenProducto.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Imagen", ms.GetBuffer());
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.cerrar();
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    

        private void label4_Click(object sender, EventArgs e)
        {
            agregar_imagen();

        }
        private void agregar_imagen()
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImagenProducto.BackgroundImage = null;
                ImagenProducto.Image = new Bitmap(dlg.FileName);
                panel2.Visible = false;
                Estado_imagen = "LLENO";
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }
    }
}
