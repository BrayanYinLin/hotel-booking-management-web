using OfficeOpenXml;
using ProyHotel_BE;
using ProyHotel_BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hotel_booking_management
{
    public partial class FrmTipoUsuario : System.Web.UI.Page
    {
        TipoUsuarioBL tipoUsuarioBL = new TipoUsuarioBL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<TipoUsuarioBE> listaTipoUsuario = new List<TipoUsuarioBE>();
                if (!Page.IsPostBack)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    listaTipoUsuario = tipoUsuarioBL.ListarTipoUsuario();
                    gridUsersType.DataSource = listaTipoUsuario;
                    gridUsersType.DataBind();
                }

            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
            }
        }

        protected void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (textboxSearch.Text.Trim() == String.Empty)
                {
                    List<TipoUsuarioBE> todosTipoUsuario = new List<TipoUsuarioBE>();
                    todosTipoUsuario = tipoUsuarioBL.ListarTipoUsuario();
                    labelError.Text = "";
                    gridUsersType.DataSource = todosTipoUsuario;
                    gridUsersType.DataBind();
                    return;
                }

                List<TipoUsuarioBE> listaTipoUsuario = new List<TipoUsuarioBE>();
                TipoUsuarioBE tipoUsuarioBE = tipoUsuarioBL.BuscarTipoUsuarioPorNombre(textboxSearch.Text.Trim()) ?? throw new Exception("No se hallaron coincidencias");
                listaTipoUsuario.Add(tipoUsuarioBE);
                labelError.Text = "";
                gridUsersType.DataSource = listaTipoUsuario;
                gridUsersType.DataBind();
            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
            }
        }

        protected void buttonDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                string path = $"{Server.MapPath("/")}Plantillas/ListadoTipoUsuario.xlsx";
                List<TipoUsuarioBE> tipoUsuarioDescargados = new List<TipoUsuarioBE>();

                foreach (GridViewRow row in gridUsersType.Rows)
                {
                    TipoUsuarioBE servicio = new TipoUsuarioBE
                    {
                        tipoUsuarioId = int.Parse(row.Cells[0].Text),
                        tipoUsuarioDescripcion = row.Cells[1].Text
                    };
                    tipoUsuarioDescargados.Add(servicio);
                }

                int filaInicial = 5;
                using (var paquete = new OfficeOpenXml.ExcelPackage(new FileInfo(path)))
                {
                    string filename = $"ReporteTiposDeUsuario_{DateTime.Today.ToShortDateString()}";
                    //paquete.Workbook.Worksheets.Add("Servicios");
                    ExcelWorksheet worksheet = paquete.Workbook.Worksheets["Hoja1"];

                    foreach (TipoUsuarioBE item in tipoUsuarioDescargados)
                    {
                        worksheet.Cells[filaInicial, 1].Value = item.tipoUsuarioId.ToString();
                        worksheet.Cells[filaInicial, 2].Value = item.tipoUsuarioDescripcion.ToString();

                        filaInicial++;
                    }

                    worksheet.Column(1).Width = 20;
                    worksheet.Column(2).Width = 50;

                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", $"attachment; filename={filename}.xlsx");
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
                labelError.Text = ex.Message;
            }
        }

        protected void gridTipoUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsersType.PageIndex = e.NewPageIndex;
            gridUsersType.DataSource = tipoUsuarioBL.ListarTipoUsuario();
            gridUsersType.DataBind();
        }
    }
}