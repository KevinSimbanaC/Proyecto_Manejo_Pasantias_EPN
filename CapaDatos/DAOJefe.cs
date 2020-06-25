using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaNegocio;

namespace CapaDatos
{
    public class DAOJefe
    {
        public static List<Solicitud> ObtenerListaPracticantes(Jefe j)
        {
            List<Solicitud> solicituds = new List<Solicitud>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_BuscarPracticantesInformeJefe", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idJefe", j.IdJefe);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Solicitud aux = new Solicitud();
                    aux.IdSolicitud = reader.GetInt32(0);
                    aux.Practicante.NombreUsuario = reader.GetString(1);
                    aux.Practicante.Carrera = reader.GetString(2);
                    aux.Empresa.NombreEmpresa = reader.GetString(3);
                    aux.Empresa.Direccion = reader.GetString(4);
                    aux.Empresa.Telefono = reader.GetString(5);
                    aux.Empresa.Fax = reader.GetString(6);
                    aux.Empresa.CorreoElectronico = reader.GetString(7);
                    solicituds.Add(aux);
                }
            }
            return solicituds;
        }
        public static int CrearInforme(InformeJefe i, Solicitud pasantia, Jefe j)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_CrearInformeJefe", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@areaAsignada",i.AreaAsignada);
            comando.Parameters.AddWithValue("@actividadesDesarrolladas",i.ActividadesDesarrolladas);
            comando.Parameters.AddWithValue("@horario,",i.Horario);
            comando.Parameters.AddWithValue("@fortalezas",i.Fortalezas);
            comando.Parameters.AddWithValue("@debilidades",i.Debilidades);
            comando.Parameters.AddWithValue("@evaluacion",i.Evaluacion);
            comando.Parameters.AddWithValue("@desempenio",i.Desempenio);
            comando.Parameters.AddWithValue("@motivacion",i.Motivacion);
            comando.Parameters.AddWithValue("@contactoTutor",i.ContactoTutor);
            comando.Parameters.AddWithValue("@idSolicitud",i.Solicitud.IdSolicitud);
            comando.Parameters.AddWithValue("@idTutor",i.Tutor);
            comando.Parameters.AddWithValue("@idRegistroDeAsistencia",i.RegistroAsistencia);
            comando.Parameters.AddWithValue("@idJefe",i.Jefe.IdJefe);

            int resultado;
            try
            {
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                resultado = 0;

            }
            return resultado;

        }

        public static List<InformeJefe> ObtenerInformesJefe(Jefe j)
        {
            List<InformeJefe> informes = new List<InformeJefe>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_BuscarInformesMitadPeriodoTutor", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idTutor", j.IdJefe);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    InformeJefe aux = new InformeJefe();
                    
                    
                    aux.Solicitud.Empresa.NombreEmpresa = reader.GetString(8);
                    aux.Solicitud.Empresa.Direccion = reader.GetString(9);
                    aux.Solicitud.Empresa.Telefono = reader.GetString(10);
                    aux.Solicitud.Empresa.Fax = reader.GetString(11);
                    aux.Solicitud.Empresa.CorreoElectronico = reader.GetString(12);
                    aux.Solicitud.Practicante.NombreUsuario = reader.GetString(13);
                    aux.Solicitud.Practicante.Carrera = reader.GetString(14);
                    informes.Add(aux);
                }
            }
            return informes;
        }
        public static int BorrarInforme(InformeMitadPeriodo i)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_EliminarInformeMitad", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idInformeMitad", i.IdInformeMitadPeriodo);
            int resultado;
            try
            {
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                resultado = 0;

            }
            return resultado;
        }
        public static int EditarInforme(InformeMitadPeriodo i)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_EditarInformeMitad", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idInformeMitad", i.IdInformeMitadPeriodo);
            comando.Parameters.AddWithValue("@preparacionTecnica", i.PreparacionTecnica);
            comando.Parameters.AddWithValue("@capacidadAprendizaje", i.CapacidadAprendizaje);
            comando.Parameters.AddWithValue("@trabajoEquipo", i.TrabajoEquipo);
            comando.Parameters.AddWithValue("@creatividad", i.Creatividad);
            comando.Parameters.AddWithValue("@adaptacion", i.Adaptacion);
            comando.Parameters.AddWithValue("@responsabilidad", i.Responsabilidad);
            comando.Parameters.AddWithValue("@puntualidad ", i.Puntualidad);

            int resultado;
            try
            {
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                resultado = 0;

            }
            return resultado;
        }

    }
}
