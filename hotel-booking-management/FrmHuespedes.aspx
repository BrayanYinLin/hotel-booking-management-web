<%@ Page Title="Gestionar Huéspedes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHuespedes.aspx.cs" Inherits="hotel_booking_management.FrmHuespedes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Huéspedes</h2>
    <p>Aquí puede ver los huéspedes registrados y sus datos de contacto.</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <h3>Listado de Huéspedes</h3>
    <table>
        <thead>
            <tr>
                <th>ID</th>
                <th>Nombre</th>
                <th>Email</th>
                <th>Teléfono</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>1</td>
                <td>Juan Pérez</td>
                <td>juan@example.com</td>
                <td>+1 234 567 890</td>
                <td><a href="#">Ver detalles</a> | <a href="#">Eliminar</a></td>
            </tr>
            <tr>
                <td>2</td>
                <td>Ana López</td>
                <td>ana@example.com</td>
                <td>+1 234 567 891</td>
                <td><a href="#">Ver detalles</a> | <a href="#">Eliminar</a></td>
            </tr>
            <!-- Añadir más huéspedes según sea necesario -->
        </tbody>
    </table>
</asp:Content>
