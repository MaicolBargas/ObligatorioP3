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
    public class PersVehiculo : Conexion
    {
        public static List<Vehiculo> ListaVehiculo()
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            try
            {
                Vehiculo vehiculo;

                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListarVehiculo", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehiculo = new Vehiculo();
                        vehiculo.IdVehiculo = int.Parse(reader["IdVehiculo"].ToString());
                        vehiculo.Matricula = reader["Matricula"].ToString();
                        vehiculo.Marca = reader["Marca"].ToString();
                        vehiculo.Modelo = reader["Modelo"].ToString();
                        vehiculo.Anio = int.Parse(reader["Anio"].ToString());
                        vehiculo.Color = reader["Color"].ToString();
                        vehiculo.DuenoVehiculo = int.Parse(reader["DuenoVehiculo"].ToString());


                        lista.Add(vehiculo);
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

        public static DataTable MostrarVehiculo()
        {
            var conexionSQL = new SqlConnection(CadenadaDeConexion);
            conexionSQL.Open();
            SqlDataAdapter da = new SqlDataAdapter("ListarVehiculo", conexionSQL);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable MostrarVehiculoDueno(int pdueno)
        {
            var conexionSQL = new SqlConnection(CadenadaDeConexion);
            conexionSQL.Open();
            SqlCommand cmd = new SqlCommand("ListarVehiculoxDueno", conexionSQL);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DuenoVehiculo", pdueno));
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public static bool AltaVehiculo(Vehiculo pVehiculo)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaVehiculo", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Matricula", pVehiculo.Matricula));
                cmd.Parameters.Add(new SqlParameter("@Marca", pVehiculo.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", pVehiculo.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Anio", pVehiculo.Anio));
                cmd.Parameters.Add(new SqlParameter("@Color", pVehiculo.Color));
                cmd.Parameters.Add(new SqlParameter("@DuenoVehiculo", pVehiculo.DuenoVehiculo));


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

        public static bool BajaVehiculo(string pMatricula)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("BajaVehiculo", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Matricula", pMatricula));

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

        public static bool ModificarVehiculo(Vehiculo pVehiculo)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ModificarVehiculo", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Matricula", pVehiculo.Matricula));
                cmd.Parameters.Add(new SqlParameter("@Marca", pVehiculo.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", pVehiculo.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Anio", pVehiculo.Anio));
                cmd.Parameters.Add(new SqlParameter("@Color", pVehiculo.Color));
                cmd.Parameters.Add(new SqlParameter("@DuenoVehiculo", pVehiculo.DuenoVehiculo));

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
