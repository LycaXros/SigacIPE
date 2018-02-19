<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" CodeBehind="Coberturas.aspx.cs" Inherits="SIGAC.WEB.Vistas.AdministrarPAE.Coberturas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="server">
    <div class="GridContainer">
        <div class="panel panel-custom">
            <div class="panel-heading">
                <h4 class="panel-title">Busqueda de Coverturas</h4>
                <h6 class="panel-text">Por Nombre</h6>
            </div>
            <div class="panel-body">
                <div class="GridContainer">
                    <div class="GridRow">
                        <div class="col1">

                            <table border="0" class="auto-style1" style="border-spacing: 0;">
                                <tr>
                                    <td align="center" width="80px">Vigencia:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlVigencia" runat="server" AutoPostBack="false" BackColor="#EEEEEE" CssClass="chosen-select" Height="30px" TabIndex="15" Width="220px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" width="80px">Escuela:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlEscuela" runat="server" AutoPostBack="false" BackColor="#EEEEEE" CssClass="chosen-select" Height="30px" TabIndex="15" Width="220px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center" width="80px">&nbsp;&nbsp;</td>
                                    <td align="center" width="80px">Estrategia:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlEstrategia" runat="server" AutoPostBack="false" BackColor="#EEEEEE" CssClass="chosen-select" Height="30px" TabIndex="15" Width="220px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-success" TabIndex="17" Visible="True" Width="140px" OnClick="btnBuscar_Click"><span class="glyphicon glyphicon-search"></span>&nbsp; Buscar</asp:LinkButton>
                                        &nbsp;</td>
                                    <td>&nbsp;&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="btnAgregar0" runat="server" CssClass="btn btn-primary" TabIndex="17" Visible="True" Width="140px"><span class="glyphicon glyphicon-plus"></span>&nbsp; Agregar</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>

                        </div>
                        <div class="col8">
                            <div class="input-group">
                                <div class="input-group-btn">
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
                        <p>
                            <asp:GridView ID="gv_menu" runat="server" AutoGenerateColumns="False" 
                                CssClass="grid sortable {disableSortCols: [1]} " Width="930px" 
                               >
                                <Columns>
                                    <asp:BoundField DataField="no" HeaderText="Codigo." SortExpression="no">
                                        <HeaderStyle CssClass="celdaHead" Width="70px" />
                                        <ItemStyle CssClass="celdaCenter" />
                                    </asp:BoundField>
                                    <asp:ButtonField CommandName="ver" HeaderText="Ver" Text="Ver">
                                        <HeaderStyle CssClass="celdaHead" Width="15px" />
                                        <ItemStyle CssClass="celdaCenter" />
                                    </asp:ButtonField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Vigencia">
                                        <HeaderStyle CssClass="celdaHead" Width="200px" />
                                        <ItemStyle CssClass="celdaJust" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="posicion" HeaderText="Estrategia">
                                        <HeaderStyle CssClass="celdaHead" Width="100px" />
                                        <ItemStyle CssClass="celdaJust" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="padre" HeaderText="Unidad">
                                        <HeaderStyle CssClass="celdaHead" Width="100px" />
                                        <ItemStyle CssClass="celdaCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="habilitado" HeaderText="Observacion">
                                        <HeaderStyle CssClass="celdaHead" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Estatus">
                                        <HeaderStyle CssClass="celdaHead" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </p>
                    </div>

                </div>
            </div>
            <div class="panel panel-custom">
                <div class="panel panel-heading">
                </div>
                <style>
                    .inputStyle {
                        width: 350px;
                        height: auto;
                    }

                    .ajax__combobox_buttoncontainer button {
                        background-image: url('mvwres://AjaxControlToolkit, Version=18.1.0.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e/AjaxControlToolkit.Images.ComboBox.Arrow-Down.gif');
                        background-position: center;
                        background-repeat: no-repeat;
                        border-color: ButtonFace;
                        height: 15px;
                        width: 15px;
                    }

                    .tableCellSpacing { /* Table espaciado entre cada celda*/
                        border-collapse: separate;
                        border-spacing: 10px;
                    }

                    tbody {
                        margin: 0;
                        padding: 0;
                        border: 0;
                        font-size: 100%;
                        font: inherit;
                        vertical-align: baseline;
                    }

                    .auto-style1 {
                        border-collapse: collapse;
                        font-size: 100%;
                        vertical-align: baseline;
                        border-style: none;
                        border-color: inherit;
                        border-width: 0;
                        margin: 0;
                        padding: 0;
                        background-color: transparent;
                    }
                </style>
                <div class="panel panel-body">
                    <div class="GridRow">


                        <div class="col4">
                        </div>

                        <div class="col6">
                        </div>


                        <div class="col4">
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>

