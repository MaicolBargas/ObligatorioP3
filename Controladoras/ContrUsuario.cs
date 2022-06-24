using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Dominio;

namespace Controladoras
{
    class ContrUsuario
    {
        public static List<Usuario> ListaUsuario()
        {
            return PersUsuario.ListaUsuario();
        }

        public static DataTable MostrarUsuarios()
        {
            return PersUsuario.MostrarUsuarios();
        }

        internal static bool AltaUsuario(Usuario pUsuario)
         {
             return PersUsuario.AltaUsuario(pUsuario);
         }
        internal static bool BajaUsuario(int pCi)
        {
            return PersUsuario.BajaUsuario(pCi);
        }
        internal static bool ModificarUsuario(Usuario pUsuario)
        {
            return PersUsuario.ModificarUsuario(pUsuario);
        }
    }
}
