<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="SIGAC.WEB.Vistas.Sistema.Cursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleCPH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="server">
    <div class="GridContainer">
        <div class="panel panel-custom">
            <div class="panel-heading">
                <h4 class="panel-title">Busqueda de Cursos</h4>
                <h6 class="panel-text">Por Descripcion</h6>
            </div>
            <div class="panel-body">
                <div class="GridContainer">
                    <div class="GridRow">
                        <div class="col1">
                            <p>&nbsp;</p>
                        </div>
                        <div class="col8">
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="textboxFiltro" CssClass="form-control" />
                                <div class="input-group-btn">
                                    <asp:LinkButton ID="buttonFiltro" runat="server" CssClass="btn btn-custom" OnClick="buttonFiltro_Click">
                                        <span class="fas fa-search"></span>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col1">
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
                <div class="GridContainer">
                    <div class="GridRow">
                        <div class="col1">
                            <p>&nbsp;</p>
                        </div>
                        <div class="col8 w3-responsive">
                            <asp:GridView runat="server" ID="gridViewCursos"
                                AllowPaging="true" PageSize="5"
                                CssClass="w3-table-all"
                                HeaderStyle-CssClass="GridCenter"
                                AutoGenerateColumns="false"
                                ShowHeaderWhenEmpty="true"
                                OnRowCommand="gridViewCursos_RowCommand"
                                OnRowUpdating="gridViewCursos_RowUpdating"
                                OnPageIndexChanging="gridViewCursos_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="ID_CURSO" HeaderText="ID" />
                                    <asp:TemplateField HeaderText="Fecha Creacion">
                                        <ItemTemplate>
                                            <div class="GridCenter">
                                                <p><%# Eval("FECHA", "{0:d}") %></p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripcion">
                                        <ItemTemplate>
                                            <div class="GridCenter">
                                                <p><%# Eval("DESCRIPCION") %></p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rama Profesional">
                                        <ItemTemplate>
                                            <div class="GridCenter">
                                                <p><%# Eval("RAMA_PROFESIONAL") %></p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tipo">
                                        <ItemTemplate>
                                            <div class="GridCenter">
                                                <p><%# Eval("TIPO") %></p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vigente">
                                        <ItemTemplate>
                                            <div class="GridCenter">
                                                <p><%# Eval("VIGENTE") %></p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="col1">
                            <p>&nbsp;</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsCPH" runat="server">
</asp:Content>
