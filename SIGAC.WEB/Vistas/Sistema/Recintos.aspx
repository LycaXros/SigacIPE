<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" CodeBehind="Recintos.aspx.cs" Inherits="SIGAC.WEB.Vistas.Sistema.Recintos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleCPH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="server">
    <div class="GridContainer">
        <div class="panel panel-custom">
            <div class="panel-heading">
                <h4 class="panel-title">Busqueda de Recintos</h4>
                <h6 class="panel-text">Por Nombre</h6>
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
                                    <ItemTemplate>
                                        <asp:LinkButton ID="editBtn" runat="server"
                                                    CausesValidation="false"
                                                    CssClass="w3-button w3-bar-item"
                                                    CommandName="Edit" OnClick="accionBtn_Click"
                                                    CommandArgument='<%#Eval("ID")%>'>
                                                    Editar
                                                </asp:LinkButton>
                                        &nbsp;|&nbsp;
                                        <asp:LinkButton ID="deleteBtn" runat="server"
                                                    CausesValidation="false"
                                                    CssClass="w3-button w3-bar-item"
                                                    CommandName="Delete" OnClick="accionBtn_Click"
                                                    CommandArgument='<%#Eval("ID")%>'>
                                                    Eliminar
                                                </asp:LinkButton>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="Id del Recinto" SortExpression="ID" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre del Recinto" />
                                <asp:BoundField DataField="DIRECCION" HeaderText="Direccion del Recinto" />
                                <asp:BoundField DataField="TELEFONO1" HeaderText="1er Telefono" />
                                <asp:BoundField DataField="TELEFONO2" HeaderText="2do Telefono" />
                                <asp:TemplateField>
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
        <div class="panel panel-custom">
            <div class="panel panel-heading">
                <asp:Label ID="lblAccion" runat="server" Text="Añadir"></asp:Label>
            </div>
            <style>
                .inputStyle {
                
                    width:350px;
                    height:auto;
                
                }

            </style>
            <div class="panel panel-body">
                <div class="GridRow">
                    <div class="col4">
                        <asp:RequiredFieldValidator
                            ControlToValidate="txtNombre" Display="Dynamic"  Text="*" ValidationGroup="FormVal"
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nombre es requerido"></asp:RequiredFieldValidator>
                        <label>Nombre del Recinto:</label>
                    </div>
                    <div class="col6">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="inputStyle" />
                    </div>
                </div>
                <br />
                <div class="GridRow">
                    <div class="col4">
                        <asp:RequiredFieldValidator
                            ControlToValidate="txtDir" Display="Dynamic"  Text="*" ValidationGroup="FormVal"
                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="Direccion es requerida"></asp:RequiredFieldValidator>
                        <label>Direccion del Recinto:</label>
                    </div>
                    <div class="col6">
                        <asp:TextBox ID="txtDir" runat="server" CssClass="inputStyle"/>
                    </div>
                </div>
                <br />
                <div class="GridRow">
                    <div class="col4">
                        <asp:RequiredFieldValidator
                            ControlToValidate="txtTel1" Display="Dynamic"  Text="*" ValidationGroup="FormVal"
                            ID="RequiredFieldValidator3" runat="server" ErrorMessage="Telefono es requerido"></asp:RequiredFieldValidator>
                        <label>1er Telefono:</label>
                    </div>
                    <div class="col6">
                        <asp:TextBox ID="txtTel1" TextMode="Phone" runat="server" />
                    </div>
                </div>
                <br />
                <div class="GridRow">
                    <div class="col4">
                        <label>2do Telefono:</label>
                    </div>
                    <div class="col6">
                        <asp:TextBox ID="txtTel2" TextMode="Phone" runat="server" />
                    </div>
                </div>
                <br />
                <div class="GridRow">
                    <div class="col4">
                        <label>Notas:</label>
                    </div>
                    <div class="col6">
                        <asp:TextBox ID="txtNotas" TextMode="MultiLine" runat="server" Height="200px" Width="400" />
                    </div>
                </div>
                <br />
                <div class="GridRow">
                    <div class="col4">
                        <label>Estado:</label>
                    </div>
                    <div class="col6">
                        <asp:DropDownList ID="ddlEstado" runat="server">
                            <asp:ListItem Text="Activo" Value="1" />
                            <asp:ListItem Text="Inactivo" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="FormVal" ShowMessageBox="false" ShowSummary="true" />
                <br />
                <div class="w3-content">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary"
                        Text="Agregar" ValidationGroup="FormVal" 
                        OnClick="btnAdd_Click" CommandName="Add"/> &nbsp;
                    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-info" 
                        Text="Modificar" ValidationGroup="FormVal"
                        OnClick="btnAdd_Click" CommandName="Mod"/> &nbsp;
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click"/> &nbsp;

                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsCPH" runat="server">
</asp:Content>
