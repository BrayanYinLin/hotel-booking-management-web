<%@ Page Title="Gestionar Reservas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmReserva.aspx.cs" Inherits="hotel_booking_management.FrmReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Reservas</h2>
    <p>Desde esta sección podrás consultar y modificar las reservas realizadas por los huéspedes.</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <h3>Listado de Reservas</h3>
    <table>
        <thead>
            <tr>
                <th>ID Reserva</th>
                <th>Huésped</th>
                <th>Fecha de Entrada</th>
                <th>Fecha de Salida</th>
                <th>Estado</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>R-001</td>
                <td>Juan Pérez</td>
                <td>10/12/2024</td>
                <td>12/12/2024</td>
                <td>Confirmada</td>
                <td><a href="#">Ver detalles</a> | <a href="#">Modificar</a></td>
            </tr>
            <tr>
                <td>R-002</td>
                <td>Ana López</td>
                <td>15/12/2024</td>
                <td>18/12/2024</td>
                <td>Pendiente</td>
                <td><a href="#">Ver detalles</a> | <a href="#">Modificar</a></td>
            </tr>
            <!-- Más reservas -->
        </tbody>
    </table>
</asp:Content>
