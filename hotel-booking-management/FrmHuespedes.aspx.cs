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

                    // Obtén los datos solo una vez
                    var estadisticas = huespedBL.ObtenerEstadisticasPorMesHuesped();

                    // Agrega las series
                    graficohuesped.Series.Add("Masculino");
                    
                    graficohuesped.Series.Add("Femenino");

                    // Asocia los datos de las series con las listas correctas
                    graficohuesped.Series["Masculino"].Points.DataBindXY(
                        estadisticas, "MesCreacion", // Enlaza los meses
                        estadisticas, "TotalMasculinos" // Enlaza el total de masculinos
                    );

                    graficohuesped.Series["Femenino"].Points.DataBindXY(
                        estadisticas, "MesCreacion", // Enlaza los meses
                        estadisticas, "TotalFemeninos" // Enlaza el total de femeninos
                    );

                    // Configuración del gráfico
                    graficohuesped.Series["Masculino"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    graficohuesped.Series["Femenino"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn;

                    graficohuesped.Series["Masculino"].IsValueShownAsLabel = true;
                    graficohuesped.Series["Femenino"].IsValueShownAsLabel = true;

                    graficohuesped.ChartAreas[0].AxisX.Interval = 1;
                    graficohuesped.ChartAreas[0].AxisY.LabelStyle.Format = "#,0";

                    graficohuesped.ChartAreas[0].AxisX.Title = "Meses";
                    graficohuesped.ChartAreas[0].AxisY.Title = "Cantidad de Huéspedes";

                    graficohuesped.Legends.Add("Leyenda");
                    graficohuesped.Legends["Leyenda"].Docking = System.Web.UI.DataVisualization.Charting.Docking.Top;
                    graficohuesped.Legends["Leyenda"].Alignment = System.Drawing.StringAlignment.Center;

                    // Fuente de datos para el Grid
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