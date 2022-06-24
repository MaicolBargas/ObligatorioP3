using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Controladoras;

namespace Taller_Mecanico
{
    public partial class GestionRepuestos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar();
                ListarProveedor();
                btnAlta.Enabled = true;
                btnBaja.Enabled = false;
                btnModificar.Enabled = false;
            }

        }

        #region Funciones Auxiliares
        protected void Listar()
        {
            GridRepuestos.DataSource = Taller.MostrarRepuesto();
            GridRepuestos.DataBind();
        }

        protected void Limpiar()
        {
            this.txtId.Text = "";
            this.txtDescripcion.Text = "";
            this.txtCosto.Text = "";
            this.txtTipo.Text = "";
            this.txtProveedor.SelectedValue = null;

            btnAlta.Enabled = true;
            btnBaja.Enabled = false;
            btnModificar.Enabled = false;
        }
        protected void linkMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admins.aspx");

        }
        protected void ListarProveedor()
        {
            txtProveedor.DataSource = Taller.MostrarProveedor();
            txtProveedor.DataTextField = "Nombre";
            txtProveedor.DataValueField = "IdProveedor";
            txtProveedor.DataBind();
            txtProveedor.Items.Insert(0, new ListItem("<Seleccionar Proveedor>", "0"));
        }
        private bool FaltanDatos()
        {
            if (this.txtId.Text == "" || this.txtDescripcion.Text == "" || this.txtCosto.Text == "" || this.txtTipo.Text == "" || this.txtProveedor.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void link_OnClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);

            Repuesto repuesto = Taller.BuscarRepuestoID(id);


            this.txtId.Text = repuesto.IdRepuesto.ToString();
            this.txtDescripcion.Text = repuesto.DescRepuesto1.ToString();
            this.txtCosto.Text = repuesto.CostoRepuesto1.ToString();
            this.txtTipo.Text = repuesto.TipoRepuesto1.ToString();
            this.txtProveedor.Text = repuesto.ProveedorRepuesto.ToString();

            btnAlta.Enabled = false;
            btnBaja.Enabled = true;
            btnModificar.Enabled = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        #endregion

        #region ABM
        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                int id = int.Parse(this.txtId.Text);
                string descripcion = this.txtDescripcion.Text;
                int costo = int.Parse(this.txtCosto.Text);
                char tipo = Convert.ToChar(this.txtTipo.Text);
                int proveedor = int.Parse(this.txtProveedor.Text);

                if (Taller.BuscarRepuestoID(id) == null)
                {
                    Repuesto unRepuesto = new Repuesto(id, descripcion, costo, tipo, proveedor);

                    if (Taller.AltaRepuesto(unRepuesto))
                    {
                        this.lblAlertas.Text = "Repuesto ingresado con éxito";
                        Limpiar();
                        Listar();
                    }
                }
                else
                {
                    this.lblAlertas.Text = "Este Repuesto ya ha sido registrado";
                }
            }
            else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            if (Taller.BajaRepuesto(id))
            {
                this.lblAlertas.Text = "Repuesto dado de baja con éxito";
                Limpiar();
                Listar();
            }
            else
            {
                this.lblAlertas.Text = "El Repuesto no existe";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                int id = int.Parse(this.txtId.Text);
                string descripcion = this.txtDescripcion.Text;
                int costo = int.Parse(this.txtCosto.Text);
                char tipo = Convert.ToChar(this.txtTipo.Text);
                int proveedor = int.Parse(this.txtProveedor.Text);

                Repuesto unRepuesto = new Repuesto(id, descripcion, costo, tipo, proveedor);

                if (Taller.ModificarRepuesto(unRepuesto))
                {
                    this.lblAlertas.Text = "Repuesto modificado con éxito";
                    Limpiar();
                    Listar();
                }
            }
            else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }
        }



        #endregion


    }
}
