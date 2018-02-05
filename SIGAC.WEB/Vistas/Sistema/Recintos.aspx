<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" CodeBehind="Recintos.aspx.cs" Inherits="SIGAC.WEB.Vistas.Sistema.Recintos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleCPH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="server">
    <div class="GridContainer">
        <div class="panel panel-custom">
            <div class="panel-heading">
                <h4 class="panel-title">Busqueda de Recintos</h4>
                <h6 class="panel-text"> Por Nombre</h6>
            </div>
            <div class="panel-body">
                <div class="GridContainer">
                    <div class="GridRow">
                        <div class="col1">
                            <p>&nbsp;</p>
                        </div>
                        <div class="col8">
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" />
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
                <div class="GridRow">
                    <div class="col1">
                        <p>&nbsp;</p>
                    </div>
                    <div class="col8">
                        <asp:GridView runat="server" ID="gridViewRecintos"
                            AllowPaging="True"
                            CssClass="w3-table-all"
                            HeaderStyle-CssClass=""
                            ShowHeaderWhenEmpty="True"
                            AutoGenerateColumns="false"
                            DataKeyNames="ID">
                            
                            <Columns>
                                <asp:TemplateField HeaderText="Opciones">
                                    <ItemTemplate></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="Id del Recinto" SortExpression="ID" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre del Recinto"  />
                                <asp:BoundField DataField="TELEFONO1" HeaderText="1er Telefono"  />
                                <asp:BoundField DataField="TELEFONO2" HeaderText="2do Telefono" />
                                <asp:TemplateField >
                                    <HeaderTemplate>
                                        <p>Notas</p>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div>
                                            <p><%# Eval("NOTA") %></p>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ESTATUS" HeaderText="Estado" />
                            </Columns>
                        </asp:GridView>
                        <asp:EntityDataSource ID="Entitycon_Recintos" runat="server">
                        </asp:EntityDataSource>
                    </div>
                    <div class="col1">
                        <p>&nbsp;</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsCPH" runat="server">
</asp:Content>
