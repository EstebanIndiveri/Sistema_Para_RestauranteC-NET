using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace Sistema_para_restaurante.Conexion
{
    public partial class Conexion_manual : Form
    {
        private Librerias.AES aes = new Librerias.AES();

        int idtabla;

        public Conexion_manual()
        {
            InitializeComponent();
        }
        public void SavetoXML(object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }
        string dbcnString;
        public void ReadFromXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes[0].Value;
                txtCnString.Text = (aes.Decrypt(dbcnString, Librerias.Desencryptacion.appPwdUnique, int.Parse("256")));
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {

            }
        }

        private void Conexion_manual_Load(object sender, EventArgs e)
        {
            ReadFromXML();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comprobar_conection();
        }
        private void comprobar_conection()
        {
            SqlConnection con = new SqlConnection();

            try
            {
                /*Ingresar localHOST COMPLETO:
                 
                DESKTOP-AGLI2H6\ROOT

                 */
                /*Conexion libre por ahora*/
                con.ConnectionString = txtCnString.Text;
                SqlCommand com = new SqlCommand("SELECT * FROM SALON",con);
                con.Open();
                idtabla = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
                /*recien encripta*/
                SavetoXML(aes.Encrypt(txtCnString.Text, Librerias.Desencryptacion.appPwdUnique, int.Parse("256")));
                MessageBox.Show("Conexión realizada correctamente", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Sin conexión","Conexión fallida",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Console.WriteLine(ex);
                //MessageBox.Show(ex.Message);
            }
        }
        
    }
}
