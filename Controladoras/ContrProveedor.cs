using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Persistencia;


namespace Controladoras
{
    class ContrProveedor
    {
        public static List<Proveedor> ListaProveedor()
        {
            return PersProveedor.ListaProveedor();
        }

        public static DataTable MostrarProveedor()
        {
            return PersProveedor.MostrarProveedor();
        }

        internal static bool AltaProveedor(Proveedor pProveedor)
        {
            return PersProveedor.AltaProveedor(pProveedor);
        }
        internal static bool BajaProveedor(int pId)
        {
            return PersProveedor.BajaProveedor(pId);
        }
        internal static bool ModificarProveedor(Proveedor pProveedor)
        {
            return PersProveedor.ModificarProveedor(pProveedor);
        }

    }
}
