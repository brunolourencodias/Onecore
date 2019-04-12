using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace OneCore.Class
{
    public class Suporte
    {

        public void openModal(string lModal = "")
        {
            Page lPage = new Page();
            ScriptManager.RegisterStartupScript(lPage, this.GetType(), "Modal", "function openModal() { " + $"$(#{lModal} ).modal('show')"+ "}; " , true);
        }
    }
}