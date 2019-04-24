<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OneCore.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ONECORE</title>
    <link href="Content/StarAdmin-Free-Bootstrap-Admin-Template-master/css/style.css" rel="stylesheet" />
    <script src="wwwroot/js/jquery-3.3.1.js"></script>
    <link href="Content/StarAdmin-Free-Bootstrap-Admin-Template-master/vendors/iconfonts/mdi/css/materialdesignicons.css" rel="stylesheet" />
    <link href="Content/StarAdmin-Free-Bootstrap-Admin-Template-master/vendors/iconfonts/mdi/css/materialdesignicons.css" rel="stylesheet" />
    <link rel="stylesheet" href="Content/StarAdmin-Free-Bootstrap-Admin-Template-master/vendors/css/vendor.bundle.base.css" />
    <link rel="stylesheet" href="Content/StarAdmin-Free-Bootstrap-Admin-Template-master/vendors/css/vendor.bundle.addons.css" />
    
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery.maskedinput/1.4.1/jquery.maskedinput.min.js"></script>
    <style type="text/css">
        #Body {
            background-image: url(StarAdmin-Free-Bootstrap-Admin-Template-master\images\auth\login_1.jpg) !important;
            background-color: aliceblue;
        }

        .card {
            width: 500px;
            min-height: 400px;
            margin: 0px auto;
            position: relative;
        }
    </style>
    <script type="text/javascript">
        jQuery(function ($) {

            $("#txtDateBirth").mask('99/99/9999');
            $("#txtCPF").mask('999.999.999-99');
        });
    </script>
</head>  

<body id="Body">
    <form id="frmRegister" runat="server">
        <div>
            <br />
            <div class="panel panel-Default">
                <div class="card">
                    <div class="card-body">
                        <div class="card-title">
                            <asp:Label Text="CADASTRAMENTO DE USUÁRIOS" runat="server"></asp:Label>
                        </div>
                        <asp:Label ID="lblCheck" ForeColor="Green" Text="Cadastrado com sucesso!" Visible="false" runat="server"></asp:Label>
                        <asp:ValidationSummary ID="vsRegister" CssClass="alert alert-danger" ValidationGroup="Add" runat="server" />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="lblName" runat="server">Nome</asp:Label>
                                    <asp:TextBox ID="txtName" class="form-control" runat="server">                                      
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtName" ValidationGroup="Add" ErrorMessage="Preencha os Campos!!" Display="None" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblEmail" runat="server">Email</asp:Label>
                                    <asp:TextBox ID="txtEmail" class="form-control" TextMode="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEmail" ValidationGroup="Add" ErrorMessage="Preencha os Campos!!" Display="None" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblCPF" runat="server">CPF</asp:Label>
                                    <asp:TextBox ID="txtCPF" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtCPF" ValidationGroup="Add" ErrorMessage="Preencha os Campos!!" Display="None" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblDateBirth" runat="server">Data de Nascimento</asp:Label>
                                    <asp:TextBox ID="txtDateBirth" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfDate" ControlToValidate="txtDateBirth" ValidationGroup="Add" ErrorMessage="Preencha os Campos!!" Display="None" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblGenre" runat="server">Sexo</asp:Label>
                                    <asp:DropDownList ID="ddlGenre" class="form-control" runat="server">
                                        <asp:ListItem Text="--Selecione--" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                                        <asp:ListItem Text="Feminino" Value="F"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlGenre" ValidationGroup="Add" ErrorMessage="Preencha os Campos!!" Display="None" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblPassword" runat="server">Senha</asp:Label>
                                    <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Add" ControlToValidate="txtPassword" ErrorMessage="Preencha os Campos!!" Display="None" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblRepeatPassoword" runat="server">Repita a Senha</asp:Label>
                                    <asp:TextBox ID="txtRepeatPassword" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Add" ControlToValidate="txtRepeatPassword" ErrorMessage="Preencha os Campos!!" Display="None" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Button ID="btnRegister" ValidationGroup="Add" OnClick="btnRegister_Click" Text="Cadastrar" class=" btn btn-primary btn-rounded btn-fw" runat="server" />
                                    <asp:Button ID="btnCancel" OnClick="btnCancel_Click" Text="Cancelar" class=" btn btn-danger btn-rounded btn-fw" runat="server" />
                                    
                                    <asp:CustomValidator ID="cvVerifyDate" ValidationGroup="Add" OnServerValidate="cvVerifyDate_ServerValidate" ErrorMessage="Data Inválida!!" Display="None" runat="server"></asp:CustomValidator>
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
