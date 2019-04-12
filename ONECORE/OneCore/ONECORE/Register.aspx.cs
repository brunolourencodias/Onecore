using OneCore.Class;
using OneCore.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneCore
{
    public partial class Register : System.Web.UI.Page
    {
        Users lUsers = new Users();
        RegisterClient lRegisterClient = new RegisterClient();

        Transaction lTransaction = new Transaction();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {


                lUsers.USS_NAME = Convert.ToString(txtName.Text);
                lUsers.USS_EMAIL = Convert.ToString(txtEmail.Text);
                lUsers.USS_PASSWORD = Convert.ToString(txtPassword.Text);
                lUsers.USS_DATECREATE = Convert.ToDateTime(DateTime.Now.Date);
                lUsers.UST_IDTYPE = 2;
                lUsers.Add(lTransaction);

                lRegisterClient.USS_ID = Convert.ToInt32(lUsers.USS_ID);
                lRegisterClient.RST_NAME = Convert.ToString(lUsers.USS_NAME);
                lRegisterClient.RST_DATEBIRTH = Convert.ToDateTime(txtDateBirth.Text);
                if (ddlGenre.SelectedValue == "M")
                    lRegisterClient.RST_GENRE = RegisterClient.genre.Masculino;
                else
                    lRegisterClient.RST_GENRE = RegisterClient.genre.Feminino;

                lRegisterClient.RST_DOCUMENT = Convert.ToString(txtCPF.Text).Replace(".", "").Replace("-", "");

                lRegisterClient.Add(lTransaction);


                lblCheck.Visible = true;

                SendEmail(txtEmail.Text);

                Clean();

                Response.Redirect("~/Create/Default.aspx" + "?Id=" + lUsers.USS_ID);

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        private void Clean()
        {
            txtCPF.Text = string.Empty;
            txtDateBirth.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;

            ddlGenre.SelectedValue = "";

            txtPassword.Text = string.Empty;
            txtRepeatPassword.Text = string.Empty;
        }

        protected void cvVerifyDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DataTable ldtCheckEmail = lUsers.Return($"AND USS_EMAIL ='{txtEmail.Text}'");

            if (ldtCheckEmail.Rows.Count > 0)
            {
                args.IsValid = false;
                cvVerifyDate.ErrorMessage = "E-mail já Cadastrado!!";
            }

            if (txtPassword.Text != txtRepeatPassword.Text)
            {
                args.IsValid = false;
                cvVerifyDate.ErrorMessage = "Senhas diferentes!";
            }
            string pRepl = txtCPF.Text.Replace(".", "").Replace("-", "");
            DataTable lDtCheckCPF = lRegisterClient.Return($"AND RST_DOCUMENT ='{pRepl}'");

            if (lDtCheckCPF.Rows.Count > 0)
            {
                args.IsValid = false;
                cvVerifyDate.ErrorMessage = "CPF já Cadastrado!!";
            }
        }

        public void SendEmail(string lEmail)
        {

            try
            {
                MailMessage lMessage = new MailMessage("onecore.noreply@gmail.com", lEmail);

                lMessage.Subject = "Seja Bem-Vindo ao ONECORE!!";
                string MessageBody = "Você acabou de se cadastrar no ONECORE.\n Seu acesso já está disponível: \n\n E-mail: " + txtEmail.Text + "\n Senha: " + txtPassword.Text + " \n\n\n\n\n Atenciosamente, " +
                    " \n Equipe ONECORE!";
                lMessage.Body = MessageBody;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 25);
                smtpClient.EnableSsl = true;
                //credenciais da conta que utilizará para enviar o e-mail 
                smtpClient.Credentials = new NetworkCredential("onecore.noreply@gmail.com", "1350868bru");
                smtpClient.Send(lMessage);

            }
            catch { }


        }
    }
}