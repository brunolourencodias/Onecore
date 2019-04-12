using OneCore.Class;
using OneCore.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneCore.CreateVagancy
{
    public partial class Default : System.Web.UI.Page
    {
        CultureInfo gCulture = new CultureInfo("pt-BR");

        Vagancy lVagancy = new Vagancy();
        Transaction pTransaction = new Transaction();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulaGrid(Convert.ToDecimal(Request["Id"]));
            }
        }

        protected void btnCloseDel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Create/Default.aspx");
        }

        private void PopulaGrid(decimal lRequest)
        {
            DataTable ldtPopulaGrid = lVagancy.ReturnVagancy($"AND USS_ID={lRequest}");

            gvVagancyCreated.DataSource = ldtPopulaGrid;
            gvVagancyCreated.DataBind();

        }

        protected void gvVagancyCreated_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataRowView lDrv = (DataRowView)e.Row.DataItem;

                Vagancy lVagancy = new Vagancy(Convert.ToDecimal(lDrv["VAGANCY_ID"]));

                e.Row.Cells[2].Text = string.Format(gCulture, "{0:dd/MM/yyyy}", lVagancy.VG_DATE_FINALLY);

                e.Row.Cells[3].Text = string.Format(gCulture, "{0:dd/MM/yyyy}", lVagancy.VG_DATECREATE);

                #region Status

                Label lblStatus = (Label)e.Row.FindControl("lblStatus");

                if (lVagancy.VG_STATUS == Vagancy.status.Ativo)
                {
                    lblStatus.Text = "Ativo";
                    lblStatus.Attributes["class"] = "badge badge-success";

                }
                else
                {
                    lblStatus.Text = "Inativo";
                    lblStatus.Attributes["class"] = "badge badge-danger";
                }
                #endregion

            }
        }

        protected void gvVagancyCreated_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                decimal pIdCommand = Convert.ToDecimal(e.CommandArgument);

                decimal pId =Convert.ToDecimal(Request["Id"]);

                Response.Redirect("CreateVagancy.aspx?Edit=" + pIdCommand);
            }
            if (e.CommandName == "Del")
            {
                lVagancy.Delete(Convert.ToDecimal(e.CommandArgument), pTransaction);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ModalDel();", true);

            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Create/CreateVagancy.aspx" + "?Id=" + Request["Id"] );
        }
    }
}