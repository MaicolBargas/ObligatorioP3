using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        private int idUsuario;
        private string nombre;
        private int ci;
        private string telefono;
        private string mail;
        private string password;
        



        public Usuario(string nombre, int ci, string telefono,string mail, string password )
        {
            this.nombre = nombre;
            this.ci = ci;
            this.mail = mail;
            this.password = password;
            this.telefono = telefono;
        }
        public Usuario()
        { }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Ci { get => ci; set => ci = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Password { get => password; set => password = value; }
    }
}
