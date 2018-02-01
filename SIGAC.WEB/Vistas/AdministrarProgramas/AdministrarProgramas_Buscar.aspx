<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" CodeBehind="AdministrarProgramas_Buscar.aspx.cs" Inherits="SIGAC.WEB.Vistas.AdministrarProgramas.AdministrarProgramas_Buscar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleCPH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h4 class="panel-title">Buscar Programa</h4>
            </div>
            <div class="panel-body">
                <div class="w3-container">
                    <div class="w3-row">
                        <div class="w3-col s2 m2 l2">
                            <p>Nivel Académico</p>
                        </div>
                        <div class="w3-col s4 m4 l4">
                            <asp:DropDownList runat="server" ID="selectNivelAcademico" CssClass="w3-select"></asp:DropDownList>
                        </div>
                        <div class="w3-col s2 m2 l2">
                            <p>Programa Académico</p>
                        </div>
                        <div class="w3-col s4 m4 l4">
                            <asp:DropDownList runat="server" ID="selectProgramaAcademico" CssClass="w3-select"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col s2 m2 l2">
                            <p>Modalidad</p>
                        </div>
                        <div class="w3-col s4 m4 l4">
                            <asp:DropDownList runat="server" ID="selectModalidad" CssClass="w3-select"></asp:DropDownList>
                        </div>
                        <div class="w3-col s2 m2 l2">
                            <p>Titulo Otorgado</p>
                        </div>
                        <div class="w3-col s4 m4 l4">
                            <asp:Label runat="server" ID="labelTituloOtorgado" CssClass="w3-text"></asp:Label>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col s2 m2 l2">
                            <p>Proceso</p>
                        </div>
                        <div class="w3-col s4 m4 l4">
                            <asp:DropDownList runat="server" ID="selectProceso" CssClass="w3-select"></asp:DropDownList>
                        </div>
                        <div class="w3-col s6 m6 l6">
                            <p>&nbsp;</p>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col s12 m12 l12">
                            <p>&nbsp;</p>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col s12 m12 l12">
                            <p>&nbsp;</p>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col s3 m3 l3">
                            <asp:LinkButton ID="buttonBuscar" runat="server" CssClass="w3-button" Width="100%">Buscar</asp:LinkButton>
                        </div>
                        <div class="w3-col s1 m1 l1">
                            <p>&nbsp;</p>
                        </div>
                        <div class="w3-col s3 m3 l3">
                            <asp:LinkButton ID="buttonAgregarPrograma" runat="server" CssClass="w3-button" Width="100%">Buscar</asp:LinkButton>
                        </div>
                        <div class="w3-col s5 m5 l5">
                            <p>&nbsp;</p>
                        </div>
                    </div>
                    <div class="w3-row-padding">
                        <div class="w3-col s12 m12 l12">
                            <asp:GridView ID="gridViewAdministrarProgramas" runat="server"
                                AutoGenerateColumns="false"
                                ShowHeaderWhenEmpty="true"
                                AllowPaging="True" PageSize="5"
                                CssClass="w3-table-all w3-responsive"
                                OnRowCommand="gridViewAdministrarProgramas_RowCommand"
                                OnRowUpdating="gridViewAdministrarProgramas_RowUpdating"
                                OnRowDeleting="gridViewAdministrarProgramas_RowDeleting"
                                OnPageIndexChanging="gridViewAdministrarProgramas_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Opciones">
                                        <ItemTemplate>
                                            <div class="w3-bar">
                                                <% if (true)
                                                    {%>
                                                <asp:LinkButton ID="buttonContinuarDiligenciamiento" runat="server"
                                                    CausesValidation="false"
                                                    CssClass="w3-button w3-bar-item"
                                                    CommandName="Continuar"
                                                    CommandArgument='<%#Eval("#")%>'>
                                                    Continuar Diligenciamiento
                                                </asp:LinkButton>
                                                <%}
                                                    else
                                                    { %>
                                                 <asp:LinkButton CausesValidation="false"
                                                    ID="buttonVerVersiones" runat="server"
                                                    CommandName="Ver"
                                                    CssClass="w3-button w3-bar-item"
                                                    CommandArgument='<%#Eval("#")%>'>
                                                    Ver Versiones
                                                </asp:LinkButton>
                                                 <asp:LinkButton CausesValidation="false"
                                                    ID="buttonEditar" runat="server"
                                                    CommandName="Editar"
                                                    CssClass="w3-button w3-bar-item"
                                                    CommandArgument='<%#Eval("#")%>'>
                                                    Editar
                                                </asp:LinkButton>
                                                 <asp:LinkButton CausesValidation="false"
                                                    ID="buttonGenerarPDF" runat="server"
                                                    CommandName="GenerarPDF"
                                                    CssClass="w3-button w3-bar-item"
                                                    CommandArgument='<%#Eval("#")%>'>
                                                    Generar PDF
                                                </asp:LinkButton>
                                                 <asp:LinkButton CausesValidation="false"
                                                    ID="buttonNuevaVersion" runat="server"
                                                    CommandName="NuevaVersion"
                                                    CssClass="w3-button w3-bar-item"
                                                    CommandArgument='<%#Eval("#")%>'>
                                                    Nueva Version
                                                </asp:LinkButton>
                                                <%}%>
                                                <asp:LinkButton CausesValidation="false"
                                                    ID="buttonConsultarPrograma" runat="server"
                                                    CommandName="Consultar"
                                                    CssClass="w3-button w3-bar-item"
                                                    CommandArgument='<%#Eval("#")%>'>
                                                    Consultar
                                                </asp:LinkButton>
                                               
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nivel Académico">
                                        <ItemTemplate>
                                            <div><%# Eval("#") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Programa Académico">
                                        <ItemTemplate>
                                            <div><%# Eval("#") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Modalidad">
                                        <ItemTemplate>
                                            <div><%# Eval("#") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Proceso">
                                        <ItemTemplate>
                                            <div><%# Eval("#") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemTemplate>
                                            <div><%# Eval("#") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col s12 m12 l12">
                            <p>&nbsp;</p>
                        </div>
                    </div>
                    <div class="w3-row-padding">
                        <div class="w3-col s12 m12 l12">
                            <asp:GridView ID="gridViewVersiones" runat="server"
                                AutoGenerateColumns="false"
                                ShowHeaderWhenEmpty="true"
                                AllowPaging="True" PageSize="5"
                                CssClass="w3-table-all w3-responsive"
                                OnRowCommand="gridViewVersiones_RowCommand"
                                OnRowUpdating="gridViewVersiones_RowUpdating"
                                OnRowDeleting="gridViewVersiones_RowDeleting"
                                OnPageIndexChanging="gridViewVersiones_PageIndexChanging"
                                Visible="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Opciones">
                                        <ItemTemplate>
                                            <div class="w3-bar">
                                                <asp:LinkButton ID="buttonGenerarPDF" runat="server"
                                                    CausesValidation="false"
                                                    CssClass="w3-button w3-bar-item"
                                                    CommandName="GenerarPDF"
                                                    CommandArgument='<%#Eval("#")%>'>
                                                    Generar PDF
                                                </asp:LinkButton>
                                                <asp:LinkButton CausesValidation="false"
                                                    ID="buttonConsultarVigencia" runat="server"
                                                    CommandName="Consultar"
                                                    CssClass="w3-button w3-bar-item"
                                                    CommandArgument='<%#Eval("#")%>'>
                                                    Consultar
                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Version">
                                        <ItemTemplate>
                                            <div><%# Eval("#") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemTemplate>
                                            <div><%# Eval("#") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsCPH" runat="server">
</asp:Content>
