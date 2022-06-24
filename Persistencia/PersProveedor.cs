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
    public class PersProveedor : Conexion
    {
        public static List<Proveedor> ListaProveedor()
        {
            List<Proveedor> lista = new List<Proveedor>();
            try
            {
                Proveedor proveedor;

                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListarProveedor", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedor = new Proveedor();
                        proveedor.IdProveedor = int.Parse(reader["IdProveedor"].ToString());
                        proveedor.NombreProveedor = reader["Nombre"].ToString();
                        proveedor.TelefonoProveedor = reader["Telefono"].ToString();

                        lista.Add(proveedor);
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

        public static DataTable MostrarProveedor()
        {
            var conexionSQL = new SqlConnection(CadenadaDeConexion);
            conexionSQL.Open();
            SqlDataAdapter da = new SqlDataAdapter("ListarProveedor", conexionSQL);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool AltaProveedor(Proveedor pProveedor)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaProveedor", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdProveedor", pProveedor.IdProveedor));
                cmd.Parameters.Add(new SqlParameter("@Nombre", pProveedor.NombreProveedor));
                cmd.Parameters.Add(new SqlParameter("@Telefono", int.Parse(pProveedor.TelefonoProveedor)));

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

        public static bool BajaProveedor(int pId)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("BajaProveedor", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdProveedor", pId));

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

        public static bool ModificarProveedor(Proveedor pProveedor)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ModificarProveedor", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdProveedor", pProveedor.IdProveedor));
                cmd.Parameters.Add(new SqlParameter("@Nombre", pProveedor.NombreProveedor));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pProveedor.TelefonoProveedor));

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
