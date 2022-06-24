using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersAgenda : Conexion
    {
        public static List<Agenda> ListaAgenda()
        {
            List<Agenda> lista = new List<Agenda>();
            try
            {
                Agenda agenda;

                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListarAgenda", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        agenda = new Agenda();
                        agenda.Id = int.Parse(reader["Id"].ToString());
                        agenda.IdVehiculo = int.Parse(reader["IdVehiculo"].ToString());
                        agenda.DscEntrada = reader["DscEntrada"].ToString();
                        agenda.Usuario = int.Parse(reader["Usuario"].ToString());
                        lista.Add(agenda);
                    }
                }
                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }
            return lista;
        }

        public static DataTable MostrarAgenda()
        {
            var conexionSQL = new SqlConnection(CadenadaDeConexion);
            conexionSQL.Open();
            SqlDataAdapter da = new SqlDataAdapter("ListarAgenda", conexionSQL);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable MostrarAgendaUsuario(int pUsuario)
        {
            var conexionSQL = new SqlConnection(CadenadaDeConexion);
            conexionSQL.Open();
            SqlCommand cmd = new SqlCommand("ListarAgendaxUsuario", conexionSQL);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Usuario", pUsuario));
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public static bool AltaAgenda(Agenda pAgenda)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaAgenda", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.Add(new SqlParameter("@IdVehiculo", pAgenda.IdVehiculo));
                cmd.Parameters.Add(new SqlParameter("@DscEntrada", pAgenda.DscEntrada));
                cmd.Parameters.Add(new SqlParameter("@Usuario", pAgenda.Usuario));


                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;

        }

        public static bool BajaAgenda(int pId)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("BajaAgenda", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;

        }
    }
}
