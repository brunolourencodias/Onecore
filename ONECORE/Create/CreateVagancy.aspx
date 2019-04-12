<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateVagancy.aspx.cs" Inherits="OneCore.Create.CreateVagancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery.maskedinput/1.4.1/jquery.maskedinput.min.js"></script>
    <script type="text/javascript">
        function openModal() {
            $("#ModalRegister").modal('show');
        }

        jQuery(function ($) {

            $("#txtTelephone").mask("(099) 99999-9999");
            $("#txtDateFinally").mask('99/99/9999');
        });
    </script>
    <!-- Modal -->
    <div class="modal fade" id="ModalRegister" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ONECORE</h4>
                </div>
                <div class="modal-body">
                    <h6>VAGA CADASTRADA COM SUCESSO!!</h6>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnClose" Text="Fechar" OnClick="btnClose_Click" class="btn btn-danger" runat="server"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="udpPnlRegisterVagancy" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PnlRegisterVagancy" runat="server">
                <div class="card">
                    <div class="card-body">
                        <div class="card-title">
                            Cadastramento de Vagas
                        </div>
                        <asp:ValidationSummary ID="vsForm" CssClass="alert-danger" ValidationGroup="Add" runat="server" />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblTitle" runat="server">Título</asp:Label>
                                    <asp:TextBox ID="txTitle" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtitle" ErrorMessage="Por favor Informe um título!" ControlToValidate="txTitle" ForeColor="Red" ValidationGroup="Add" Display="None" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblCompany" runat="server">Empresa/Contratante</asp:Label>
                                    <asp:TextBox ID="txtCompany" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Por favor Informe um Empresa!" ControlToValidate="txtCompany" ForeColor="Red" Display="None" ValidationGroup="Add" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblDataFinally" runat="server">Data de encerramento</asp:Label>
                                    <asp:TextBox ID="txtDateFinally" ClientIDMode="Static" class="form-control form-control-sm" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Por favor Informe um Data Válida!" ControlToValidate="txtDateFinally" ForeColor="Red" Display="None" ValidationGroup="Add" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblTelephone" runat="server">Telefone</asp:Label>
                                    <asp:TextBox ID="txtTelephone" class="form-control form-control-sm" ClientIDMode="Static" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Por favor Informe um Telefone Válido!" ControlToValidate="txtTelephone" Display="None" ValidationGroup="Add" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblEmail" runat="server">Email</asp:Label>
                                    <asp:TextBox ID="txtEmail" class="form-control form-control-sm" TextMode="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Por favor Informe um E-mail" ControlToValidate="txtEmail" ForeColor="Red" Display="None" ValidationGroup="Add" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblValor" runat="server">Valor</asp:Label>
                                    <asp:TextBox ID="txtValor" class="form-control form-control-sm" ClientIDMode="Static" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="Por favor Informe um valor" ControlToValidate="txtValor" ForeColor="Red" Display="None" ValidationGroup="Add" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="lblObs" runat="server">Resumo da vaga</asp:Label>
                                    <textarea id="txtObs" class="form-control" cols="20" rows="3" aria-multiline="true"  runat="server"></textarea>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Por favor, Digite as atividades!!" ControlToValidate="txtObs" ForeColor="Red" Display="None" ValidationGroup="Add" runat="server"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="btnRegister" ValidationGroup="Add" OnClick="btnRegister_Click" Text="Cadastrar" class=" btn btn-primary btn-rounded btn-fw" runat="server" />
                                    <asp:Button ID="btnUpdate" ValidationGroup="Add" OnClick="btnUpdate_Click" Visible="false" Text="Atualizar" class=" btn btn-primary btn-rounded btn-fw" runat="server" />
                                    <asp:Button ID="btnCanel" Text="Cancelar" class="btn btn-danger btn-rounded btn-fw"  OnClick="btnCanel_Click" runat="server" />
                                    <asp:Button ID="btnClean" Text="Limpar" class="btn btn-default btn-rounded btn-fw" OnClick="btnClean_Click" runat="server" />
                                    <asp:CustomValidator ID="cvVerifyDate" ValidationGroup="Add" OnServerValidate="cvVerifyDate_ServerValidate" ErrorMessage="Data Inválida!!" Display="None" runat="server"></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
