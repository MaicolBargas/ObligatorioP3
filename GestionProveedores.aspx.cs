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
    public partial class GestionProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar();
                btnAlta.Enabled = true;
                btnBaja.Enabled = false;
                btnModificar.Enabled = false;
            }
        }

        #region Funciones auxiliares
        protected void Listar()
        {
            GridProveedores.DataSource = Taller.MostrarProveedor();
            GridProveedores.DataBind();
        }

        protected void Limpiar()
        {
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtTelefono.Text = "";

            btnAlta.Enabled = true;
            btnBaja.Enabled = false;
            btnModificar.Enabled = false;
        }

        protected void linkMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admins.aspx");

        }
        private bool FaltanDatos()
        {
            if (this.txtId.Text == "" || this.txtNombre.Text == ""  || this.txtTelefono.Text == "")
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

            Proveedor proveedor = Taller.BuscarProveedorID(id);

            this.txtId.Text = proveedor.IdProveedor.ToString();
            this.txtNombre.Text = proveedor.NombreProveedor.ToString();
            this.txtTelefono.Text = proveedor.TelefonoProveedor.ToString();

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
                string nombre = this.txtNombre.Text;
                string telefono = this.txtTelefono.Text;

                if (Taller.BuscarProveedorID(id) == null)
                {
                    Proveedor unProveedor = new Proveedor(id,nombre, telefono);

                    if (Taller.AltaProveedor(unProveedor))
                    {
                        this.lblAlertas.Text = "Proveedor ingresado con éxito";
                        Limpiar();
                        Listar();
                    }
                }
                else
                {
                    this.lblAlertas.Text = "Este Proveedor ya ha sido registrado";
                }
            }
            else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            if (Taller.BajaProveedor(id))
            {
                this.lblAlertas.Text = "Proveedor dado de baja con éxito";
                Limpiar();
                Listar();
            }
            else
            {
                this.lblAlertas.Text = "El Proveedor no existe";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {

                int id = int.Parse(this.txtId.Text); 
                string nombre = this.txtNombre.Text;
                string telefono = this.txtTelefono.Text;

                Proveedor unProveedor = new Proveedor(id, nombre, telefono);

                if (Taller.ModificarProveedor(unProveedor))
                {
                    this.lblAlertas.Text = "Proveedor modificado con éxito";
                    Limpiar();
                    Listar();
                }
            }
            else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }
        }


        #endregion
    }
}

 

   