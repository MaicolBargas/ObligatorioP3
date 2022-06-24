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
    class ContrAgenda
    {
        public static List<Agenda> ListaAgenda()
        {
            return PersAgenda.ListaAgenda();
        }

        public static DataTable MostrarAgenda()
        {
            return PersAgenda.MostrarAgenda();
        }
        public static DataTable MostrarAgendaUsuario(int pUsuario)
        {
            return PersAgenda.MostrarAgendaUsuario(pUsuario);

        }
        internal static bool AltaAgenda(Agenda pAgenda)
        {
            return PersAgenda.AltaAgenda(pAgenda);
        }
        internal static bool BajaAgenda(int pId)
        {
            return PersAgenda.BajaAgenda(pId);
        }

    }
}
