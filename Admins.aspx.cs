using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taller_Mecanico
{
    public partial class Admins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Links
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionUsuarios.aspx");
        }
        protected void linkProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionProveedores.aspx");

        }
        protected void linkRepuestos_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionRepuestos.aspx");

        }

        protected void linkVehiculos_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionVehiculos.aspx");

        }

        protected void linkMecanicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionMecanicos.aspx");

        }

        protected void linkReparaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionReparaciones.aspx");

        }
        protected void linkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        #endregion


    }
}