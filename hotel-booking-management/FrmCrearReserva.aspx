<%@ Page Title="Gestionar Habitaciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHabitaciones.aspx.cs" Inherits="hotel_booking_management.FrmHabitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Habitaciones</h2>
    <p>En esta sección podrás visualizar y administrar las habitaciones del hotel. Puedes añadir nuevas habitaciones, modificar las existentes y gestionar su disponibilidad.</p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <h3>Listado de Habitaciones</h3>
    <table class="table">
        <thead>
            <tr>
                <th>ID Habitacion</th>
                <th>Nombre</th>
                <th>Capacidad</th>
                <th>Precio</th>
                <th>Estado</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>101</td>
                <td>Habitación Sencilla</td>
                <td>1 Persona</td>
                <td>$50/noche</td>
                <td>Disponible</td>
                <td><a href="#">Modificar</a> | <a href="#">Eliminar</a></td>
            </tr>
            <tr>
                <td>102</td>
                <td>Habitación Doble</td>
                <td>2 Personas</td>
                <td>$80/noche</td>
                <td>Ocupada</td>
                <td><a href="#">Modificar</a> | <a href="#">Eliminar</a></td>
            </tr>
            <tr>
                <td>103</td>
                <td>Suite Presidencial</td>
                <td>4 Personas</td>
                <td>$250/noche</td>
                <td>Disponible</td>
                <td><a href="#">Modificar</a> | <a href="#">Eliminar</a></td>
            </tr>
            <!-- Más habitaciones -->
        </tbody>
    </table>
    
    <h3>Añadir Nueva Habitación</h3>
    <p><a href="#">Haz clic aquí</a> para añadir una nueva habitación al sistema.</p>
</asp:Content>
