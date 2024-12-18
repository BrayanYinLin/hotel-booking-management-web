<%@ Page Title="Gestionar Reservas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmReserva.aspx.cs" Inherits="hotel_booking_management.FrmReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Reservas</h2>
    <p>Desde esta sección podrás consultar y modificar las reservas realizadas por los huéspedes.</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <style>
        
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f9f9f9;
        }

        h3, h4 {
            text-align: center;
            color: #2c3e50;
        }

        
        .chart-container {
            max-width: 900px;
            margin: 20px auto;
            padding: 20px;
            background-color: #ffffff;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        .chart {
            margin: 20px 0;
        }

       
        .chart + .chart {
            margin-top: 40px;
        }

        h4 {
            margin-bottom: 20px;
            font-size: 1.2rem;
            color: #34495e;
        }
    </style>

    <div class="chart-container">
        <h3>Gráficas de Reservas</h3>

        <div class="chart">
            <h4>Importe mensual por reserva</h4>
            <asp:Chart ID="graficoReserva" runat="server" Width="850px">
                <Series>
                    <asp:Series Name="Series1" ChartType="Column" Color="#3498db" />
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="Mes" TitleFont="Arial, 12pt, style=Bold" />
                        <AxisY Title="Importe Total" TitleFont="Arial, 12pt, style=Bold" />
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>

        <div class="chart">
            <h4>Cantidad de reservas por mes</h4>
            <asp:Chart ID="GraficoCantidadReservas" runat="server" Width="850px">
                <Series>
                    <asp:Series Name="Series1" ChartType="Line" BorderWidth="2" Color="#2ecc71" />
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="Mes" TitleFont="Arial, 12pt, style=Bold" />
                        <AxisY Title="Cantidad de Reservas" TitleFont="Arial, 12pt, style=Bold" />
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>
</asp:Content>
