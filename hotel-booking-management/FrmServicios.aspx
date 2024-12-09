<%@ Page Title="Gestionar Servicios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmServicios.aspx.cs" Inherits="hotel_booking_management.FrmServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Servicios</h2>
    <p>En esta sección puede agregar o eliminar los servicios disponibles para los huéspedes, como Wi-Fi, gimnasio, spa, etc.</p>
    <asp:Label ID="labelError" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <style>
        header {
            margin: 10px 0;
            display: flex;
            justify-content: space-between;
        }
    </style>
    <header>
        <h3>Lista de Servicios Disponibles</h3>
        <div>
            <asp:TextBox ID="textboxSearch" runat="server"></asp:TextBox>
<asp:Button ID="buttonReport" runat="server" Text="Buscar" CssClass="btn btn-outline-dark" OnClick="buttonReport_Click" />
        </div>
    </header>
    <div>
        <asp:Button ID="buttonDescargar" runat="server" Text="Descargar" CssClass="btn btn-outline-dark" OnClick="buttonDescargar_Click" />
    </div>
    <asp:GridView ID="gridServices" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="bg-transparent border border-dark rounded">
        <HeaderStyle Font-Bold="True" Font-Size="Large" />
        <Columns>
            <asp:BoundField DataField="servicioId" HeaderText="Id" />
            <asp:BoundField DataField="servicioDescripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="servicioPrecio" HeaderText="Precio" />
            <asp:BoundField DataField="servicioFechaCreacion" HeaderText="Fecha Creacion" />
            <asp:BoundField DataField="servicioEstado" HeaderText="Estado" />
        </Columns>
    </asp:GridView>
</asp:Content>
