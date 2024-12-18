<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmTipoHabitacion.aspx.cs" Inherits="hotel_booking_management.FrmTipoHabitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Tipos de Habitcion</h2>
    <p>En esta seccion podrás gestionar los tipos de habitaciones con los que cuenta el hotel</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <style>
        header {
            margin: 10px 0;
            display: flex;
            justify-content: space-between;
        }

        #download-section {
            width: 100%;
            display: flex;
            margin: 10px 0;
            justify-content: flex-end;
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

        .search-input {
            width: 75%;
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

            .table-grid td,
            .table-grid th {
                border-top: 1px solid #ccc;
            }

        @media (max-width: 768px) {
            .content-container {
                width: 90%;
            }

            .search-bar {
                flex-direction: column;
            }

            .search-input {
                width: 100%;
                margin-bottom: 10px;
            }

            .btn-search {
                width: 100%;
            }
        }
        .btn-excel-download {
    display: inline-block;
    padding: 10px 20px;
    background: linear-gradient(135deg, #28a745, #218838); /* Verdes profesionales */
    color: #fff; /* Texto blanco */
    font-size: 1rem;
    font-weight: bold;
    text-align: center;
    text-decoration: none;
    border: none;
    border-radius: 8px;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    cursor: pointer;
    transition: background 0.3s ease, transform 0.2s ease;
}
    </style>
    <div class="content-container">
        <h3 class="section-title">Lista de Tipo de Habitaciones</h3>
        <asp:Label ID="labelError" runat="server" Text="" CssClass="badge text-bg-danger"></asp:Label>
        <header>
            <div class="search-bar">
                <asp:TextBox ID="textboxSearch" runat="server" CssClass="search-input" placeholder="Ingrese el tipo de habitacion"></asp:TextBox>
                <asp:Button ID="buttonReport" runat="server" Text="Buscar" CssClass="btn-search" OnClick="buttonReport_Click" />
                <asp:Button ID="buttonDescargar" runat="server" Text="Descargar" CssClass="btn-excel-download" OnClick="buttonDescargar_Click" />
            </div>
        </header>
        <asp:GridView ID="gridTypeRooms" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CssClass="table-grid" OnPageIndexChanging="gridTypeRooms_PageIndexChanging">
            <HeaderStyle Font-Bold="True" Font-Size="Large" />
            <Columns>
                <asp:BoundField DataField="tipoHabitacionId" HeaderText="Id" />
                <asp:BoundField DataField="tipoHabitacionDescripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="tipoHabitacionPrecio" HeaderText="Precio" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
