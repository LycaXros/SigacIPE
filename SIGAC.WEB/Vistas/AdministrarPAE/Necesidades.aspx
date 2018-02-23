<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" CodeBehind="Necesidades.aspx.cs" Inherits="SIGAC.WEB.Vistas.AdministrarPAE.Necesidades" %>

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
                <table border="0" class="auto-style1" style="border-spacing: 0;">
                    <tbody>
                        <tr>
                            <td>VIGENCIA
                                &nbsp;
                                &nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="BuscarVigenciaDDL" runat="server">
                                </asp:DropDownList>
                                &nbsp;
                                &nbsp;
                            </td>
                            <td>ESCUELA
                                &nbsp;
                                &nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="BuscarEscuelaDDL" runat="server">
                                </asp:DropDownList>
                                &nbsp;
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button Text="Buscar" runat="server"
                                    CssClass="btn btn-info"
                                    CommandName="Buscar" OnClick="BuscarBTN_Click" />
                                &nbsp;
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button Text="Agregar" runat="server"
                                    CssClass="btn btn-success"
                                    CommandName="Agregar" OnClick="BuscarBTN_Click" />
                                &nbsp;
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button Text="Asociar Proceso" runat="server"
                                    CssClass="btn btn-secondary"
                                    CommandName="Asociar" OnClick="BuscarBTN_Click" />
                                &nbsp;
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

            <asp:Panel ID="pn_resultados" runat="server">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">Consultas</h4>
                    </div>
                    <div class="panel panel-primary" style="overflow: scroll; margin-left: 10px; padding: 15px; margin-top: 10px;">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvAdministrarPae" runat="server"
                                        AutoGenerateColumns="False" CssClass="grid sortable {disableSortCols: [1]} "
                                        AllowPaging="True" EmptyDataText="**NO HAY DATOS QUE MOSTRAR**" PageSize="7"
                                        ShowFooter="True" ShowHeaderWhenEmpty="True">

                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                                            <asp:BoundField HeaderText="REGIONAL"></asp:BoundField>
                                            <asp:BoundField HeaderText="UNIDAD FISICA"></asp:BoundField>
                                            <asp:BoundField HeaderText="UNIDAD DEPENDE"></asp:BoundField>
                                            <asp:BoundField HeaderText="NIVEL ACADEMICO"></asp:BoundField>
                                            <asp:BoundField HeaderText="PROGRAMA ACADEMICO"></asp:BoundField>
                                            <asp:BoundField HeaderText="NECESIDAD"></asp:BoundField>
                                            <asp:BoundField HeaderText="PROCESO"></asp:BoundField>
                                            <asp:BoundField HeaderText="ESTRATEGIA"></asp:BoundField>
                                            <asp:BoundField HeaderText="ORIGEN"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>

            <%-- MODAL Agregar --%>
            <div id="modalAgregar" class="w3-modal">

                <div class="w3-modal-content">
                    <div class="w3-container">
                        <span onclick="document.getElementById('modalAgregar').style.display='none'" class="w3-button w3-display-topright">&times;</span>
                        <div class="">
                            <asp:HiddenField runat="server" ID="AgregarVigenciaHidden" />
                            <table class="table table-striped ">
                                <thead class="thead-dark">
                                    <tr>
                                        <th colspan="3">&nbsp;</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>REGIONAL</td>
                                        <td>
                                            <asp:DropDownList ID="AgregarRegionalDDL" runat="server"
                                                OnSelectedIndexChanged="AgregarRegionalDDL_SelectedIndexChanged"
                                                Enabled="false" CssClass="form-control">
                                                <asp:ListItem Value="-1">Seleccione</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>UNIDAD FISICA</td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="AgregarU_FisicaDDL" runat="server"
                                                Enabled="false" CssClass="form-control">
                                                <asp:ListItem Value="-1">Seleccione</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>UNIDAD DEPENDE</td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="AgregarU_DependeDDL" runat="server"
                                                CssClass="form-control" AppendDataBoundItems="true">
                                                <asp:ListItem Value="-1">Seleccione</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>NIVEL ACADEMICO</td>
                                        <td>
                                            <asp:DropDownList ID="AgregarNivelDDL" runat="server" OnSelectedIndexChanged="AgregarNivelDDL_SelectedIndexChanged"
                                                CssClass="form-control">
                                                <asp:ListItem Value="-1">Seleccione</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>PROGRAMA ACADEMICO</td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="AgregarProgramaDDL" runat="server"
                                                Enabled="false" CssClass="form-control">
                                                <asp:ListItem Value="-1">Seleccione</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>NECESIDAD</td>
                                        <td>
                                            <asp:TextBox ID="AgregarNecesidadTbox" runat="server"
                                                CssClass="form-control" MaxLength="6" TextMode="Number"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="2">&nbsp</td>
                                        <td>
                                            <span onclick="document.getElementById('modalAgregar').style.display='none'" class="btn btn-danger">CANCELAR</span>
                                            &nbsp;
                                            <asp:Button CommandName="" ID="btnAgregar" runat="server" Text="GUARDAR" CssClass="btn btn-primary" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;
                                        </td>
                                    </tr>

                                </tfoot>
                            </table>

                            <br />
                        </div>
                    </div>
                </div>
            </div>

            <%-- Modal Asociar Proceso --%>

            <div id="modalAsociar" class="w3-modal">

                <div class="w3-modal-content">
                    <div class="w3-container">

                        <asp:HiddenField runat="server" ID="AsociarVigenciaHidden" />
                        <span onclick="document.getElementById('modalAsociar').style.display='none'" class="w3-button w3-display-topright">&times;</span>
                        <div class="">

                            <asp:ListView ID="ListView1" runat="server"
                                GroupPlaceholderID="groupPlacehoder1"
                                ItemPlaceholderID="itemsPlaceholder">
                                <LayoutTemplate>

                                    <table class="table table-striped">
                                        <thead>
                                            <tr>
                                                <th>NIVEL ACADEMICO</th>
                                                <th colspan="2">PROGRAMA ACADEMICO</th>
                                                <th>PROCESO</th>
                                                <th>ESTRATEGIA</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder runat="server" ID="groupPlacehoder1"></asp:PlaceHolder>
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="4">&nbsp;</td>
                                                <td>
                                                    <span onclick="document.getElementById('modalAsociar').style.display='none'" class="btn btn-danger">CANCELAR</span>
                                                    &nbsp;
                                            <asp:Button CommandName="" ID="Button1" runat="server" Text="GUARDAR" CssClass="btn btn-primary" />

                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>

                                </LayoutTemplate>
                                <GroupTemplate>
                                    <tr>
                                        <asp:PlaceHolder runat="server" ID="itemsPlaceholder"></asp:PlaceHolder>
                                    </tr>
                                </GroupTemplate>
                                <ItemTemplate>

                                    <td> <%# Eval("NivelAcademico") %></td>
                                    <td colspan="2"> <%# Eval("ProgramaAcademico") %></td>
                                    <td> <%# Eval("ProcesoName") %></td>
                                    <td> <%# Eval("EstrategiaName") %></td>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <td> <%# Eval("NivelAcademico") %></td>
                                    <td colspan="2"> <%# Eval("ProgramaAcademico") %></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlProceso"></asp:DropDownList>
                                    </td>
                                </EditItemTemplate>
                                <EmptyDataTemplate>
                                    <h3>No hay Datos que mostrar</h3>
                                </EmptyDataTemplate>
                            </asp:ListView>


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
