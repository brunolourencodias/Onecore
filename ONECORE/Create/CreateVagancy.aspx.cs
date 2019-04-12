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

namespace OneCore.Create
{
    public partial class CreateVagancy : System.Web.UI.Page
    {
        #region Ações

        CultureInfo gCulture = new CultureInfo("pt-BR");

        Vagancy lVagancy = new Vagancy();

        Company lCompany = new Company();

        Transaction pTransaction = new Transaction();

        Suporte suporte = new Suporte();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["Edit"] != null)
                {
                    btnRegister.Visible = false;
                    btnUpdate.Visible = true;

                    MontaFormUpdate(Convert.ToDecimal(Request["Edit"]));
                }

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    lVagancy.VG_TITLE = Convert.ToString(txTitle.Text);
                    lVagancy.VG_DATE_FINALLY = Convert.ToDateTime(txtDateFinally.Text);
                    lVagancy.VG_DATECREATE = Convert.ToDateTime(DateTime.Now);
                    lVagancy.VG_OBS = Convert.ToString(txtObs.InnerText);
                    lVagancy.VG_VALUE = Convert.ToDecimal(txtValor.Text);
                    lVagancy.VG_EMAIL = Convert.ToString(txtEmail.Text);
                    lVagancy.VG_TELEFONE = Convert.ToString(txtTelephone.Text);
                    lVagancy.VG_NAMECOMPANY = Convert.ToString(txtCompany.Text);
                    lVagancy.Add(pTransaction);

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Vaga cadastrada com sucesso!!');", true);

                    CleanForm();

                }
                catch (Exception Epx)
                {

                    throw Epx;
                }

            }

        }

        protected void btnClean_Click(object sender, EventArgs e)
        {
            CleanForm();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Create/Default.aspx");
        }

        protected void cvVerifyDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime DtActually = Convert.ToDateTime(txtDateFinally.Text);

            if (DtActually.Date < DateTime.Now.Date)
            {
                args.IsValid = false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                // faz o update 
                Vagancy lvagancyUP = new Vagancy(Convert.ToDecimal(Request["Edit"]));

                lvagancyUP.VG_TITLE = Convert.ToString(txTitle.Text);
                lvagancyUP.VG_DATE_FINALLY = Convert.ToDateTime(txtDateFinally.Text);
                lvagancyUP.VG_OBS = Convert.ToString(txtObs.InnerText);
                lvagancyUP.VG_VALUE = Convert.ToDecimal(txtValor.Text);
                lvagancyUP.VG_EMAIL = Convert.ToString(txtEmail.Text);
                lvagancyUP.VG_TELEFONE = Convert.ToString(txtTelephone.Text);
                lvagancyUP.VG_NAMECOMPANY = Convert.ToString(txtCompany.Text);

                lvagancyUP.Update(lvagancyUP.VAGANCY_ID, pTransaction);

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Vaga atualizada com sucesso');", true);

                CleanForm();
            }
            catch (Exception pEx)
            {

                throw pEx;
            }

        }
        #endregion

        #region Métodos 

        private void MontaFormUpdate(decimal pVAGANCY_ID)
        {
            //monta a tela para dar o update
            Vagancy lvagancy = new Vagancy(Convert.ToDecimal(pVAGANCY_ID));

            txTitle.Text = Convert.ToString(lvagancy.VG_TITLE);
            txtTelephone.Text = Convert.ToString(lCompany.CPY_TEL);
            txtObs.InnerText = Convert.ToString(lvagancy.VG_OBS);
            txtEmail.Text = Convert.ToString(lCompany.CPY_EMAIL);
            txtDateFinally.Text = Convert.ToString(lvagancy.VG_DATE_FINALLY);
            txtValor.Text = Convert.ToString(lvagancy.VG_VALUE);
            txtEmail.Text = Convert.ToString(lvagancy.VG_EMAIL);
            txtTelephone.Text = Convert.ToString(lvagancy.VG_TELEFONE);
            txtCompany.Text = Convert.ToString(lvagancy.VG_NAMECOMPANY);
            udpPnlRegisterVagancy.Update();

        }

        private void CleanForm()
        {
            txTitle.Text = string.Empty;
            txtDateFinally.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtObs.InnerText = string.Empty;
            txtCompany.Text = string.Empty;
            txtValor.Text = string.Empty;
        }

        #endregion

        protected void btnCanel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Create/Default.aspx");
        }
    }
}