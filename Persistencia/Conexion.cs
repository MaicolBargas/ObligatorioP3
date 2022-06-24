using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Conexion
    {
        protected static string CadenadaDeConexion
        {
            get
            {
                return @"data source=LAPTOP-4IUKP25O\SQLEXPRESS;" + "Initial Catalog=ObligatorioP3;Integrated Security=SSPI";
            }
        }
        /*public static SqlConnection Conectar()
          {
            SqlConnection conectar = new SqlConnection(CadenadaDeConexion);
            try
            {
                conectar.Open();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return conectar;
           }*/
    }
}


/*-------------------
va en la clase Conexión.cs
------------------
public static List<Cliente> Cliente_ObtenerTodos()
{
    List<Cliente> resultado = new List<Cliente>();

    Cliente cliente;
    using (SqlConnection conexionSQL = Conectar())
    {
        try
        {
            //Se debe identificar el storedprocedure que creamos en la base de datos ObtenerClientes
            SqlCommand cmd = new SqlCommand("ObtenerClientes", conexionSQL);
            //Se identifica el tipo de ejecución, en este caso un SP
            cmd.CommandType = CommandType.StoredProcedure;
            resultado.Add(cliente);
        }
                    }
}
                catch (Exception ex)
{

    throw new Exception(ex.ToString());

}
            }

            return resultado;

        }
*/