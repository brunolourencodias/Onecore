<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FeedsHome.aspx.cs" Inherits="OneCore.Feeds.FeedsHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="card">
        <div class="card-body">
            <h5 class="card-title mb-4">Atualizadas Recentemente</h5>
            <asp:UpdatePanel ID="updRpt" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="rptFeeds" OnItemDataBound="rptFeeds_ItemDataBound" runat="server">
                        <ItemTemplate>

                            <div class="fluid-container">
                                <div class="row ticket-card mt-3 pb-2 border-bottom pb-3 mb-3">
                                    <div class="col-md-1">
                                        <img class="img-sm rounded-circle mb-4 mb-md-0" src="../Icones/download.png" alt="profile image">
                                    </div>
                                    <div class="ticket-details col-md-9">
                                        <div class="d-flex">
                                            <asp:HiddenField ID="hdnId" Value='<%# Eval("VAGANCY_ID")%>' runat="server" />
                                            <p>
                                                <label>Titulo:  </label>
                                                <asp:Label ID="lblCompany" class="text-dark font-weight-semibold mr-2 mb-0 no-wrap" runat="server"></asp:Label>
                                            </p>
                                            <p>

                                                <asp:Label ID="lblTitle" class="text-primary mr-1 mb-0" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                        <p>
                                            <label>Descrição da vaga: </label>
                                            <asp:Label ID="lblDescripton" class="text-gray ellipsis mb-2" Text="BALLNALNBALANLAS" runat="server"></asp:Label>

                                        </p>
                                        <div class="row text-gray d-md-flex d-none">
                                            <div class="col-4 d-flex">
                                                <label class="mb-0 mr-2 text-muted text-muted small">Criado:</label>
                                                <asp:Label ID="lblCreated" class="mb-0 mr-2 text-muted text-muted small" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-4 d-flex">
                                                <label class="mb-0 mr-2 text-muted text-muted small">Expira:</label>
                                                <asp:Label ID="lblExp" class="mb-0 mr-2 text-muted text-muted small" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--                            <div class="ticket-actions col-md-2">
                                <div class="btn-group">
                                    <asp:Button class="btn btn-success btn-sm" Text="Enviar Portifólio" runat="server"></asp:Button>
                                </div>
                            </div>--%>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>

            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
