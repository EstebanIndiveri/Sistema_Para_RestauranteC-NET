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
   
    public partial class Configurar_mesas : Form
    {
        int id_salon;
        string estado;
        public static string nombreMesa;
        public static int idMesa;
        public Configurar_mesas()
        {
            InitializeComponent();
        }

        private void Configurar_mesas_Load(object sender, EventArgs e)
        {
            PanelBienvenida.Dock = DockStyle.Fill;
            dibujarSalones();
        }

        private void dibujarMesas()
        {
            try
            {
                PanelMesas.Controls.Clear();
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_mesas_por_salon", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_salon", id_salon);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    /*boton*/
                    Button b = new Button();
                    Panel panel = new Panel();
                    int alto = Convert.ToInt32(rdr["y"].ToString());
                    int ancho = Convert.ToInt32(rdr["x"].ToString());
                    int tamanio_letra = Convert.ToInt32(rdr["Tamanio_letra"].ToString());
                    Point tamanio = new Point(ancho, alto);

                    /*panel*/
                    panel.BackgroundImage = Properties.Resources.mesa_vacia;
                    panel.BackgroundImageLayout = ImageLayout.Zoom;
                    panel.Cursor = Cursors.Hand;
                    panel.Tag = rdr["Id_mesa"].ToString();
                    panel.Size = new System.Drawing.Size(tamanio);

                    /**/
                    b.Text = rdr["Mesa"].ToString();
                    b.Name = rdr["Id_mesa"].ToString();
                    
                    /*Condicion nula*/
                    if(b.Text != "NULO")
                    {
                        b.Size = new System.Drawing.Size(tamanio);
                        b.BackColor = Color.DarkGreen;
                        b.Font = new System.Drawing.Font("Montserrat",tamanio_letra);
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.ForeColor = Color.White;
                        PanelMesas.Controls.Add(b);

                    }
                    else
                    {
                        PanelMesas.Controls.Add(panel);
                    }
                    b.Click += new EventHandler(miEvento);
                    panel.Click += new EventHandler(miEventoPanel_Click);
                }
                Conexion.ConexionMaestra.cerrar();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.cerrar();
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void miEvento(System.Object sender, EventArgs e)
        {
            nombreMesa = ((Button)sender).Text;
            idMesa = Convert.ToInt32(((Button)sender).Name);
            Agregar_mesa_ok frm = new Agregar_mesa_ok();
            /*mismo que el panel*/
            frm.FormClosed += new FormClosedEventHandler(frm_agregar_mesa_ok_FormClosed);
            frm.ShowDialog();
        }
        private void miEventoPanel_Click(System.Object sender, EventArgs e)
        {
            idMesa = Convert.ToInt32(((Panel)sender).Tag);
            Agregar_mesa_ok frm = new Agregar_mesa_ok();
            /*al momento de cerrar dibuja las mesas de nuevo (actualiza ponele)*/
            frm.FormClosed += new FormClosedEventHandler(frm_agregar_mesa_ok_FormClosed);
            frm.ShowDialog();
        }
        private void frm_agregar_mesa_ok_FormClosed(Object sender, FormClosedEventArgs e)
        {
            dibujarMesas();
        }
        private void dibujarSalones()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_SALON", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@buscar", txtSalon.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panelC1 = new Panel();
                    b.Text = rdr["Salon"].ToString();
                    b.Name = rdr["id_salon"].ToString();
                    b.Dock = DockStyle.Fill;
                    b.BackColor = Color.Transparent;
                    b.Font = new System.Drawing.Font("Montserrat",12);
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.Tag = rdr["Estado"].ToString();

                    panelC1.Size = new System.Drawing.Size(312, 60);
                    panelC1.Name = rdr["Id_salon"].ToString();
                    String estado;
                    estado = rdr["Estado"].ToString();
                    if(estado == "ELIMINADO")
                    {
                        b.Text = rdr["Salon"].ToString() + " - Eliminado";
                        b.ForeColor = Color.FromArgb(231, 63, 67);
                    }
                    else
                    {
                        b.ForeColor = Color.White;
                    }
                    panelC1.Controls.Add(b);
                    flowLayoutPanel1.Controls.Add(panelC1);
                    b.Click += new EventHandler(Evento_salon_button);
                }
                Conexion.ConexionMaestra.cerrar();

            }
            catch(Exception ex)
            {
                Conexion.ConexionMaestra.cerrar();

                MessageBox.Show(ex.StackTrace);
            }
        }
        /*Evento personalizado*/
        private void Evento_salon_button(System.Object sender, EventArgs e)
        {
            PanelBienvenida.Visible = false;
            PanelBienvenida.Dock = DockStyle.None;
            PanelMesas.Visible = true;
            PanelMesas.Dock = DockStyle.Fill;
            id_salon = Convert.ToInt32(((Button)sender).Name);
            estado = Convert.ToString(((Button)sender).Tag);
            dibujarMesas();
            /*pimer panel creado*/
            foreach (Panel PanelC2 in flowLayoutPanel1.Controls)
            {
                /*nuevo panel creado*/
                if(PanelC2 is Panel)
                {
                    /*boton agregado por codigo*/
                    foreach(Button boton in PanelC2.Controls)
                    {
                        if(boton is Button)
                        {
                            boton.BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
            }
            String NOMBRE = Convert.ToString(((Button)sender).Name);
            foreach(Panel PanelC2 in flowLayoutPanel1.Controls)
            {
                if(PanelC2 is Panel)
                {
                    foreach(Button boton in PanelC2.Controls)
                    {
                        if(boton is Button)
                        {
                            if (boton.Name == NOMBRE)
                            {
                                boton.BackColor = Color.FromArgb(92, 70, 107);
                                break;
                            }
                        }
                    }
                }
            }
        }

        /*Cierre evento personalizado*/
        private void button1_Click(object sender, EventArgs e)
        {
            Modulos.Mesas_salones.Salones frm = new Modulos.Mesas_salones.Salones();
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frm.ShowDialog();

        }
        public void frm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            dibujarSalones();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            aumentar_tamanio_mesa();
        }
        internal void aumentar_tamanio_mesa()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ConexionMaestra.abrir();
                cmd = new SqlCommand("aumentar_tamanio_mesa", Conexion.ConexionMaestra.conectar);
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.cerrar();
                dibujarMesas();
            }
            catch(Exception ex)
            {
                Conexion.ConexionMaestra.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
        internal void disminuir_tamanio_mesa()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ConexionMaestra.abrir();
                cmd = new SqlCommand("disminuir_tamanio_mesa", Conexion.ConexionMaestra.conectar);
                /*Usamos esta instancia porque no tenemos parametros*/
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.cerrar();
                dibujarMesas();
            }
            catch(Exception ex)
            {
                Conexion.ConexionMaestra.cerrar();
                MessageBox.Show(ex.Message);
            }
        }
        internal void aumentar_tamanio_letra()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ConexionMaestra.abrir();
                cmd = new SqlCommand("aumentar_tamanio_letra", Conexion.ConexionMaestra.conectar);
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.cerrar();
                dibujarMesas();
            }
            catch(Exception ex)
            {
                Conexion.ConexionMaestra.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            disminuir_tamanio_mesa();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            aumentar_tamanio_letra();
        }
        internal void disminuir_tamanio_letra()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ConexionMaestra.abrir();
                cmd = new SqlCommand("disminuir_tamanio_letra", Conexion.ConexionMaestra.conectar);
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.cerrar();
                dibujarMesas();

            }
            catch(Exception ex)
            {
                Conexion.ConexionMaestra.cerrar();
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            disminuir_tamanio_letra();
        }
    }
}
