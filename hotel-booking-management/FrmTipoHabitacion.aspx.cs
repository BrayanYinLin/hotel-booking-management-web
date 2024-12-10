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
    public partial class FrmTipoHabitacion : System.Web.UI.Page
    {
        TipoHabitacionBL tipoHabitacionBL = new TipoHabitacionBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<TipoHabitacionBE> listadoTipoHabitacion = new List<TipoHabitacionBE>();
                if (!Page.IsPostBack)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    listadoTipoHabitacion = tipoHabitacionBL.ListarTipoHabitacion();
                    gridTypeRooms.DataSource = listadoTipoHabitacion;
                    gridTypeRooms.DataBind();
                }

            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
            }
        }

        protected void buttonReport_Click(object sender, EventArgs e)
        {
            try
            {
                List<TipoHabitacionBE> listadoTipoHabitaciones = new List<TipoHabitacionBE>();
                TipoHabitacionBE targetService = tipoHabitacionBL.BuscarTipoHabitacionPorNombre(textboxSearch.Text.Trim());
                if (targetService == null)
                {
                    throw new Exception("No se hallaron coincidencias");
                }
                listadoTipoHabitaciones.Add(targetService);
                labelError.Text = "";

                gridTypeRooms.DataSource = listadoTipoHabitaciones;
                gridTypeRooms.DataBind();
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
                string path = $"{Server.MapPath("/")}Plantillas/ListadoServicio.xlsx";
                List<TipoHabitacionBE> tipoHabitacionesDescargadas = new List<TipoHabitacionBE>();

                foreach (GridViewRow row in gridTypeRooms.Rows)
                {
                    TipoHabitacionBE tipoHabitacion = new TipoHabitacionBE
                    {
                        tipoHabitacionId = int.Parse(row.Cells[0].Text),
                        tipoHabitacionDescripcion = row.Cells[1].Text,
                        tipoHabitacionPrecio = Convert.ToSingle(row.Cells[2].Text)
                    };
                    tipoHabitacionesDescargadas.Add(tipoHabitacion);
                }

                int filaInicial = 5;
                using (var paquete = new OfficeOpenXml.ExcelPackage(new FileInfo(path)))
                {
                    string filename = $"ReporteServicios_{DateTime.Today.ToShortDateString()}";
                    //paquete.Workbook.Worksheets.Add("Servicios");
                    ExcelWorksheet worksheet = paquete.Workbook.Worksheets["Hoja1"];

                    foreach (TipoHabitacionBE item in tipoHabitacionesDescargadas)
                    {
                        worksheet.Cells[filaInicial, 1].Value = item.tipoHabitacionId.ToString();
                        worksheet.Cells[filaInicial, 2].Value = item.tipoHabitacionDescripcion.ToString();
                        worksheet.Cells[filaInicial, 3].Value = item.tipoHabitacionPrecio.ToString("C2");
                        filaInicial++;
                    }

                    worksheet.Column(1).Width = 20;
                    worksheet.Column(2).Width = 50;
                    worksheet.Column(3).Width = 20;
                    worksheet.Column(4).Width = 35;
                    worksheet.Column(5).Width = 30;

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


        protected void gridTypeRooms_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridTypeRooms.PageIndex = e.NewPageIndex;
            gridTypeRooms.DataSource = tipoHabitacionBL.ListarTipoHabitacion();
            gridTypeRooms.DataBind();
        }
    }
}