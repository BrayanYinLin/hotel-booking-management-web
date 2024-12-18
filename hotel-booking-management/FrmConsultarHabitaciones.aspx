<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmConsultarHabitaciones.aspx.cs" Inherits="hotel_booking_management.FrmConsultarHabitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <h2>
        Consultar Habitaciones</h2>
    <p>
        Aquí puede consultar las habitaciones filtrándolas a través de su tipo</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <table class="w-100">
        <tr>
            <td style="height: 29px">
                <h3>Listado de Habitaciones</h3>
            </td>
        </tr>
        <tr>
            <td>Seleccione tipo:<br />
                <div>

                    <asp:DropDownList ID="cboTipoHabitacion" runat="server">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnFiltrar" runat="server" Text="Button" OnClick="btnFiltrar_Click1" />

                </div>
            </td>
            <td>
                <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grvHabitaciones" runat="server" PageSize="20" Width="853px" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="habitacionId" HeaderText="ID Habitación" />
            <asp:BoundField DataField="habitacionNombre" HeaderText="Nombre Habitación" />
            <asp:BoundField DataField="habitacionAforo" HeaderText="Aforo" />
            <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
                <%# Convert.ToBoolean(Eval("estadoHabitacion")) ? "Activo" : "Inactivo" %>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
