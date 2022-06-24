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
     class ContrMecanico
    {
        public static List<Mecanico> ListaMecanico()
        {
            return PersMecanico.ListaMecanico();
        }

        public static DataTable MostrarMecanico()
        {
            return PersMecanico.MostrarMecanico();
        }

        internal static bool AltaMecanico(Mecanico pMecanico)
        {
            return PersMecanico.AltaMecanico(pMecanico);
        }
        internal static bool BajaMecanico(int pCi)
        {
            return PersMecanico.BajaMecanico(pCi);
        }
        internal static bool ModificarMecanico(Mecanico pMecanico)
        {
            return PersMecanico.ModificarMecanico(pMecanico);
        }

    }
}
