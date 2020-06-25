using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAOEmpresa
    {
        public static List<Empresa> ObtenerListaEmpresas()
        {
            List<Empresa> empresas = new List<Empresa>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_VerListaEmpresas", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Empresa aux = new Empresa();
                    aux.IdEmpresa = reader.GetInt32(0);
                    aux.NombreEmpresa = reader.GetString(1);
                    aux.Descripcion = reader.GetString(2);
                    aux.CorreoElectronico = reader.GetString(3);
                    aux.Direccion = reader.GetString(4);
                    aux.Telefono = reader.GetString(5);
                    aux.Fax = reader.GetString(6);
                    aux.Jefe.IdJefe = reader.GetInt32(7);
                    empresas.Add(aux);
                }
            }
            return empresas;
        }
    }
}
