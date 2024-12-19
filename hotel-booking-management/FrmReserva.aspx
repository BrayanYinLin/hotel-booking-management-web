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
        :root {
    --primary-color: #6366f1;
    --secondary-color: #4f46e5;
    --background-color: #f8fafc;
    --card-bg: rgba(255, 255, 255, 0.9);
    --text-color: #333;
    --table-bg: #fff;
}

.content-container {
    background: var(--card-bg);
    border-radius: 15px;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
    padding: 20px;
    width: 100%;
    max-width: 1200px;
    margin: 0 auto;
}

.section-title {
    font-size: 1.5rem;
    color: var(--primary-color);
    margin-bottom: 15px;
}

.search-bar {
    width: 100%;
    gap: 10px;
    display: flex;
    justify-content: space-between;
    margin-bottom: 20px;
}

.search-input-group {
    display: flex;
    flex-direction: column;
    flex: 1;
    margin-right: 10px;
}

.search-input {
    width: 100%;
    padding: 10px;
    border-radius: 10px;
    border: 2px solid #ccc;
    font-size: 1rem;
    transition: border-color 0.3s ease;
}

.search-input:focus {
    border-color: var(--primary-color);
    outline: none;
}

.btn-search {
    padding: 10px 20px;
    background: linear-gradient(135deg, var(--primary-color), var(--secondary-color));
    color: white;
    border: none;
    border-radius: 10px;
    font-size: 1rem;
    cursor: pointer;
    transition: background 0.3s ease;
}

.btn-search:hover {
    background: linear-gradient(135deg, var(--secondary-color), var(--primary-color));
}

.table-grid {
    width: 100%;
    border-collapse: collapse;
    border-radius: 10px;
    overflow: hidden;
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
}

.table-grid th, .table-grid td {
    padding: 12px;
    text-align: center;
    border: 1px solid #ddd;
}

.table-grid th {
    background-color: var(--primary-color);
    color: white;
    font-weight: bold;
}

.table-grid tr:nth-child(even) {
    background-color: #f9f9f9;
}

.table-grid tr:hover {
    background-color: #e7e7e7;
    cursor: pointer;
}

.table-grid td, .table-grid th {
    border-top: 1px solid #ccc;
}

@media (max-width: 768px) {
    .content-container {
        width: 90%;
    }

    .search-bar {
        flex-direction: column;
    }

    .search-input-group {
        margin-bottom: 10px;
    }

    .btn-search {
        width: 100%;
    }
}

    </style>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- Contenedor principal -->
            <div class="content-container">
                <!-- Título de la sección -->
                <h2 class="section-title">Consulta de Reservas</h2>

                <!-- Barra de búsqueda -->
                <div class="search-bar">
                    <div class="search-input-group">
                        <asp:Label ID="Label1" runat="server" Text="DNI:"></asp:Label>
                        <asp:TextBox ID="txtDni" runat="server" CssClass="search-input"></asp:TextBox>
                    </div>
                    <div class="search-input-group">
                        <asp:Label ID="Label2" runat="server" Text="Fecha Inicio: "></asp:Label>
                        <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="search-input"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" TargetControlID="txtFechaInicio" />
                    </div>
                    <div class="search-input-group">
                        <asp:Label ID="Label3" runat="server" Text="Fecha Fin: "></asp:Label>
                        <asp:TextBox ID="txtFin" runat="server" CssClass="search-input"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFin_CalendarExtender" runat="server" TargetControlID="txtFin" />
                    </div>
                    <div class="search-input-group">
                        <br />
                        <asp:Button ID="consultar" runat="server" OnClick="consultar_Click" Text="Consultar" CssClass="btn-search" />
                    </div>
                </div>

                <asp:Label ID="lblErrorMensaje" runat="server"></asp:Label>

                <!-- Tabla de resultados -->
                <br />
                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" CssClass="table-grid">
                    <Columns>
                        <asp:BoundField DataField="reservaId" HeaderText="Id Reserva" />
                        <asp:BoundField DataField="nombreReserva" HeaderText="A nombre de" />
                        <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="precio" HeaderText="Precio" />
                        <asp:BoundField DataField="creadoPor" HeaderText="Creado Por" />
                        <asp:BoundField DataField="fechaCreacion" HeaderText="Fecha Creacion" />
                        <asp:BoundField DataField="estado" HeaderText="Estado Pago" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />


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
