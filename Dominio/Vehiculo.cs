using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vehiculo
    {
        private int idVehiculo;
        private string matricula;
        private string marca;
        private string modelo;
        private int anio;
        private string color;
        private int duenoVehiculo;

        public Vehiculo( string matricula, string marca, string modelo, int anio, string color, int duenoVehiculo)
        {
 
            this.matricula = matricula;
            this.marca = marca;
            this.modelo = modelo;
            this.anio = anio;
            this.color = color;
            this.duenoVehiculo = duenoVehiculo;
        }

        public Vehiculo()
        { }
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int Anio { get => anio; set => anio = value; }
        public string Color { get => color; set => color = value; }
        public int DuenoVehiculo { get => duenoVehiculo; set => duenoVehiculo = value; }
    }
}
