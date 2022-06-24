using Dominio;
using Controladoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Taller_Mecanico
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool FaltanDatos()
        {
            if (this.txtMail.Text == "" || this.txtPassword.Text == "" || this.txtNombre.Text == "" || this.txtCi.Text == "" || this.txtTelefono.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
           Taller taller = new Taller();

            if(!FaltanDatos())
            {
                string nombre = this.txtNombre.Text;
                int ci = int.Parse(this.txtCi.Text);
                string telefono = this.txtTelefono.Text;
                string mail = this.txtMail.Text;
                string password = this.txtPassword.Text;

                if (Taller.BuscarUsuarioCI(ci) == null)
                {
                    Usuario unUsuario = new Usuario(nombre, ci, telefono, mail, password);

                    if (Taller.AltaUsuario(unUsuario))
                    {
                        Session["Nombre"] = nombre;
                        Session["ci"] = ci;

                        Response.Redirect("Users.aspx");
                    }
                }
                else
                {
                    this.lblAlertas.Text = "Este usuario ya ha sido registrado";
                }
                    


            }
            else{ this.lblAlertas.Text = "Debe ingresar todos los datos"; }

        }
    }
}