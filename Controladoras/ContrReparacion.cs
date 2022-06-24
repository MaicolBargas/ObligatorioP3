using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Dominio;
using System.Data;

namespace Controladoras
{
    class ContrReparacion
    {
        public static List<Reparacion> ListaReparacion()
        {
            return PersReparacion.ListaReparacion();
        }

        public static DataTable MostrarReparacion()
        {
            return PersReparacion.MostrarReparacion();
        }

        internal static bool AltaReparacion(Reparacion pReparacion)
        {
            return PersReparacion.AltaReparacion(pReparacion);
        }
        internal static bool BajaReparacion(int pId)
        {
            return PersReparacion.BajaReparacion(pId);
        }
        internal static bool ModificarReparacion(Reparacion pReparacion)
        {
            return PersReparacion.ModificarReparacion(pReparacion);
        }

    }
}
