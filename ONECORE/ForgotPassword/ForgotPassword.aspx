<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="OneCore.ForgotPassword.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ONECORE</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/StarAdmin-Free-Bootstrap-Admin-Template-master/css/style.css" rel="stylesheet" />

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery.maskedinput/1.4.1/jquery.maskedinput.min.js"></script>
    <script type="text/javascript">
</script>
    <style type="text/css">
        #body {
            background-color: aliceblue;
        }

        .card {
            width: 500px;
            min-height: 300px;
            margin: 0px auto;
            position: relative;
        }
    </style>
</head>
<body id="body">
    <form id="form" runat="server">
        <div>
            <br />
            <br />
            <br />
            <br />
            <div class="panel panel-Default">
                <div class="card">
                    <div class="card-body">
                        <div class="card-title">
                            <asp:Label Text="RECUPERAÇÃO DE SENHA" runat="server"></asp:Label>
                        </div>                        
                        <asp:ValidationSummary ID="vsRegister" CssClass="alert alert-danger" ValidationGroup="Add" runat="server" />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="lblText" Text="Digite seu E-mail para recuperar sua senha.<br/> Caso não possua cadastro: " runat="server"><asp:LinkButton ID="lnkRegister" Text="Clique Aqui!" CausesValidation="false" OnClick="lnkRegister_Click" runat="server"></asp:LinkButton></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="lblCPF" runat="server">E-mail</asp:Label>
                                    <asp:TextBox ID="txtEmail" class="form-control" TextMode="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtEmail" ValidationGroup="Add" ErrorMessage="Digite um E-mail válido para recuperar sua senha!!" Display="None" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Button ID="btnSend" ValidationGroup="Add" class="form-control  btn-success mr-2" OnClick="btnSend_Click" Text="Enviar" runat="server"></asp:Button>
                                    <asp:CustomValidator ID="cvVerify" ErrorMessage="Erro" ValidationGroup="Add" OnServerValidate="cvVerify_ServerValidate"  Display="None" runat="server"></asp:CustomValidator>
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
