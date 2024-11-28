<%@ Page Title="Gestionar Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmUsuarios.aspx.cs" Inherits="hotel_booking_management.FrmUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Usuarios</h2>
    <p>En esta sección podrás agregar, editar o eliminar usuarios del sistema.</p>
<style type="text/css">
    .auto-style1 {
        height: 23px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <h3>Listado de Usuarios</h3>
    <table>
        <thead>
            <tr>
                <th>ID</th>
                <th>Nombre</th>
                <th>Correo Electrónico</th>
                <th>Tipo de Usuario</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="auto-style1">1</td>
                <td class="auto-style1">Carlos Gómez</td>
                <td class="auto-style1">carlos@ejemplo.com</td>
                <td class="auto-style1">Administrador</td>
                <td class="auto-style1"><a href="#">Ver detalles</a> | <a href="#">Eliminar</a></td>
            </tr>
            <tr>
                <td>2</td>
                <td>María López</td>
                <td>maria@ejemplo.com</td>
                <td>Recepcionista</td>
                <td><a href="#">Ver detalles</a> | <a href="#">Eliminar</a></td>
            </tr>
            <!-- Más usuarios -->
        </tbody>
    </table>
</asp:Content>
