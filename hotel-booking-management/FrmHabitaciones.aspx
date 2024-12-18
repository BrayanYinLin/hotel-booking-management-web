<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHabitaciones.aspx.cs" Inherits="hotel_booking_management.FrmConsultarHabitaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Consultar Habitaciones</h2>
    <p>Aquí puede consultar las habitaciones filtrándolas a través de su tipo</p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <style>
        :root {
            --primary-color: #6366f1;
            --secondary-color: #4f46e5;
            --card-bg: rgba(255, 255, 255, 0.9);
        }

        .content-container {
            background: var(--card-bg);
            border-radius: 15px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
            padding: 20px;
            width: 100%;
            max-width: 1200px;
        }

        .section-title {
            font-size: 1.5rem;
            color: var(--primary-color);
            margin-bottom: 15px;
        }

        .lbl-message {
            margin-top: 15px;
            display: block;
            font-size: 1rem;
            color: var(--secondary-color);
            font-weight: bold;
        }

        .search-bar {
            width: 100%;
            gap: 5px;
            display: flex;
            justify-content: flex-start;
            margin-bottom: 10px;
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

        .btn-download {
            padding: 10px 20px;
            background: linear-gradient(135deg, #28a745, #218838);
            color: white;
            border: none;
            border-radius: 10px;
            font-size: 1rem;
            cursor: pointer;
            transition: background 0.3s ease, transform 0.2s ease;
        }

            .btn-download:hover {
                background: linear-gradient(135deg, #218838, #28a745);
            }


        .table-grid {
            width: 100%;
            border-collapse: collapse;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
        }

            .table-grid th,
            .table-grid td {
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

        .custom-select {
            width: 100%;
            padding: 10px 15px;
            border: 2px solid #ccc;
            border-radius: 8px;
            background-color: #f8f9fa;
            color: #333;
            font-size: 1rem;
            font-family: Arial, sans-serif;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            appearance: none;
            cursor: pointer;
            transition: border-color 0.3s, box-shadow 0.3s;
        }

            .custom-select:hover {
                border-color: #6366f1;
                box-shadow: 0 4px 10px rgba(99, 102, 241, 0.2);
            }

            .custom-select:focus {
                outline: none;
                border-color: #4f46e5;
                box-shadow: 0 0 8px rgba(79, 70, 229, 0.5);
            }

            .custom-select option {
                padding: 10px;
                background-color: #fff;
                color: #333;
            }

        .graphic {
            display: flex;
            justify-content: center;
        }
    </style>

    <div class="content-container">
        <h3 class="section-title">Listado de Habitaciones</h3>
        <p class="section-title">
            <asp:Label ID="labelError" runat="server" CssClass="badge text-bg-danger"></asp:Label>
        </p>
        <asp:Label ID="lblMensaje" runat="server" CssClass="lbl-message"></asp:Label>

        <!-- Barra de búsqueda -->
        <div class="search-bar">
            <asp:DropDownList ID="cboTipoHabitacion" runat="server" CssClass="search-input"></asp:DropDownList>
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn-search" OnClick="btnFiltrar_Click" />
            <asp:Button ID="btnDescargar" runat="server" Text="Descargar" CssClass="btn-download" OnClick="btnDescargar_Click" />
        </div>

        <!-- Tabla de habitaciones -->
        <asp:GridView ID="grvHabitaciones" runat="server" PageSize="20" AutoGenerateColumns="False" CssClass="table-grid">
            <Columns>
                <asp:BoundField DataField="habitacionId" HeaderText="ID Habitación" />
                <asp:BoundField DataField="habitacionNombre" HeaderText="Nombre Habitación" />
                <asp:BoundField DataField="habitacionAforo" HeaderText="Aforo" />
                <asp:BoundField DataField="estadoHabitacionString" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div class="graphic">
        <asp:Chart ID="ChartHabitaciones" runat="server" Width="653px">
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY Title="Aforo">
                    </AxisY>
                    <AxisX Title="Habitaciones">
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    <br />
</asp:Content>
