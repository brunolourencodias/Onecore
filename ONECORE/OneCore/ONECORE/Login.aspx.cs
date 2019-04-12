using OneCore.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneCore
{
    public partial class Login : System.Web.UI.Page
    {

        Users Users = new Users();
        DataTable gtable;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                foreach (DataRow lRow in gtable.Rows)
                {
                    Response.Redirect("~/Create/Default.aspx" + "?Id=" + lRow["USS_ID"]);
                }

            }
        }

        protected void cvVerify_ServerValidate(object source, ServerValidateEventArgs args)
        {

            gtable = Users.Return($"AND USS_EMAIL ='{txtEmail.Text}' AND USS_PASSWORD ='{txtPassword.Text}' ");

            if (gtable.Rows.Count == 0)
            {
                args.IsValid = false;
                cvVerify.ErrorMessage = "E-mail ou senha inválido!";
            }
        }

        protected void lnkRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void lnkForgot_Click(object sender, EventArgs e)
        {

        }
    }
}