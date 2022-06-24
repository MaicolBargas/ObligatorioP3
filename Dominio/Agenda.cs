using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agenda
    {
        private int id;
        private int idVehiculo;
        private string dscEntrada;
        private int usuario;
        public Agenda(int id, int idVehiculo, string dscEntrada, int usuario )
        {
            this.id = id;
            this.idVehiculo = idVehiculo;
            this.dscEntrada = dscEntrada;
            this.usuario = usuario;
        }
        public Agenda(int idVehiculo, string dscEntrada, int usuario)
        {

            this.idVehiculo = idVehiculo;
            this.dscEntrada = dscEntrada;
            this.usuario = usuario;
        }
        public Agenda()
        { }

        public int Id { get => id; set => id = value; }
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string DscEntrada { get => dscEntrada; set => dscEntrada = value; }
        public int Usuario { get => usuario; set => usuario = value; }
    }
}
