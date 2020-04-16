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

namespace Sistema_para_restaurante.Modulos.Punto_de_venta
{
    public partial class Visor_de_mesas : Form
    {
        public Visor_de_mesas()
        {
            InitializeComponent();
        }

        int id_salon;
        String estado;
        String Union_de_mesas;
        int Paso = 0;
        int idmesa_Origen;
        int idmesa_Destino;
        int idmesa;
        String nombre_mesa;
        String estado_de_mesa;
        int id_venta_mesa_origen;
        int id_venta_mesa_destino;
        private void Visor_de_mesas_Load(object sender, EventArgs e)
        {
            dibujarSalones();
            Union_de_mesas = "INACTIVO";
            PanelBienvenida.Visible = true;
            PanelBienvenida.Dock = DockStyle.Fill;
            PanelMesas.Visible = false;
            PanelMesas.Dock = DockStyle.None;
        }
        public void dibujarSalones()
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                Conexion.ConexionMaestra.abrir();
                String query = "SELECT * FROM SALON WHERE Estado='ACTIVO'";
                SqlCommand cmd = new SqlCommand(query, Conexion.ConexionMaestra.conectar);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panelC1 = new Panel();
                    Panel panelLateral = new Panel();

                    /*Configuración botones*/
                    b.Text = rdr["Salon"].ToString();
                    b.Name = rdr["id_salon"].ToString();
                    b.Tag = rdr["Estado"].ToString();
                    b.Dock = DockStyle.Fill;
                    b.BackColor = Color.Transparent;
                    b.Font = new System.Drawing.Font("Montserrat", 12);
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.ForeColor = Color.White;

                    /*panelC1*/
                    panelC1.Size = new System.Drawing.Size(244, 58);
                    panelC1.Name = rdr["Id_salon"].ToString();
                    /**/

                    /*panel lateral*/
                    panelLateral.Size = new System.Drawing.Size(3, 58);
                    panelLateral.Dock = DockStyle.Left;
                    panelLateral.BackColor = Color.Transparent;
                    panelLateral.Name = rdr["Id_salon"].ToString();
                    /**/

                    panelC1.Controls.Add(b);
                    panelC1.Controls.Add(panelLateral);

                    flowLayoutPanel1.Controls.Add(panelC1);
                    b.BringToFront();
                    panelLateral.SendToBack();
                    b.Click += new EventHandler(miEvento_salon_button);
                }
                Conexion.ConexionMaestra.cerrar();

            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void miEvento_salon_button(System.Object sender, EventArgs e)
        {
            try
            {
                PanelMesas.Visible = true;
                PanelMesas.Dock = DockStyle.Fill;
                id_salon = Convert.ToInt32(((Button)sender).Name);
                BtnParaLLevar.Visible = true;
                PanelBienvenida.Visible = false;
                PanelBienvenida.Dock = DockStyle.None;
                dibujarMesas();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public void dibujarMesas()
        {
            PanelMesas.Controls.Clear();

            try
            {
                Conexion.ConexionMaestra.abrir();
                String query = "mostrar_mesas_por_salon";
                SqlCommand cmd = new SqlCommand(query, Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_salon", id_salon);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panel = new Panel();

                    int alto = Convert.ToInt32(rdr["y"].ToString());
                    int ancho = Convert.ToInt32(rdr["x"].ToString());
                    int tamanio_letra = Convert.ToInt32(rdr["Tamanio_letra"].ToString());
                    Point tamanio = new Point(ancho, alto);

                    panel.Tag = rdr["Id_mesa"].ToString();

                    b.Text = rdr["Mesa"].ToString();
                    b.Name = rdr["Id_mesa"].ToString();
                    b.Tag = rdr["Estado_de_Disponibilidad"].ToString();

                    panel.Size = new System.Drawing.Size(tamanio);

                    if (b.Text != "NULO")
                    {
                        b.Size = new System.Drawing.Size(tamanio);
                        b.Font = new System.Drawing.Font("Montserrat", tamanio_letra);
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.ForeColor = Color.White;
                        PanelMesas.Controls.Add(b);
                        b.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        PanelMesas.Controls.Add(panel);
                    }
                    if (Convert.ToString(b.Tag) == "LIBRE")
                    {
                        b.BackColor = Color.DarkGreen;
                    }
                    else
                    {
                        b.BackColor = Color.Firebrick;
                    }
                    b.Click += new EventHandler(miEvento_button_mesa);
                }
                Conexion.ConexionMaestra.cerrar();
            }
            catch(Exception ex)
            {
                Conexion.ConexionMaestra.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void miEvento_button_mesa(System.Object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(48, 48, 48);
        }
    }
}
