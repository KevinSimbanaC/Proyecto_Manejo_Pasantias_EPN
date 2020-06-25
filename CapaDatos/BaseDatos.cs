using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class BaseDatos
    {
        public static SqlConnection ConexionBD()
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-0J0QFDT;Initial Catalog=db_Pasantias;Integrated Security=True");
            conexion.Open();
            return conexion;
        }
    }
}
