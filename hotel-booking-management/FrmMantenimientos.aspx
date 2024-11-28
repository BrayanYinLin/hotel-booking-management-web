<%@ Page Title="Mantenimientos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmMantenimientos.aspx.cs" Inherits="hotel_booking_management.FrmMantenimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Mantenimientos</h2>
    <p>Aquí podrá ver y actualizar los registros de mantenimiento de las habitaciones y otras áreas del hotel.</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <h3>Historial de Mantenimientos</h3>
    <table>
        <thead>
            <tr>
                <th>ID</th>
                <th>Descripción</th>
                <th>Fecha de Mantenimiento</th>
                <th>Estado</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>1</td>
                <td>Reparación de aire acondicionado</td>
                <td>01/10/2024</td>
                <td>Completado</td>
            </tr>
            <tr>
                <td>2</td>
                <td>Pintura de habitación 102</td>
                <td>03/10/2024</td>
                <td>En progreso</td>
            </tr>
            <!-- Añadir más mantenimientos según el sistema -->
        </tbody>
    </table>
</asp:Content>
