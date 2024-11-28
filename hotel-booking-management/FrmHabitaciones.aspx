<%@ Page Title="Gestionar Habitaciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHabitaciones.aspx.cs" Inherits="hotel_booking_management.FrmHabitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Habitaciones</h2>
    <p>Aquí puede ver, agregar o modificar las habitaciones disponibles en el hotel.</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <h3>Listado de Habitaciones</h3>
    <table>
        <thead>
            <tr>
                <th>ID</th>
                <th>Nombre de la Habitación</th>
                <th>Estado</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>101</td>
                <td>Habitación 101</td>
                <td>Disponible</td>
                <td><a href="#">Modificar</a> | <a href="#">Eliminar</a></td>
            </tr>
            <tr>
                <td>102</td>
                <td>Habitación 102</td>
                <td>Ocupada</td>
                <td><a href="#">Modificar</a> | <a href="#">Eliminar</a></td>
            </tr>
            <!-- Añadir más habitaciones según el sistema -->
        </tbody>
    </table>
</asp:Content>
