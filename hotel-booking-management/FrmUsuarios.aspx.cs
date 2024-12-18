using OfficeOpenXml;
using ProyHotel_BE;
using ProyHotel_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hotel_booking_management
{
    public partial class FrmUsuarios : System.Web.UI.Page
    {
        UsuarioBL usuarioBL = new UsuarioBL();
        List<UsuarioBE> listUsuarios = new List<UsuarioBE>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    listUsuarios = usuarioBL.ListarUsuarios();
                    grvUsuarios.DataSource = listUsuarios;
                    grvUsuarios.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.Visible = true;
            }
        }

        private void CargarDatos(string filtro)
        {
            try
            {
                listUsuarios = usuarioBL.ListarUsuarios().Where(user => user.usuarioNombre.ToLower().Contains(filtro.ToLower())).ToList();
                grvUsuarios.DataSource = listUsuarios;
                grvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.Visible = true;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos(txtFiltro.Text);
        }

        protected void grvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvUsuarios.PageIndex = e.NewPageIndex;
            CargarDatos(txtFiltro.Text);
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("~/Plantillas/ListadoUsuario.xlsx");
                List<UsuarioBE> usuariosDescargados = usuarioBL.ListarUsuarios();

                if (usuariosDescargados.Count == 0)
                {
                    lblMensaje.Text = "No hay usuarios para generar el reporte.";
                    lblMensaje.Visible = true;
                    return;
                }

                using (var paquete = new ExcelPackage(new FileInfo(path)))
                {
                    // Verificar si la hoja de trabajo existe y crearla si es necesario
                    ExcelWorksheet worksheet = paquete.Workbook.Worksheets["Hoja1"] ?? paquete.Workbook.Worksheets.Add("Hoja1");

                    int filaInicial = 5;
                    foreach (var usuario in usuariosDescargados)
                    {
                        worksheet.Cells[filaInicial, 1].Value = usuario.usuarioId.ToString();
                        worksheet.Cells[filaInicial, 2].Value = usuario.usuarioNombre;
                        worksheet.Cells[filaInicial, 3].Value = usuario.usuarioCorreo;
                        worksheet.Cells[filaInicial, 4].Value = usuario.usuarioClave;
                        worksheet.Cells[filaInicial, 5].Value = usuario.usuarioTipo;
                        worksheet.Cells[filaInicial, 6].Value = usuario.usuarioEstado ? "Activo" : "Inactivo";
                        filaInicial++;
                    }

                    worksheet.Column(1).Width = 20;
                    worksheet.Column(2).Width = 30;
                    worksheet.Column(3).Width = 30;
                    worksheet.Column(4).Width = 30;
                    worksheet.Column(5).Width = 30;
                    worksheet.Column(6).Width = 20;

                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", $"attachment; filename=ReporteUsuarios_{DateTime.Today.ToShortDateString()}.xlsx");
                    using (var memoryStreamPackage = new MemoryStream())
                    {
                        paquete.SaveAs(memoryStreamPackage);
                        memoryStreamPackage.WriteTo(Response.OutputStream);
                    }
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.Visible = true;
            }
        }

    }
}
