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
    public partial class GestionVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar();
                ListarUsuario();
                btnAlta.Enabled = true;
                btnBaja.Enabled = false;
                btnModificar.Enabled = false;
            }
            
        }

        #region Funciones Auxiliares
        protected void Listar()
        {
            GridVehiculos.DataSource = Taller.MostrarVehiculo();
            GridVehiculos.DataBind();
        }

        protected void Limpiar()
        {
            this.txtMatricula.Text = "";
            this.txtMarca.Text = "";
            this.txtModelo.Text = "";
            this.txtAnio.Text = "";
            this.txtColor.Text = "";
            this.txtDueno.SelectedValue = null;

            btnAlta.Enabled = true;
            btnBaja.Enabled = false;
            btnModificar.Enabled = false;
        }
         protected void linkMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admins.aspx");
        }
        protected void ListarUsuario()
        {
            txtDueno.DataSource = Taller.MostrarUsuario();
            txtDueno.DataTextField = "Nombre";
            txtDueno.DataValueField = "IdUsuario";
            txtDueno.DataBind();
            txtDueno.Items.Insert(0, new ListItem("<Seleccionar Dueño>", "0"));
        }
        private bool FaltanDatos()
        {
            if (this.txtMatricula.Text == "" || this.txtMarca.Text == "" || this.txtAnio.Text == "" || this.txtColor.Text == "" || this.txtDueno.Text == "")
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

            Vehiculo vehiculo = Taller.BuscarVehiculoId(id);

            this.txtMatricula.Text = vehiculo.Matricula.ToString();
            this.txtMarca.Text = vehiculo.Marca.ToString();
            this.txtModelo.Text = vehiculo.Modelo.ToString();
            this.txtAnio.Text = vehiculo.Anio.ToString();
            this.txtColor.Text = vehiculo.Color.ToString();
            this.txtDueno.Text = vehiculo.DuenoVehiculo.ToString();

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
                string matricula = this.txtMatricula.Text;
                string marca = this.txtMarca.Text;
                string modelo = this.txtModelo.Text;
                int anio = int.Parse(this.txtAnio.Text);
                string color = this.txtColor.Text;
                int dueno = int.Parse(this.txtDueno.Text);
                
                if (Taller.BuscarVehiculoMatricula(matricula) == null)
                {
                    Vehiculo unVehiculo = new Vehiculo(matricula, marca, modelo, anio, color, dueno);

                    if (Taller.AltaVehiculo(unVehiculo))
                    {
                        this.lblAlertas.Text = "Vehiculo ingresado con éxito";
                        Limpiar();
                        Listar();
                    }
                }
                else
                {
                    this.lblAlertas.Text = "Este Vehiculo ya ha sido registrado";
                }
            }
            else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            string matricula = this.txtMatricula.Text;
            if (Taller.BajaVehiculo(matricula))
            {
                this.lblAlertas.Text = "Vehiculo dado de baja con éxito";
                Limpiar();
                Listar();
            }
            else
            {
                this.lblAlertas.Text = "El Vehiculo no existe";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {

                string matricula = this.txtMatricula.Text;
                string marca = this.txtMarca.Text;
                string modelo = this.txtModelo.Text;
                int anio = int.Parse(this.txtAnio.Text);
                string color = this.txtColor.Text;
                int dueno = int.Parse(this.txtDueno.Text);

                Vehiculo unVehiculo = new Vehiculo(matricula, marca, modelo, anio, color, dueno);

                if (Taller.ModificarVehiculo(unVehiculo))
                {
                    this.lblAlertas.Text = "Vehiculo modificado con éxito";
                    Limpiar();
                    Listar();
                }
            }
            else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }
        }
        #endregion
    }
}
