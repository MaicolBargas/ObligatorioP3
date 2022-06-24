<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Taller_Mecanico.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 489px">
    <form id="form1" runat="server">
        <div style="height: 384px">

            Login<br />
            <br />
            Mail :
            <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
            <br />
            <br />
            Password :
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            Eres Admin?<br />
            Ingresa tu codigo de Admin
            <asp:TextBox ID="txtCodeAdmin" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Inicio Sesion" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Registrate" />
            <br />
            <br />
            <asp:Label ID="lblAlertas" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
