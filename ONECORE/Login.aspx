<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OneCore.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ONECORE</title>
    <link href="Content/StarAdmin-Free-Bootstrap-Admin-Template-master/css/style.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.js"></script>
    <link href="Content/StarAdmin-Free-Bootstrap-Admin-Template-master/vendors/iconfonts/mdi/css/materialdesignicons.css" rel="stylesheet" />
    <link href="Content/StarAdmin-Free-Bootstrap-Admin-Template-master/vendors/iconfonts/mdi/css/materialdesignicons.css" rel="stylesheet" />
    <link rel="stylesheet" href="Content/StarAdmin-Free-Bootstrap-Admin-Template-master/vendors/css/vendor.bundle.base.css" />
    <link rel="stylesheet" href="Content/StarAdmin-Free-Bootstrap-Admin-Template-master/vendors/css/vendor.bundle.addons.css" />

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery.maskedinput/1.4.1/jquery.maskedinput.min.js"></script>
    <style type="text/css">
        .card {
            width: 400px;
            min-height: 320%;
            margin: 7px auto;
            position: relative;
            margin-top: 100px;
            margin-left: 70% auto;
        }
    </style>
</head>
<body id="body" style="background-image: url(img/imageBody.jpg); width:100%;">
    <form id="frmRegister" runat="server">
        <div>
            <br />
            <div class="panel panel-Default">
                <div class="card">
                    <div class="card-body">
                        <div class="card-title">
                            <asp:Label Text="LOGIN" runat="server"></asp:Label>
                        </div>
                        <asp:Label ID="lblCheck" ForeColor="Green" Text="Cadastrado com sucesso!" Visible="false" runat="server"></asp:Label>
                        <asp:ValidationSummary ID="vsRegister" CssClass="alert alert-danger" ValidationGroup="Add" runat="server" />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="lblEmail" runat="server">Email</asp:Label>
                                    <asp:TextBox ID="txtEmail" class="form-control" TextMode="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEmail" ValidationGroup="Add" ErrorMessage="Digite o E-mail!!" Display="None" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="lblPassword" runat="server">Senha</asp:Label>
                                    <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Add" ControlToValidate="txtPassword" ErrorMessage="Digite a senha!!" Display="None" runat="server"></asp:RequiredFieldValidator>
                                    <asp:LinkButton ID="lnkForgot" Text="Esqueceu a senha?" CausesValidation="false" OnClick="lnkForgot_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Button ID="btnEntrar" ValidationGroup="Add" OnClick="btnEntrar_Click" Text="Entrar" class=" form-control btn-block btn-success mr-2" runat="server" />
                                    <asp:CustomValidator ID="cvVerify" ErrorMessage="Erro" ValidationGroup="Add" OnServerValidate="cvVerify_ServerValidate"  Display="None" runat="server"></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                             <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:LinkButton ID="lnkRegister" Text="Não possui cadastro? Registre-se!" CausesValidation="false" OnClick="lnkRegister_Click" runat="server" />                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
