using OfficeOpenXml;
using ProyHotel_BE;
using ProyHotel_BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace hotel_booking_management
{
    public partial class FrmConsultarHabitaciones : System.Web.UI.Page
    {
        HabitacionBL habitacionBL = new HabitacionBL();
        TipoHabitacionBL tipoHabitacionBL = new TipoHabitacionBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    CargarTiposHabitacion();
                    CargarHabitaciones(0);
                    cargarDatosGrafico();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        private void CargarTiposHabitacion()
        {
            try
            {
                List<TipoHabitacionBE> listaTipos = tipoHabitacionBL.ListarTipoHabitacion();

                TipoHabitacionBE opcionInicial = new TipoHabitacionBE
                {
                    tipoHabitacionId = 0,
                    tipoHabitacionDescripcion = "--Seleccione--"
                };
                listaTipos.Insert(0, opcionInicial);

                cboTipoHabitacion.DataSource = listaTipos;
                cboTipoHabitacion.DataValueField = "tipoHabitacionId";
                cboTipoHabitacion.DataTextField = "tipoHabitacionDescripcion";
                cboTipoHabitacion.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar los tipos de habitación: " + ex.Message;
            }
        }

        private void CargarHabitaciones(int tipoHabitacionId)
        {
            try
            {
                List<HabitacionBE> listaHabitaciones = habitacionBL.obtenerListaHabitacionesPorTipo(tipoHabitacionId);

                grvHabitaciones.DataSource = listaHabitaciones;
                grvHabitaciones.DataBind();

                lblMensaje.Text = $"Registros encontrados: {listaHabitaciones.Count}";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar las habitaciones: " + ex.Message;
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                int tipoHabitacionId = Convert.ToInt32(cboTipoHabitacion.SelectedValue);

                if (tipoHabitacionId == 0)
                {
                    CargarHabitaciones(0);
                    cargarDatosGrafico();
                    return;
                }

                CargarHabitaciones(tipoHabitacionId);

                List<HabitacionBE> listaHabitaciones = habitacionBL.obtenerListaHabitacionesPorTipo(tipoHabitacionId);

                ChartHabitaciones.Series.Clear();
                ChartHabitaciones.Series.Add("Aforo");

                ChartHabitaciones.Series["Aforo"].Points.DataBindXY(
                    listaHabitaciones,
                    "habitacionNombre",
                    listaHabitaciones,
                    "habitacionAforo"
                );

                ChartHabitaciones.Series["Aforo"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                ChartHabitaciones.Series["Aforo"].IsValueShownAsLabel = true;
                ChartHabitaciones.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al filtrar las habitaciones: " + ex.Message;
            }
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                string path = $"{Server.MapPath("/")}Plantillas/ListadoConsultaHabitaciones.xlsx";
                List<HabitacionBE> habitacionesDescargados = new List<HabitacionBE>();

                foreach (GridViewRow row in grvHabitaciones.Rows)
                {
                    HabitacionBE habitacion = new HabitacionBE
                    {
                        habitacionId = int.Parse(row.Cells[0].Text),
                        habitacionNombre = row.Cells[1].Text,
                        habitacionAforo = Convert.ToByte(row.Cells[2].Text),
                        estadoHabitacionString = row.Cells[3].Text
                    };
                    habitacionesDescargados.Add(habitacion);
                }

                int filaInicial = 5;
                using (var paquete = new OfficeOpenXml.ExcelPackage(new FileInfo(path)))
                {
                    string filename = $"ReporteConsultaHabitaciones_{DateTime.Today.ToShortDateString()}";
                    //paquete.Workbook.Worksheets.Add("Habitaciones");
                    ExcelWorksheet worksheet = paquete.Workbook.Worksheets["Hoja1"];

                    foreach (HabitacionBE item in habitacionesDescargados)
                    {
                        worksheet.Cells[filaInicial, 1].Value = item.habitacionId.ToString();
                        worksheet.Cells[filaInicial, 2].Value = item.habitacionNombre.ToString();
                        worksheet.Cells[filaInicial, 3].Value = item.habitacionAforo.ToString();
                        worksheet.Cells[filaInicial, 4].Value = item.estadoHabitacionString.ToString();
                        filaInicial++;
                    }

                    worksheet.Column(1).Width = 15;
                    worksheet.Column(2).Width = 25;
                    worksheet.Column(3).Width = 10;
                    worksheet.Column(4).Width = 20;

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
        private void cargarDatosGrafico()
        {
            List<HabitacionBE> listaHabitaciones = habitacionBL.obtenerListaHabitaciones();

            ChartHabitaciones.Series.Clear();
            ChartHabitaciones.Series.Add("Aforo");

            ChartHabitaciones.Series["Aforo"].Points.DataBindXY(
                listaHabitaciones,
                "habitacionNombre",
                listaHabitaciones,
                "habitacionAforo"
            );

            ChartHabitaciones.Series["Aforo"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            ChartHabitaciones.Series["Aforo"].IsValueShownAsLabel = true;
            ChartHabitaciones.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            ChartHabitaciones.Titles.Add("Habitaciones y Aforo");
        }
    }
}
