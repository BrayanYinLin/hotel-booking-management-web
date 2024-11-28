<%@ Page Title="Gestionar Servicios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmServicios.aspx.cs" Inherits="hotel_booking_management.FrmServicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Servicios</h2>
    <p>En esta sección puede agregar o eliminar los servicios disponibles para los huéspedes, como Wi-Fi, gimnasio, spa, etc.</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <h3>Lista de Servicios Disponibles</h3>
    <table>
        <thead>
            <tr>
                <th>ID</th>
                <th>Nombre del Servicio</th>
                <th>Descripción</th>
                <th>Precio</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>1</td>
                <td>Wi-Fi</td>
                <td>Conexión a internet de alta velocidad</td>
                <td>$10/día</td>
                <td><a href="#">Modificar</a> | <a href="#">Eliminar</a></td>
            </tr>
            <tr>
                <td>2</td>
                <td>Gimnasio</td>
                <td>Acceso al gimnasio 24/7</td>
                <td>$15/día</td>
                <td><a href="#">Modificar</a> | <a href="#">Eliminar</a></td>
            </tr>
            <!-- Más servicios -->
        </tbody>
    </table>
</asp:Content>
