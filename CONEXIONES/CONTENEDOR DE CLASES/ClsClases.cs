using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONEXIONES.CONTENEDOR_DE_CLASES
{
    class ClsClases
    {
        
        public void Consultas(string consulta, SqlConnection conexion, DataGridView dataGridView1)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            dataGridView1.AutoResizeColumns();
            dataGridView1.DataSource = tabla;
            conexion.Close();
            
        }

        //public void Busquedas(string consulta, SqlConnection conexion, DataGridView dataGridView1)
        ////{
        ////    string variable;
        ////    conexion.Open();
        ////    SqlCommand comando = new SqlCommand(consulta, conexion);
        ////    SqlDataAdapter data = new SqlDataAdapter(comando);
        ////    DataTable tabla = new DataTable();
        ////    data.Fill(tabla);
        ////    dataGridView1.AutoResizeColumns();
        ////    dataGridView1.DataSource = tabla;
        ////    conexion.Close();

        //}
    }
}
