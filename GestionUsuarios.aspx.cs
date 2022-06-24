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
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
            GridUsuarios.DataSource = Taller.MostrarUsuario();
            GridUsuarios.DataBind();
         }

        protected void Limpiar()
        {
            this.txtMail.Text = "";
            this.txtPassword.Text = "";
            this.txtNombre.Text = "";
            this.txtCI.Text = "";
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
                    if (this.txtMail.Text == "" || this.txtPassword.Text == "" || this.txtNombre.Text == "" || this.txtCI.Text == "" || this.txtTelefono.Text == "")
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

                    Usuario usuario = Taller.BuscarUsuarioID(id);


                    this.txtNombre.Text = usuario.Nombre.ToString();
                    this.txtCI.Text = usuario.Ci.ToString();
                    this.txtTelefono.Text = usuario.Telefono.ToString();
                    this.txtMail.Text = usuario.Mail.ToString();
                    this.txtPassword.Text = usuario.Password.ToString();

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
                    string nombre = this.txtNombre.Text;
                    int ci = int.Parse(this.txtCI.Text);
                    string telefono = this.txtTelefono.Text;
                    string mail = this.txtMail.Text;
                    string password = this.txtPassword.Text;

                    if (Taller.BuscarUsuarioCI(ci) == null)
                    {
                        Usuario unUsuario = new Usuario(nombre, ci, telefono, mail, password);

                        if (Taller.AltaUsuario(unUsuario))
                        {
                            this.lblAlertas.Text = "Usuario ingresado con éxito";
                            Limpiar();
                            Listar();
                        }
                    }
                    else
                    {
                        this.lblAlertas.Text = "Este usuario ya ha sido registrado";
                    }
                }
                else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }
            }

            protected void btnBaja_Click(object sender, EventArgs e)
            {

                int ci = int.Parse(this.txtCI.Text);
                if(Taller.BajaUsuario(ci))
                {
                    this.lblAlertas.Text = "Usuario dado de baja con éxito";
                    Limpiar();
                    Listar();
                }
                else
                {
                    this.lblAlertas.Text = "El usuario no existe";
                }
            }

            protected void btnModificar_Click(object sender, EventArgs e)
            {
                if(!FaltanDatos())
                {
                    string nombre = this.txtNombre.Text;
                    int ci = int.Parse(this.txtCI.Text);
                    string telefono = this.txtTelefono.Text;
                    string mail = this.txtMail.Text;
                    string password = this.txtPassword.Text;

                    Usuario user = new Usuario(nombre, ci, telefono, mail, password);

                    if(Taller.ModificarUsuario(user))
                    {
                        this.lblAlertas.Text = "Usuario modificado con éxito";
                        Limpiar();
                        Listar();
                    }
                }
                else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }
            }
        #endregion
        


    }
}