using CONEXIONES.CONTENEDOR_DE_CLASES;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONEXIONES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string rutaArchivol = ((@"C:\Users\anner\Desktop\Universidad Mariano Galvez\Tercer Semestre\Programacion 1\datosTexto.csv"));
        string rutaConexion = "Data Source = DESKTOP-03L4M4P\\SQLEXPRESS; Initial Catalog = Alumnos; Integrated Security = True";
        string rutaConexionMysql = "Server=localhost\\MySqlServer;Port=3306;DATABASE=alumnosmysql;Uid=root;Pwd=SoyAgente2341; ";
        ClsArchivo Carga = new ClsArchivo();
        SqlConnection conn = new SqlConnection("Data Source = DESKTOP-03L4M4P\\SQLEXPRESS; Initial Catalog = Alumnos; Integrated Security = True");
        ClsClases Consulta = new ClsClases();

        //Boton que carga el archivo a SQl
        private void button1_Click(object sender, EventArgs e)
        {
            
            Carga.CArgarARchivo(rutaArchivol, rutaConexion);

        }

        //Boton que carga el archivo a Mysql
        private void button3_Click(object sender, EventArgs e)
        {
            Carga.CArgarARchivoMysql(rutaArchivol,rutaConexionMysql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // BOTON PARA EJECUTAR LA CARGA A ORCLE PENDIETE TODAVIA
        }

           // Boton para consultar todo el contenido cargado a la database
        private void button4_Click(object sender, EventArgs e)
        {
            Consulta.Consultas("SELECT * FROM TbAlumnos",conn, dataGridView1);
        }
        
        //Boton para consultar si el alumno tiene zona minima o no
        private void button5_Click(object sender, EventArgs e)
        {
            Consulta.Consultas("SELECT TbAlumnos.Nombre, MAX(TbAlumnos.[Pacial 1]+[Parcial 2]+[Parcial 3]) as [ZONA ACUMULADA], Promedio2 from TbAlumnos group by TbAlumnos.Nombre, TbAlumnos.Promedio2", conn, dataGridView1);
        }
 
        //cONSULTAR LOS ALUMNOS QUE NO LLEGARON A ZONA MINIMA
        private void button6_Click(object sender, EventArgs e)
        {
            Consulta.Consultas("SELECT Nombre,Promedio2 FROM TbAlumnos WHERE Promedio2 = 'Abajo de zona Minina'", conn, dataGridView1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClsEnviarCorreo NuevoCorreo = new ClsEnviarCorreo();
            NuevoCorreo.EnviarCorreo();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string NombreBusqueda = textBox1.Text;
            Consulta.Consultas($"SELECT Nombre, [pacial 1], [Parcial 2],[Parcial 3] FROM TbAlumnos Where Nombre = '{NombreBusqueda}'", conn, dataGridView1);
        }
    }
}