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
    public partial class Salones : Form
    {
        int idSalon;
        public Salones()
        {
            InitializeComponent();
        }

        private void Salones_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            textSalonEdicion.Focus();
        }
        /*Boton guardar*/
        /*punto*/
        private void button1_Click(object sender, EventArgs e)
        {
            insertar_salon();
        }
        /*punto*/
        private void insertar_mesas_vacias()
        {
            for (int i = 1; i <= 60; i++)
            {
                try
                {
                    Conexion.ConexionMaestra.abrir();
                    SqlCommand cmd = new SqlCommand("insertar_mesa",Conexion.ConexionMaestra.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mesa","NULO");
                    cmd.Parameters.AddWithValue("@idsalon", idSalon);
                    cmd.ExecuteNonQuery();
                    Conexion.ConexionMaestra.cerrar();
                }
                catch(Exception ex)
                {
                    Conexion.ConexionMaestra.cerrar();
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void mostrar_id_salon_ingresado()
        {
            SqlCommand com = new SqlCommand("mostrar_id_salon_recien_ingresado", Conexion.ConexionMaestra.conectar);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Salon",textSalonEdicion.Text);
            try
            {
                Conexion.ConexionMaestra.abrir();
                /*un dato en una variable aca esta el ERROR*/ 
                idSalon = Convert.ToInt32(com.ExecuteScalar());
                Conexion.ConexionMaestra.cerrar();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void insertar_salon()
        {
            try
            {
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Salon", Conexion.ConexionMaestra.conectar);
                /*agrega el parametro*/
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Salon", textSalonEdicion.Text);
                /*no query porque tiene un proceso almacenado :) para mostrar datos ExecuteScalar()*/
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.cerrar();
                mostrar_id_salon_ingresado();
                insertar_mesas_vacias();
                Close();
            }
            catch(Exception ex)
            {
                Conexion.ConexionMaestra.conectar.Close();
                /*Muestra el RAISERROR de la base de datos xddxdd*/
                MessageBox.Show(ex.Message);
            }
        }
    }
}
