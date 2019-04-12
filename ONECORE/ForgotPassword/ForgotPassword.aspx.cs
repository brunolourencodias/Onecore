using OneCore.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneCore.ForgotPassword
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        Users Users = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lnkRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                
            }
        }

        protected void cvVerify_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DataTable ldtCheckEmail = Users.Return($"AND USS_EMAIL='{txtEmail.Text}'");

            if(ldtCheckEmail.Rows.Count == 0){
                args.IsValid = false;
                cvVerify.ErrorMessage = "Não encontramos nenhum e-mail";
            }
        }
    }
}