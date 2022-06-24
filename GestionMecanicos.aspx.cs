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
    public partial class GestionMecanicos : System.Web.UI.Page
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
            GridMecanicos.DataSource = Taller.MostrarMecanico();
            GridMecanicos.DataBind();
        }

        protected void Limpia()
        {
            this.txtValorHora.Text = "";
            this.txtNombre.Text = "";
            this.txtCi.Text = "";
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
            if (this.txtValorHora.Text == "" || this.txtNombre.Text == "" || this.txtCi.Text == "" || this.txtTelefono.Text == "")
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

            Mecanico mecanico = Taller.BuscarMecanicoID(id);


            this.txtNombre.Text = mecanico.Nombre.ToString();
            this.txtCi.Text = mecanico.Ci.ToString();
            this.txtTelefono.Text = mecanico.Telefono.ToString();
            this.txtValorHora.Text = mecanico.ValorHora.ToString();


            btnAlta.Enabled = false;
            btnBaja.Enabled = true;
            btnModificar.Enabled = true;
        }
        protected void Limpiar_Click(object sender, EventArgs e)
        {
            Limpia();
        }
        #endregion

        #region ABM

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                string nombre = this.txtNombre.Text;
                int ci = int.Parse(this.txtCi.Text);
                string telefono = this.txtTelefono.Text;
                int valorHora = int.Parse(this.txtValorHora.Text);

                if (Taller.BuscarMecanicoCI(ci) == null)
                {
                    Mecanico unMecanico = new Mecanico(nombre, ci, telefono, valorHora);

                    if (Taller.AltaMecanico(unMecanico))
                    {
                        this.lblAlertas.Text = "Mecanico ingresado con éxito";
                        Limpia();
                        Listar();
                    }
                }
                else
                {
                    this.lblAlertas.Text = "Este Mecanico ya ha sido registrado";
                }
            }
            else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            int ci = int.Parse(this.txtCi.Text);
            if (Taller.BajaMecanico(ci))
            {
                this.lblAlertas.Text = "Mecanico dado de baja con éxito";
                Limpia();
                Listar();
            }
            else
            {
                this.lblAlertas.Text = "El Mecanico no existe";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                string nombre = this.txtNombre.Text;
                int ci = int.Parse(this.txtCi.Text);
                string telefono = this.txtTelefono.Text;
                int valorHora = int.Parse(this.txtValorHora.Text);

                Mecanico unMecanico = new Mecanico(nombre, ci, telefono, valorHora);

                if (Taller.ModificarMecanico(unMecanico))
                {
                    this.lblAlertas.Text = "Mecanico modificado con éxito";
                    Limpia();
                    Listar();
                }
            }
            else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }
        }

        #endregion
    }
}

