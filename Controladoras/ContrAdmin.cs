using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Persistencia;

namespace Controladoras
{
    public class ContrAdmin
    {


        public static List<Admin> ListaAdmin()
        {
            return PersAdmin.ListaAdmin();
        }        

        internal static bool AltaAdmin(Admin pAdmin)
        {
            return PersAdmin.AltaAdmin(pAdmin);
        }
    }
}
