<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" CodeBehind="Adm_Pae.aspx.cs" Inherits="Sigac.WEB.Vistas.Adm_Pae" %>

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
                            <asp:LinkButton ID="btnGenerarPAE" runat="server" Visible="True" TabIndex="17" CssClass="btn btn-success" Width="140px"><span class="glyphicon glyphicon-file"></span>&nbsp; Generar PAE</asp:LinkButton>
                            <asp:LinkButton ID="btnActivarVigencia" runat="server" Visible="True" TabIndex="17" CssClass="btn btn-success" Width="160px"><span class="glyphicon glyphicon-ok"></span>&nbsp; Activar Vigencia</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Panel ID="pn_resultados" runat="server">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">Consultas</h4>
                    </div>
                    <div class="panel panel-primary" style="width: 980px; overflow: scroll; margin-left: 10px; padding: 15px; margin-top: 10px;">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvAdministrarPae" runat="server" AutoGenerateColumns="False" Width="930px" CssClass="grid sortable {disableSortCols: [1]} " AllowPaging="True" EmptyDataText="**NO HAY DATOS QUE MOSTRAR**" PageSize="7" ShowFooter="True" ShowHeaderWhenEmpty="True">
                                        <Columns>
                                            <asp:BoundField DataField="no" HeaderText="Codigo." SortExpression="no">
                                                <HeaderStyle CssClass="celdaHead" Width="70px" />
                                                <ItemStyle CssClass="celdaCenter" />
                                            </asp:BoundField>
                                            <asp:ButtonField CommandName="ver" HeaderText="Ver" Text="Ver">
                                                <HeaderStyle CssClass="celdaHead" Width="15px" />
                                                <ItemStyle CssClass="celdaCenter" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Tipo Documento">
                                                <HeaderStyle CssClass="celdaHead" Width="200px" />
                                                <ItemStyle CssClass="celdaJust" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="posicion" HeaderText="Numero">
                                                <HeaderStyle CssClass="celdaHead" Width="100px" />
                                                <ItemStyle CssClass="celdaJust" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="padre" HeaderText="Fecha Doc.">
                                                <HeaderStyle CssClass="celdaHead" Width="100px" />
                                                <ItemStyle CssClass="celdaCenter" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="habilitado" HeaderText="Observacion">
                                                <HeaderStyle CssClass="celdaHead" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Anexo">
                                                <HeaderStyle CssClass="celdaHead" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Estatus">
                                                <HeaderStyle CssClass="celdaHead" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
