<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" CodeBehind="Aulas.aspx.cs" Inherits="SIGAC.WEB.Vistas.Sistema.Aulas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleCPH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="server">
    <div class="GridContainer">
        <div class="panel panel-custom">
            <div class="panel-heading">
                <h4 class="panel-title">Busqueda de Aulas</h4>
                <h6 class="panel-text">Por Curso y/o por Nombre</h6>
            </div>
            <div class="panel-body">
                <div class="GridContainer">
                    <div class="GridRow">
                        <div class="col1">
                            <p>&nbsp;</p>
                        </div>
                        <%# Eval("AULAS") %>
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
                            <asp:GridView runat="server" ID="gridViewAulas"
                                AllowPaging="True"
                                CssClass="w3-table-all"
                                HeaderStyle-CssClass="GridCenter"
                                AutoGenerateColumns="False"
                                ShowHeaderWhenEmpty="True"
                                OnRowCommand="gridViewAsignaturas_RowCommand"
                                OnPageIndexChanging="gridViewAsignaturas_PageIndexChanging"
                                EmptyDataText="No ha sido encontrado ningun registro.">
                                <Columns>
                                    <asp:TemplateField HeaderText="Opciones">
                                        <ItemTemplate>
 <%--                                           <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument="<%# Eval("ID") %>" Text="Editar" />
                                            <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument="<%# Eval("ID") %>" Text="Eliminar" />
 --%>                                       </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:TemplateField HeaderText="Nombre del Aula">
                                        <ItemTemplate>
                                            <div class="GridCenter">
                                                <p><%# Eval("AULA") %></p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ubicacion del Aula">
                                        <ItemTemplate>
                                            <div class="GridCenter">
                                                <p><%# Eval("UBICACION") %></p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripcion del uso">
                                        <ItemTemplate>
                                            <div class="GridCenter">
                                                <p><%# Eval("DESCRIPCION") %></p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observaciones">
                                        <ItemTemplate>
                                            <div class="GridCenter">
                                                <p><%# Eval("NOTA") %></p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Recinto">
                                        <ItemTemplate>
                                            <div class="GridCenter">
                                                <p><%# Eval("RECINTO") %></p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Escuela">
                                        <ItemTemplate>
                                            <div class="GridCenter">
                                                <p><%# Eval("ESCUELA") %></p>
                                            </div>
                                        </ItemTemplate>
                                
                                    </asp:TemplateField>
                                </Columns>

<HeaderStyle CssClass="GridCenter"></HeaderStyle>
                            </asp:GridView>
                        </div>
                        <div class="col1">
                            <p>&nbsp;</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-custom" style="text-align: left">
            <div class="panel-heading">
                <h4 class="panel-title">Añadir/Editar</h4>
            </div>
            <div class="panel-body">
                <div class="GridContainer">
                    <div class="GridRow">
                        <div class="col4">
                            <asp:RequiredFieldValidator
                                ControlToValidate="textboxAula" Display="Dynamic" Text="*" ValidationGroup="FormVal"
                                ID="requiredAula" runat="server" ErrorMessage="Curso es requerido"></asp:RequiredFieldValidator>
                          <label>Aula</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             
                        </div>
                        <div class="col6">
                            <asp:TextBox runat="server" ID="textboxAula" CssClass="form-control" />
                        

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        

                        </div>
                    </div>
                    <div class="GridRow">
                        <div class="col4">
                            <asp:RequiredFieldValidator
                                ControlToValidate="textboxNombre" Display="Dynamic" Text="*" ValidationGroup="FormVal"
                                ID="requiredNombre" runat="server" ErrorMessage="Nombre es requerido"></asp:RequiredFieldValidator>
                            <label>Nombre</label>
                        </div>
                        <div class="col6">
                            <asp:TextBox runat="server" ID="textboxNombre" CssClass="form-control" />
                        </div>
                        <div class="col4">
                            <asp:RequiredFieldValidator
                                ControlToValidate="textboxUbicacion" Display="Dynamic" Text="*" ValidationGroup="FormVal"
                                ID="RequiredFieldUbicacion" runat="server" ErrorMessage="Nombre es requerido"></asp:RequiredFieldValidator>
                              <label>Ubicacion</label>

                        </div>
                             <div class="col6">
                            <asp:TextBox runat="server" ID="textboxUbicacion" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="GridRow">
                        <div class="col4">
                            <asp:RequiredFieldValidator
                                ControlToValidate="textboxDescripcion" Display="Dynamic" Text="*" ValidationGroup="FormVal"
                                ID="requiredDescripcion" runat="server" ErrorMessage="Descripcion es requerido"></asp:RequiredFieldValidator>
                            <label>Descripcion</label>
                        </div>
                        <div class="col6">
                            <asp:TextBox TextMode="MultiLine" ID="textboxDescripcion" Height="100px" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="GridRow">
                        <div class="col4">
                            <%# Eval("ESCUELA") %>
                            <label>Contenido</label>
                        </div>
                        <div class="col6">
                        </div>
                    </div>
                    <div class="GridRow">
                        <div class="col4">
                            <label>Nota</label>
                        </div>
                        <div class="col6">
                            <asp:TextBox TextMode="MultiLine" ID="textboxObservacion" Height="100px" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="GridRow">
                        <div class="col4">
                            <asp:RequiredFieldValidator
                                ControlToValidate="comboboxRecintos" Display="Dynamic" Text="*" ValidationGroup="FormVal"
                                ID="requiredRecinto" runat="server" ErrorMessage="Nombre es requerido"></asp:RequiredFieldValidator>
                           <label>Recintos</label>
                        </div>
                        <div class="col6">
                            <ajax:ComboBox ID="comboboxRecintos" runat="server" AutoCompleteMode="SuggestAppend"
                                CaseSensitive="false" DropDownStyle="DropDownList" CssClass="form-control" Width="250px">
                            </ajax:ComboBox>
                        </div>

                         <div class="col4">
                            <asp:RequiredFieldValidator
                                ControlToValidate="comboboxEscuela" Display="Dynamic" Text="*" ValidationGroup="FormVal"
                                ID="RequiredFieldEscuela" runat="server" ErrorMessage="Nombre es requerido"></asp:RequiredFieldValidator>
                            <label>Escuela</label>
                        </div>
                        <div class="col6">
                            <ajax:ComboBox ID="comboboxEscuela" runat="server" AutoCompleteMode="SuggestAppend"
                                CaseSensitive="false" DropDownStyle="DropDownList" CssClass="form-control" Width="250px">
                            </ajax:ComboBox>
                        </div>
                 
                        <div class="col6">
                            <asp:LinkButton ID="btneditar" runat="server" Visible="True" TabIndex="17" CssClass="btn btn-primary" Width="100px"><span class="glyphicon glyphicon-search"></span>&nbsp; Editar</asp:LinkButton>
                            <asp:LinkButton ID="btnGrabar" runat="server" Visible="True" TabIndex="17" CssClass="btn btn-success" Width="140px"><span class="glyphicon glyphicon-file"></span>&nbsp; Grabar</asp:LinkButton>
                            <asp:LinkButton ID="btncancelar" runat="server" Visible="True" TabIndex="17" CssClass="btn btn-danger" Width="160px"><span class="glyphicon glyphicon-ok"></span>&nbsp; Cancelar</asp:LinkButton>
                        </div>


                </div>

                    </div>
        
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsCPH" runat="server">
</asp:Content>
