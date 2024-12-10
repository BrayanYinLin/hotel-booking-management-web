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
    public partial class FrmServicios : System.Web.UI.Page
    {
        ServicioBL servicioBL = new ServicioBL();
        List<ServicioBE> listServices = new List<ServicioBE>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    listServices = servicioBL.ListarServicio();
                    gridServices.DataSource = listServices;
                    gridServices.DataBind();
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
                listServices = new List<ServicioBE>();
                ServicioBE targetService = servicioBL.BuscarServicioPorNombre(textboxSearch.Text.Trim());
                if (targetService == null)
                {
                    throw new Exception("No se hallaron coincidencias");
                }
                listServices.Add(targetService);
                labelError.Text = "";

                gridServices.DataSource = listServices;
                gridServices.DataBind();
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
                List<ServicioBE> serviciosDescargados = new List<ServicioBE>();

                foreach (GridViewRow row in gridServices.Rows)
                {
                    ServicioBE servicio = new ServicioBE
                    {
                        servicioId = int.Parse(row.Cells[0].Text),
                        servicioDescripcion = row.Cells[1].Text,
                        servicioPrecio = Convert.ToSingle(row.Cells[2].Text),
                        servicioFechaCreacion = (DateTime)(row.Cells[3].Text == "---" ? (DateTime?)null : DateTime.Parse(row.Cells[3].Text)),
                        servicioEstado = row.Cells[4].Text
                    };
                    serviciosDescargados.Add(servicio);
                }

                int filaInicial = 5;
                using (var paquete = new OfficeOpenXml.ExcelPackage(new FileInfo(path)))
                {
                    string filename = $"ReporteServicios_{DateTime.Today.ToShortDateString()}";
                    //paquete.Workbook.Worksheets.Add("Servicios");
                    ExcelWorksheet worksheet = paquete.Workbook.Worksheets["Hoja1"];

                    foreach (ServicioBE item in serviciosDescargados)
                    {
                        worksheet.Cells[filaInicial, 1].Value = item.servicioId.ToString();
                        worksheet.Cells[filaInicial, 2].Value = item.servicioDescripcion.ToString();
                        worksheet.Cells[filaInicial, 3].Value = item.servicioPrecio.ToString("C2");

                        if (item.servicioFechaCreacion == null)
                        {
                            worksheet.Cells[filaInicial, 4].Value = "---";
                        } else
                        {
                            worksheet.Cells[filaInicial, 4].Value = Convert.ToDateTime(item.servicioFechaCreacion).ToShortDateString();
                        }

                        worksheet.Cells[filaInicial, 5].Value = item.servicioEstado.ToString();
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

        protected void gridServicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridServices.PageIndex = e.NewPageIndex;
            gridServices.DataSource = servicioBL.ListarServicio();
            gridServices.DataBind();
        }
    }
}