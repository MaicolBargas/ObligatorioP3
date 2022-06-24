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
    class ContrVehiculo
    {
        public static List<Vehiculo> ListaVehiculo()
        {
            return PersVehiculo.ListaVehiculo();
        }

        public static DataTable MostrarVehiculo()
        {
            return PersVehiculo.MostrarVehiculo();
        }

        public static DataTable MostrarVehiculoDueno(int pdueno)
        {
            return PersVehiculo.MostrarVehiculoDueno(pdueno);

        }
        internal static bool AltaVehiculo(Vehiculo pVehiculo)
        {
            return PersVehiculo.AltaVehiculo(pVehiculo);
        }
        internal static bool BajaVehiculo(string pMatricula)
        {
            return PersVehiculo.BajaVehiculo(pMatricula);
        }
        internal static bool ModificarVehiculo(Vehiculo pVehiculo)
        {
            return PersVehiculo.ModificarVehiculo(pVehiculo);
        }
    }
}
