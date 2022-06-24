using Dominio;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistencia
{
    public class PersUsuario : Conexion
    {
        public static List<Usuario> ListaUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                Usuario usuario;

                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListarUsuario", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.IdUsuario = int.Parse(reader["IdUsuario"].ToString());
                        usuario.Nombre = reader["Nombre"].ToString();
                        usuario.Ci = int.Parse(reader["Ci"].ToString());
                        usuario.Mail = reader["Mail"].ToString();
                        usuario.Password = reader["Password"].ToString();
                        usuario.Telefono = reader["Telefono"].ToString();
                        lista.Add(usuario);
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

        public static DataTable MostrarUsuarios()
        {
            var conexionSQL = new SqlConnection(CadenadaDeConexion);
            conexionSQL.Open();
            SqlDataAdapter da = new SqlDataAdapter("ListarUsuario", conexionSQL);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool AltaUsuario(Usuario pUsuario)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaUsuario", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Nombre", pUsuario.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Ci", pUsuario.Ci));
                cmd.Parameters.Add(new SqlParameter("@Mail", pUsuario.Mail));
                cmd.Parameters.Add(new SqlParameter("@Password", pUsuario.Password));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pUsuario.Telefono));

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

        public static bool BajaUsuario(int pCi)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("BajaUsuario", conexionSQL);

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

        public static bool ModificarUsuario(Usuario pUsuario)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ModificarUsuario", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Nombre", pUsuario.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Ci", pUsuario.Ci));
                cmd.Parameters.Add(new SqlParameter("@Mail", pUsuario.Mail));
                cmd.Parameters.Add(new SqlParameter("@Password", pUsuario.Password));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pUsuario.Telefono));

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
