using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAODecano
    {
        public static Decano ObtenerDecanoActivo()
        {
            Decano decano = new Decano();

            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_ObtenerDecanoActivo", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    decano.IdDecano = reader.GetInt32(0);
                    decano.NombreUsuario = reader.GetString(1);
                } 
            }
            return decano; ;
            
        }
    }
}
