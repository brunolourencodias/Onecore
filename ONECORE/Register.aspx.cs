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

        #region Ações 

        RegisterClient lRegisterClient = new RegisterClient();

        Transaction lTransaction = new Transaction();
        Suporte suporte = new Suporte();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                //registra o usuário
                Users lUsers = new Users();

                Random random = new Random();
                int randomNumber = random.Next(0, 9999);

                lUsers.USS_ID = randomNumber;
                lUsers.USS_NAME = Convert.ToString(txtName.Text);
                lUsers.USS_EMAIL = Convert.ToString(txtEmail.Text);
                lUsers.USS_PASSWORD = Convert.ToString(txtPassword.Text);
                lUsers.USS_DATECREATE = Convert.ToDateTime(DateTime.Now.Date);
                lUsers.Add(lTransaction);

                lRegisterClient.USS_ID = randomNumber;
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

                Response.Redirect("~/Feeds/FeedsHome.aspx");


            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        #endregion

        #region Métodos 

        public void SendEmail(string lEmail)
        {

            try
            {

                // quando o cadastro for válido enviará seus dados para o e-mail colocado no cadastro
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

        #endregion

        #region Custom Validator 

        protected void cvVerifyDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Users Users = new Users();

            DataTable ldtCheckEmail = Users.Return($"AND USS_EMAIL ='{txtEmail.Text}'");

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

        #endregion
    }
}