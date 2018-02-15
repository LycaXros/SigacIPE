<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" CodeBehind="Adm_Pae.aspx.cs" Inherits="SIGAC.WEB.Vistas.Adm_Pae"  %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="style" runat="server" ContentPlaceHolderID="StyleCPH">
    <link href="../../Content/CSS/GridStyles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h4 class="panel-title">Administracion del PAE</h4>
            </div>
            <div class="panel-body">
                <div class="w3-container">
                    <div class="GridRow">
                        <div class="col1">&nbsp;</div>
                        <div class="col3">
                            <label>Vigencia:</label>

                            <asp:DropDownList ID="ddlVigencia" runat="server" AutoPostBack="false" CssClass="chosen-select" TabIndex="15" BackColor="#EEEEEE" Width="120px" Height="30px"></asp:DropDownList>
                        </div>
                        <div class="col6">
                            <asp:LinkButton ID="btnBuscar" runat="server" Visible="True" TabIndex="17" CssClass="btn btn-success" OnClick="btnBuscar_Click" Width="100px"><span class="glyphicon glyphicon-search"></span>&nbsp; Buscar</asp:LinkButton>
                            <asp:LinkButton ID="btnGenerarPAE" OnClick="btnGenerarPAE_Click" runat="server" Visible="false"  Enable="False" TabIndex="17" CssClass="btn btn-success" Width="140px"><span class="glyphicon glyphicon-file"></span>&nbsp; Generar PAE</asp:LinkButton>
                            <asp:LinkButton ID="btnActivarVigencia"  OnClick="btnActivarVigencia_Click" runat="server" Visible="False" Enabled="false" TabIndex="17" CssClass="btn btn-success" Width="160px"><span class="glyphicon glyphicon-ok"></span>&nbsp; Activar Vigencia</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Panel ID="pn_resultados" runat="server">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">Consultas</h4>
                    </div>
                    <div class="panel panel-primary" style=" overflow: scroll; margin-left: 10px; padding: 15px; margin-top: 10px;">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvAdministrarPae" runat="server" AutoGenerateColumns="False" CssClass="grid sortable {disableSortCols: [1]} " AllowPaging="True" EmptyDataText="**NO HAY DATOS QUE MOSTRAR**" PageSize="7" ShowFooter="True" ShowHeaderWhenEmpty="True">
                                        <Columns>
                                            <asp:BoundField DataField="Vigencia" HeaderText="VIGENCIA" SortExpression="Vigencia">
                                                <HeaderStyle CssClass="celdaHead" Width="70px" />
                                                <ItemStyle CssClass="celdaCenter" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Procedimiento"
                                                 HeaderText="PROCEDIMIENTO"></asp:BoundField>

                                            <asp:BoundField DataField="Tipo_Documento"
                                                 HeaderText="TIPO DE DOCUMENTO"></asp:BoundField>

                                            <asp:BoundField DataField="Numero_Documento"
                                                  HeaderText="NUMERO DE DOCUMENTO"></asp:BoundField>

                                            <asp:BoundField DataField="Fecha_Documento"
                                                  HeaderText="FECHA DE DOCUMENTO"></asp:BoundField>

                                            <asp:BoundField DataField="Observacion"
                                                  HeaderText="OBSERVACIONES"></asp:BoundField>
                                            <asp:TemplateField HeaderText="ANEXO">
                                                <ItemTemplate>
                                                    <a href="<%# Eval("Link") %>" download="<%# Eval("Titulo") %>" target="_blank" ><%# Eval("Titulo") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField  DataField="Usuario"
                                                 HeaderText="USUARIO"></asp:BoundField>
                                            <asp:BoundField  DataField="Fecha"
                                                  HeaderText="FECHA PROCEDIMIENTO"></asp:BoundField>

                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>

            <div id="idModal" class="w3-modal">

                <div class="w3-modal-content">
                    <div class="w3-container">
                        <span onclick="document.getElementById('idModal').style.display='none'" class="w3-button w3-display-topright">&times;</span>
                        <div class="">
                            <h3>Datos del Documento</h3>
                            <hr />
                            <div class="GridRow">
                                <div class="col5">
                                    <label>TIPO DE DOCUMENTO</label>
                                </div>
                                <div class="col5">
                                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="GridRow">
                                <div class="col5">
                                    <label>NUMERO DE DOCUMENTO</label>
                                </div>
                                <div class="col5">
                                    <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <br />
                            <div class="GridRow">
                                <div class="col5">
                                    <label>FECHA DE DOCUMENTO</label>
                                </div>
                                <div class="col5">
                                    <input id="fechaDoc" runat="server" type="date" class="form-control" />
                                </div>

                            </div>
                            <br />
                            <div class="GridRow">
                                <div class="col5">
                                    <label>OBSERVACIONES</label>
                                </div>
                                <div class="col5">
                                    <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" CssClass="form-control" Height="200"></asp:TextBox>

                                </div>

                            </div>
                            <br />
                            <div class="GridRow">
                                <div class="col5">
                                    <label>ANEXO</label>
                                </div>
                                <div class="col5">
                                    <asp:Label ID="lbAnexo" runat="server" Text="Label"></asp:Label>
                                    <asp:FileUpload ID="fuAnexo" runat="server" AllowMultiple="false"/>
                                </div>

                            </div>
                            <br />
                            <div class="GridRow">
                                <div class="col5">
                                    &nbsp;
                                </div>
                                <div class="col2">
                                    &nbsp;
                                </div>
                                <div class="col3">
                                    <span onclick="document.getElementById('idModal').style.display='none'" class="btn btn-danger">CANCELAR</span>
                                    <asp:Button CommandName="" ID="btnGuardarVigenciaPae" runat="server" Text="GUARDAR" CssClass="btn btn-primary" OnClick="btnGuardarVigenciaPae_Click" />
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptsCPH">
    <script type="text/javascript">
        function OpenModal(idM) {
            document.getElementById(idM).style.display = 'block';
        }
    </script>
</asp:Content>
