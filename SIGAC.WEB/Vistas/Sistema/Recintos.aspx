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
                    <div class="col8 w3-responsive">
                        <asp:GridView runat="server" ID="gridViewRecintos" DataKeyNames="ID" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True"
                            AllowPaging="True" CssClass="w3-table-all" OnRowDataBound="gridViewRecintos_RowDataBound"
                            OnRowUpdating="gridViewRecintos_RowUpdating" OnRowEditing="gridViewRecintos_RowEditing"
                            OnRowDeleting="gridViewRecintos_RowDeleting" OnRowCancelingEdit="gridViewRecintos_RowCancelingEdit"
                            OnPageIndexChanging="gridViewRecintos_PageIndexChanging" EmptyDataText="No se han encontrado registros."
                            >

                            <Columns>
                                
                                <asp:CommandField ButtonType="Link" HeaderText="Opciones"
                                    ShowEditButton="true" ShowDeleteButton="true"
                                    EditText="Editar" DeleteText="Eliminar" />
                                <asp:TemplateField HeaderText="Id del Recinto" SortExpression="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Nombre del Recinto">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="e_txtNombre" runat="server" Text='<%# Eval("NOMBRE")%>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField  HeaderText="Direccion del Recinto">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDir" runat="server" Text='<%# Eval("DIRECCION") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="e_txtDir" runat="server" Text='<%# Eval("DIRECCION") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField  HeaderText="1er Telefono">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTel1" runat="server" Text='<%# Eval("TELEFONO1") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="e_txtTel1" TextMode="Phone" Text='<%# Eval("TELEFONO1") %>' runat="server" />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="2do Telefono">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTel2" runat="server" Text='<%# Eval("TELEFONO2") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="e_txtTel2" TextMode="Phone" Text='<%# Eval("TELEFONO2") %>' runat="server" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Notas">
                                    <ItemTemplate>
                                       <p id="lbNotas" runat="server"> <%#Eval("TransformNota") %></p>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="e_txtNotas" TextMode="MultiLine" runat="server" Height="200px" Width="100" 
                                            Text='<%#Eval("TransformNota") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("ESTATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="e_ddlEstado" runat="server"  >
                                            <asp:ListItem Text="Activo" Value="1"  />
                                            <asp:ListItem Text="Inactivo" Value="0" />
                                        </asp:DropDownList>
                                    </EditItemTemplate>
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
        <div class="panel panel-custom">
            <div class="panel panel-heading">
                <asp:Label ID="lblAccion" runat="server" Text="Añadir"></asp:Label>
            </div>
            <style>
                .inputStyle {
                    width: 350px;
                    height: auto;
                }
            </style>
            <div class="panel panel-body">
                <div class="GridRow">
                    <div class="col4">
                        <asp:RequiredFieldValidator
                            ControlToValidate="txtNombre" Display="Dynamic" Text="*" ValidationGroup="FormVal"
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
                            ControlToValidate="txtDir" Display="Dynamic" Text="*" ValidationGroup="FormVal"
                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="Direccion es requerida"></asp:RequiredFieldValidator>
                        <label>Direccion del Recinto:</label>
                    </div>
                    <div class="col6">
                        <asp:TextBox ID="txtDir" runat="server" CssClass="inputStyle" />
                    </div>
                </div>
                <br />
                <div class="GridRow">
                    <div class="col4">
                        <asp:RequiredFieldValidator
                            ControlToValidate="txtTel1" Display="Dynamic" Text="*" ValidationGroup="FormVal"
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
                        OnClick="btnAdd_Click" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger"
                        Text="Cancelar" OnClick="btnCancelar_Click" />


                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsCPH" runat="server">
</asp:Content>
