using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using ProyHotel_BE;
using ProyHotel_BL;
namespace hotel_booking_management
{
    public partial class FrmHuespedes : System.Web.UI.Page
    {
        HuespedBL huespedBL = new HuespedBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    gridHuespedes.DataSource = huespedBL.listarHuespedes();
                    gridHuespedes.DataBind();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("error: ",ex);
            }
        }

        private void CargarDatos()
        {
            gridHuespedes.DataSource = huespedBL.listarHuespedes();
            gridHuespedes.DataBind();
        }

        protected void gridHuespedes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridHuespedes.PageIndex = e.NewPageIndex;
            CargarDatos();
        }

        protected void btnBuscarPorNombre_Click(object sender, EventArgs e)
        {
            try
            {
                List<HuespedBE> buscarHuesped = new List<HuespedBE>();
                buscarHuesped.Add(huespedBL.BuscarHuespedPorNombre(txtNombre.Text));

                gridHuespedes.DataSource = buscarHuesped;
                gridHuespedes.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("error: ", ex);
            }
        }

        protected void btnDescargarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                List<HuespedBE> listHuespedes = huespedBL.listarHuespedes();
                string path = $"{Server.MapPath("/")}Plantillas/ListadoHuesped.xlsx";

                if (listHuespedes.Count == 0)
                {
                    throw new Exception("No hay Huespedes");
                }

                int filaInicial = 5;
                using (var paquete = new OfficeOpenXml.ExcelPackage(new FileInfo(path)))
                {
                    string filename = $"ReporteServicios_{DateTime.Today.ToShortDateString()}";
                    //paquete.Workbook.Worksheets.Add("Servicios");
                    ExcelWorksheet worksheet = paquete.Workbook.Worksheets["Hoja1"];

                    foreach (HuespedBE item in listHuespedes)
                    {
                        worksheet.Cells[filaInicial, 1].Value = item.huespedId;
                        worksheet.Cells[filaInicial, 2].Value = item.huespedNombre;
                        worksheet.Cells[filaInicial, 3].Value = item.huespedTelefono;
                        worksheet.Cells[filaInicial, 4].Value = item.huespedDni;
                        worksheet.Cells[filaInicial, 5].Value = item.huespedCorreo;
                        worksheet.Cells[filaInicial, 6].Value = item.huespedSexo;

                        filaInicial++;
                    }

                    worksheet.Column(1).Width = 20;
                    worksheet.Column(2).Width = 50;
                    worksheet.Column(3).Width = 20;
                    worksheet.Column(4).Width = 35;
                    worksheet.Column(5).Width = 30;
                    worksheet.Column(6).Width = 30;

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
    }
}