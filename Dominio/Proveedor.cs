using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor
    {
        private int idProveedor;
        private string nombreProveedor;
        private string telefonoProveedor;

        public Proveedor(int idProveedor, string nombreProveedor, string telefonoProveedor)
        {
            this.idProveedor = idProveedor;
            this.nombreProveedor = nombreProveedor;
            this.telefonoProveedor = telefonoProveedor;
        }
        public Proveedor()
        { }
        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string NombreProveedor { get => nombreProveedor; set => nombreProveedor = value; }
        public string TelefonoProveedor { get => telefonoProveedor; set => telefonoProveedor = value; }
    }
}
