using OneCore.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneCore.Feeds
{
    public partial class FeedsHome : System.Web.UI.Page
    {
        Vagancy vagancy = new Vagancy();

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulaRpt();
        }

        public void PopulaRpt()
        {
            rptFeeds.DataSource = vagancy.ReturnVagancy();
            rptFeeds.DataBind();

            updRpt.Update();

        }

        protected void rptFeeds_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblCompany = (Label)e.Item.FindControl("lblCompany");
                Label lblTitle = (Label)e.Item.FindControl("lblTitle");
                Label lblDescripton = (Label)e.Item.FindControl("lblDescripton");
                Label lblCreated = (Label)e.Item.FindControl("lblCreated");
                Label lblExp = (Label)e.Item.FindControl("lblExp");
                HiddenField hdnId = (HiddenField)e.Item.FindControl("hdnId");


                Vagancy pVagancy = new Vagancy(Convert.ToDecimal(hdnId.Value));

                lblCompany.Text = pVagancy.VG_TITLE;
                lblDescripton.Text = pVagancy.VG_OBS;
                lblCreated.Text = pVagancy.VG_DATECREATE.ToShortDateString();
                lblExp.Text = pVagancy.VG_DATE_FINALLY.ToShortDateString();

                
            }
        }
    }
}