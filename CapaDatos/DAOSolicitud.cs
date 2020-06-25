using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAOSolicitud
    {
        public static int CrearSolicitud(Solicitud pasantia)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_InsertarSolicitud", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@descripcionSolicitud",pasantia.DescripcionSolicitud);
            comando.Parameters.AddWithValue("@estadoSolicitud",pasantia.EstadoSolicitud);
            comando.Parameters.AddWithValue("@fechaEmision",pasantia.FechaEmision);
            comando.Parameters.AddWithValue("@idEmpresa",pasantia.Empresa.IdEmpresa);
            comando.Parameters.AddWithValue("@idPracticante",pasantia.Practicante.IdPracticante);
            comando.Parameters.AddWithValue("@idDecano",pasantia.Decano.IdDecano);
            int resultado;
            try
            {
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                resultado = 0;
                Console.WriteLine(e.Message);
            }
            return resultado;
        }
    }
}
