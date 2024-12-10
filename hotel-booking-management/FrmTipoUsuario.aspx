<%@ Page Title="Gestionar Tipos de Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmTipoUsuario.aspx.cs" Inherits="hotel_booking_management.FrmTipoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Tipos de Usuario</h2>
    <p>Defina los diferentes tipos de usuario que tendrán acceso a la plataforma, como administrador, recepcionista, y más.</p>
    <asp:Label ID="labelError" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
        <style>
        header {
            margin: 10px 0;
            display: flex;
            justify-content: space-between;
        }

        #download-section {
            width: 100%;
            margin: 10px 0;
            justify-content: flex-end;
        }
    </style>
    <header>
        <h3>Tipos de Usuario</h3>
        <div>
            <asp:TextBox ID="textboxSearch" runat="server"></asp:TextBox>
<asp:Button ID="buttonSearch" runat="server" Text="Buscar" CssClass="btn btn-outline-dark" OnClick="buttonSearch_Click" />
        </div>
    </header>
    <div id="download-section">
        <asp:Button ID="buttonDescargar" runat="server" Text="Descargar" CssClass="btn btn-outline-dark" OnClick="buttonDescargar_Click" />
    </div>
    <asp:GridView ID="gridUsersType" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="bg-transparent border border-dark rounded">
    <HeaderStyle Font-Bold="True" Font-Size="Large" />
    <Columns>
        <asp:BoundField DataField="tipoUsuarioId" HeaderText="Id" />
        <asp:BoundField DataField="tipoUsuarioDescripcion" HeaderText="Descripcion" />
    </Columns>
</asp:GridView>
</asp:Content>
