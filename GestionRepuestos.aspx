<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionRepuestos.aspx.cs" Inherits="Taller_Mecanico.GestionRepuestos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 417px">
    <form id="form1" runat="server">
        <div style="height: 370px">
            <asp:LinkButton ID="linkMenu" runat="server" OnClick="linkMenu_Click">Menu</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Gestion Repuestos"></asp:Label>
            <br />
            <br />
            Id:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            Descripcion:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <br />
            Costo:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCosto" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblAlertas" runat="server"></asp:Label>
            <br />
            Tipo:&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="txtTipo" runat="server" Height="23px" Width="158px">
                <asp:ListItem Value="M">Motor</asp:ListItem>
                <asp:ListItem Value="C">Carrocería</asp:ListItem>
                <asp:ListItem Value="L">Lubricación</asp:ListItem>
                <asp:ListItem Value="V">Varios</asp:ListItem>
            </asp:DropDownList>
            <br />
            Proovedor:&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtProveedor" runat="server">
            </asp:DropDownList>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBaja" runat="server" Text="Baja" OnClick="btnBaja_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />


             <br />


             <asp:GridView ID="GridRepuestos" runat="server" AutoGenerateColumns ="false " Width="888px" >
                <Columns>
                    <asp:BoundField DataField="IdRepuesto" HeaderText="Id" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="Costo" HeaderText="Costo" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkView" runat="server" CommandArgument='<%# Eval("IdRepuesto") %>' OnClick="link_OnClick" >Seleccionar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>


        </div>
    </form>
</body>
</html>
