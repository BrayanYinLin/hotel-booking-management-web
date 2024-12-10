<%@ Page Title="Gestionar Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmUsuarios.aspx.cs" Inherits="hotel_booking_management.FrmUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>Gestionar Usuarios</h2>
    <p>Defina los diferentes tipos de usuario que tendrán acceso a la plataforma, como administrador, recepcionista, y más.</p>
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
    <div class="content-container">
        <h3 class="section-title">Usuarios</h3>
        <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="badge text-bg-danger" Visible="false"></asp:Label>
        <header>
            <div class="search-bar">
                <asp:TextBox ID="txtFiltro" runat="server" CssClass="search-input" placeholder="Buscar por nombre"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-search" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnDescargar" runat="server" Text="Descargar" CssClass="btn-excel-download" OnClick="btnDescargar_Click" />
            </div>
        </header>
        <asp:GridView ID="grvUsuarios" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CssClass="table-grid" OnPageIndexChanging="grvUsuarios_PageIndexChanging">
            <HeaderStyle Font-Bold="True" Font-Size="Large" />
            <Columns>
                <asp:BoundField DataField="usuarioId" HeaderText="Id" />
                <asp:BoundField DataField="usuarioNombre" HeaderText="Nombre" />
                <asp:BoundField DataField="usuarioCorreo" HeaderText="Correo Electrónico" />
                <asp:BoundField DataField="usuarioClave" HeaderText="Contraseña" />
                <asp:BoundField DataField="usuarioTipoId" HeaderText="Tipo de Usuario" />
                <asp:BoundField DataField="usuarioEstado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
