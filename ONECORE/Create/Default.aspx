<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OneCore.CreateVagancy.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function ModalDel() {
            $("#ModalDelete").modal('show');
        }
    </script>
    <!-- Modal -->
    <div class="modal fade" id="ModalDelete" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ONECORE</h4>
                </div>
                <div class="modal-body">
                    <h6>Vaga Removida com Sucesso!!</h6>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCloseDel" Text="Fechar" OnClick="btnCloseDel_Click" class="btn btn-danger" runat="server"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <asp:Panel ID="PnlRegisterVagancy" runat="server">
        <div class="panel panel-Default">
            <div class="card">
                <div class="card-body">
                    <div class="card-title">
                        <asp:Label Text="FILTRO: VAGAS" runat="server"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblCod" runat="server">Código</asp:Label>
                                <asp:TextBox ID="txCod" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server">Titulo</asp:Label>
                                <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblStatus" runat="server">Status</asp:Label>
                                <asp:DropDownList ID="ddlStatus" class="form-control form-control-sm" runat="server">
                                    <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblDate" runat="server">Data</asp:Label>
                                <asp:TextBox ID="txtDate" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Button ID="btnFilter" CssClass="btn btn-primary btn-fw" Text="Filtrar" runat="server" />
                                <asp:Button ID="btnClean" CssClass="btn btn-light btn-fw" Text="Limpar" runat="server" />
                                <asp:Button ID="btnNew" CssClass="btn btn-success btn-fw" Text="Criar vaga" OnClick="btnNew_Click" runat="server" />
                            </div>
                        </div>
                    </div>
                    <asp:GridView ID="gvVagancyCreated"
                        OnRowDataBound="gvVagancyCreated_RowDataBound"
                        OnRowCommand="gvVagancyCreated_RowCommand"
                        AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered"
                        runat="server">
                        <EmptyDataTemplate>Nenhum registro encontrado! </EmptyDataTemplate>
                        <Columns>                            
                            <asp:BoundField HeaderText="Cód." HeaderStyle-Width="30px" SortExpression="VAGANCY_ID" DataField="VAGANCY_ID" />
                            <asp:BoundField HeaderText="Título" HeaderStyle-HorizontalAlign="Center" SortExpression="VG_TITLE" DataField="VG_TITLE" />
                            <asp:BoundField HeaderText="Data de Encerramento" HeaderStyle-HorizontalAlign="Center" SortExpression="VG_DATE_FINALLY" DataField="VG_DATE_FINALLY" />
                            <asp:BoundField HeaderText="Data de Criação" HeaderStyle-HorizontalAlign="Center" SortExpression="VG_DATECREATE" DataField="VG_DATECREATE" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate> 
                                    <asp:ImageButton ID="imgEdit" CommandArgument='<%# Eval("VAGANCY_ID")%>'  ImageUrl="~/Icones/pencil.png" CommandName="Edit" ToolTip="Editar" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <span>
                                    <asp:ImageButton ID="imgDel" CommandArgument='<%# Eval("VAGANCY_ID")%>' ImageUrl="~/Icones/delete.png"  OnClientClick="return confirm('Você deseja excluir essa vaga??');" CommandName="Del" ToolTip="Deletar" runat="server" />
                                    <i class="fa-trash-o"></i></span>
                                </ItemTemplate>
                                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
