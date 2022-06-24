<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admins.aspx.cs" Inherits="Taller_Mecanico.Admins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 492px">
    <form id="form1" runat="server">
        <div style="height: 432px; ">
            <asp:LinkButton ID="linkUsuarios" runat="server" OnClick="LinkButton1_Click">Gestion Usuarios</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="linkProveedores" runat="server" OnClick="linkProveedores_Click" >Gestion Proveedores</asp:LinkButton>
    
            &nbsp;&nbsp;&nbsp;
    
            <asp:LinkButton ID="linkRepuestos" runat="server" OnClick="linkRepuestos_Click">Gestion Repuestos</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="linkVehiculos" runat="server" OnClick="linkVehiculos_Click">Gestion Vehiculos</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="linkMecanicos" runat="server" OnClick="linkMecanicos_Click">Gestion Mecanicos</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="linkReparaciones" runat="server" OnClick="linkReparaciones_Click">Gestion Reparaciones</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="linkLogin" runat="server" OnClick="linkLogin_Click">Cerrar Sesion</asp:LinkButton>
&nbsp;<hr />
        </div>
    </form>
</body>
</html>
