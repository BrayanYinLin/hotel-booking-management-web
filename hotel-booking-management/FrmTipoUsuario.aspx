<%@ Page Title="Gestionar Tipos de Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmTipoUsuario.aspx.cs" Inherits="hotel_booking_management.FrmTipoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Tipos de Usuario</h2>
    <p>Defina los diferentes tipos de usuario que tendrán acceso a la plataforma, como administrador, recepcionista, y más.</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <h3>Tipos de Usuario</h3>
    <table>
        <thead>
            <tr>
                <th>ID</th>
                <th>Tipo de Usuario</th>
                <th>Descripción</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>1</td>
                <td>Administrador</td>
                <td>Acceso total al sistema</td>
                <td><a href="#">Modificar</a> | <a href="#">Eliminar</a></td>
            </tr>
            <tr>
                <td>2</td>
                <td>Recepcionista</td>
                <td>Acceso a gestión de reservas y huéspedes</td>
                <td><a href="#">Modificar</a> | <a href="#">Eliminar</a></td>
            </tr>
            <!-- Más tipos de usuario -->
        </tbody>
    </table>
</asp:Content>
