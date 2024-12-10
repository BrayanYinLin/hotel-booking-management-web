<%@ Page Title="Gestionar Huéspedes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHuespedes.aspx.cs" Inherits="hotel_booking_management.FrmHuespedes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Huéspedes</h2>
    <p>Aquí puede ver los huéspedes registrados y sus datos de contacto.</p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <div class="content-container">
        <h3 class="section-title">Listado de Huéspedes</h3>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="search-bar">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="search-input" placeholder="Ingrese el nombre" />
                    <asp:Button ID="btnBuscarPorNombre" runat="server" Text="Buscar" CssClass="btn-search" OnClick="btnBuscarPorNombre_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btnDescargarExcel" runat="server" Text="Descargar Excel" CssClass="btn-excel-download" OnClick="btnDescargarExcel_Click" />
                </div>
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false"></asp:Label>

                <asp:GridView ID="gridHuespedes" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" CellPadding="4" OnPageIndexChanging="gridHuespedes_PageIndexChanging" CssClass="table-grid">
                    <Columns>
                        <asp:BoundField DataField="huespedId" HeaderText="Id" />
                        <asp:BoundField DataField="huespedNombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="huespedTelefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="HuespedDni" HeaderText="DNI" />
                        <asp:BoundField DataField="huespedCorreo" HeaderText="Correo" />
                        <asp:BoundField DataField="huespedSexo" HeaderText="Sexo" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!-- Estilos solo para el ContentPlaceHolderID="Principal" -->
    <style>
        .btn-excel-download {
        display: inline-block;
        padding: 10px 20px;
        background: linear-gradient(135deg, #28a745, #218838); 
        color: #fff; 
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

        .btn-excel-download:hover {
            background: linear-gradient(135deg, #218838, #1e7e34);
            transform: translateY(-2px); 
        }

        .btn-excel-download:active {
            background: #1e7e34; 
            transform: translateY(0); 
        }

    
        .btn-excel-download i {
            margin-right: 8px;
            font-size: 1.2rem;
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
    </style>
    </asp:Content>