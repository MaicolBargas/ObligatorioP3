using System;
using Dominio;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class PersMecanico : Conexion
    {
        public static List<Mecanico> ListaMecanico()
        {
            List<Mecanico> lista = new List<Mecanico>();
            try
            {
                Mecanico mecanico;

                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListarMecanico", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mecanico = new Mecanico();
                        mecanico.IdMecanico = int.Parse(reader["IdMecanico"].ToString());
                        mecanico.Nombre = reader["Nombre"].ToString();
                        mecanico.Ci = int.Parse(reader["Ci"].ToString());
                        mecanico.Telefono = reader["Telefono"].ToString();
                        mecanico.ValorHora = int.Parse(reader["ValorHora"].ToString());
 
                        lista.Add(mecanico);
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

        public static DataTable MostrarMecanico()
        {
            var conexionSQL = new SqlConnection(CadenadaDeConexion);
            conexionSQL.Open();
            SqlDataAdapter da = new SqlDataAdapter("ListarMecanico", conexionSQL);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool AltaMecanico(Mecanico pMecanico)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaMecanico", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Nombre", pMecanico.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Ci", pMecanico.Ci));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pMecanico.Telefono));
                cmd.Parameters.Add(new SqlParameter("@ValorHora", pMecanico.ValorHora));


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

        public static bool BajaMecanico(int pCi)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("BajaMecanico", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Ci", pCi));

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

        public static bool ModificarMecanico(Mecanico pMecanico)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ModificarMecanico", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Nombre", pMecanico.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Ci", pMecanico.Ci));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pMecanico.Telefono));
                cmd.Parameters.Add(new SqlParameter("@ValorHora", pMecanico.ValorHora));

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
