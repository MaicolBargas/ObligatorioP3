using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Repuesto
    {
        private int idRepuesto;
        private string DescRepuesto;
        private int CostoRepuesto;
        private char TipoRepuesto;
        private int proveedorRepuesto;

        public Repuesto(int idRepuesto, string descRepuesto, int costoRepuesto, char tipoRepuesto, int proveedorRepuesto)
        {
            this.idRepuesto = idRepuesto;
            DescRepuesto = descRepuesto;
            CostoRepuesto = costoRepuesto;
            TipoRepuesto = tipoRepuesto;
            this.proveedorRepuesto = proveedorRepuesto;
        }
        public Repuesto()
        { }

        public int IdRepuesto { get => idRepuesto; set => idRepuesto = value; }
        public string DescRepuesto1 { get => DescRepuesto; set => DescRepuesto = value; }
        public int CostoRepuesto1 { get => CostoRepuesto; set => CostoRepuesto = value; }
        public char TipoRepuesto1 { get => TipoRepuesto; set => TipoRepuesto = value; }
        public int ProveedorRepuesto { get => proveedorRepuesto; set => proveedorRepuesto = value; }

    }
}
