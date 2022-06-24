using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
     public class Mecanico
    {
        private int idMecanico;
        private string nombre;
        private int ci;
        private string telefono;
        private int valorHora;

        public Mecanico(string nombre, int ci, string telefono, int valorHora)
        {
            this.nombre = nombre;
            this.ci = ci;
            this.telefono = telefono;
            this.valorHora = valorHora;
        }

        public Mecanico()
        { }

        public int IdMecanico { get => idMecanico; set => idMecanico = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Ci { get => ci; set => ci = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int ValorHora { get => valorHora; set => valorHora = value; }
    }
}
