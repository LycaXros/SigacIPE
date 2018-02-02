<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SIGAC.WEB.Vistas.Sistema.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleCPH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="server">
    <div class="container">
        <div class="panel panel-custom">
            <div class="panel-heading">
                <h4 class="panel-title">Busqueda de Usuarios</h4>
            </div>
            <div class="panel-body">
                <div class="w3-container">
                    <div class="w3-row">
                        <div class="w3-col s1">
                            <p>&nbsp;</p>
                        </div>
                        <div class="w3-col s10">
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="textboxFiltro" CssClass="form-control" />
                                <div class="input-group-btn">
                                    <asp:LinkButton ID="buttonFiltro" runat="server" CssClass="button btn btn-primary" OnClick="buttonFiltro_Click"><span class="glyphicon glyphicon-search w3-text-white"/></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="w3-col s1">
                            <p>&nbsp;</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-custom">
            <div class="panel-heading">
                <h4 class="panel-title">Detalles</h4>
            </div>
            <div class="panel-body">
                <div class="w3-row">
                    <div class="w3-col s1">
                        <p>&nbsp;</p>
                    </div>
                    <div class="w3-col s10">
                        <asp:GridView runat="server" ID="gridViewUsuarios"
                            AllowPaging="true" PageSize="10"
                            CssClass="w3-table-all"
                            HeaderStyle-CssClass=""
                            AutoGenerateColumns="false"
                            ShowHeaderWhenEmpty="true"
                            OnRowCommand="gridViewUsuarios_RowCommand"
                            OnRowUpdating="gridViewUsuarios_RowUpdating"
                            OnRowDeleting="gridViewUsuarios_RowDeleting"
                            OnPageIndexChanging="gridViewUsuarios_PageIndexChanging">
                            <Columns>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="w3-col s1">
                        <p>&nbsp;</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsCPH" runat="server">
</asp:Content>
