using OfficeOpenXml;
using ProyHotel_BE;
using ProyHotel_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hotel_booking_management
{
    public partial class FrmServicios : System.Web.UI.Page
    {
        ServicioBL servicioBL = new ServicioBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    gridServices.DataSource = servicioBL.ListarServicio();
                    gridServices.DataBind();
                }
                
            }
            catch (Exception ex)
            {

            }
        }

        protected void buttonReport_Click(object sender, EventArgs e)
        {
            try
            {
                List<ServicioBE> searchedService = new List<ServicioBE>();
                searchedService.Add(servicioBL.BuscarServicioPorNombre(textboxSearch.Text));

                gridServices.DataSource = searchedService;
                gridServices.DataBind();
            }
            catch (Exception ex)
            {

            }
        }


    }
}