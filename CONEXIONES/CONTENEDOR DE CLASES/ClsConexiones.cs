using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONEXIONES
{
    class ClsConexiones
    {
        public void ConectarSql()
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-03L4M4P\\SQLEXPRESS; Initial Catalog = Alumnos; Integrated Security = True");

        }



    }
}
