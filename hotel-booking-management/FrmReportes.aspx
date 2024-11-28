<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmReportes.aspx.cs" Inherits="hotel_booking_management.FrmReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Reportes de Actividades</h2>
    <p>Acceda a los reportes de reservas, ocupación de habitaciones y mantenimientos.</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <h3>Reportes Generados</h3>
    <table>
        <thead>
            <tr>
                <th>ID</th>
                <th>Tipo de Reporte</th>
                <th>Fecha</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>1</td>
                <td>Reporte de Ocupación</td>
                <td>01/11/2024</td>
                <td><a href="#">Ver</a></td>
            </tr>
            <tr>
                <td>2</td>
                <td>Reporte de Reservas</td>
                <td>02/11/2024</td>
                <td><a href="#">Ver</a></td>
            </tr>
            <!-- Añadir más reportes según disponibilidad -->
        </tbody>
    </table>
</asp:Content>
