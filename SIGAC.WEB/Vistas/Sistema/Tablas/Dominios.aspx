<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" CodeBehind="Dominios.aspx.cs" Inherits="SIGAC.WEB.Vistas.Sistema.Tablas.Dominios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="server">

    <div class="container">

        <div class="row">
            <div class="col-sm-12 col-md-2">&nbsp;</div>
            <div class="col-sm-12 col-md-10">
                <h2>Formulario para agregar Dominios y Tipos de Dominio</h2>
                <hr />
                <div class="w3-container">
                    <div class="w3-row">
                        <div class="w3-half">
                            <div class="=GridRow">

                                <div class="col2">
                                    <label>Nombre del Tipo de Dominio</label>
                                    <asp:TextBox ID="TxtNuevoTipo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col2">
                                    <label>Descripcion del Tipo de Dominio</label>
                                    <asp:TextBox ID="TxtDescripcionNuevo" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="col2">
                                    <asp:Button ID="BtnAgregarTipoDominio" runat="server"
                                        OnClick="BtnAgregarTipoDominio_Click"
                                        Text="Agregar Tipo de Dominio" CssClass="btn btn-success" />

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <%--   
                              <asp:Button ID="BtnAgregarDominio" runat="server"
                                OnClick="BtnAgregarDominio_Click"
                                Text="Agregar Dominio" CssClass="btn btn-success" />
                --%>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                &nbsp;
            <asp:GridView ID="gridTipoDeDominio"
                AutoGenerateColumns="false" CssClass="table table-striped"
                OnRowCommand="gridTipoDeDominio_RowCommand" runat="server">

                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nom" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Desc" />
                    <asp:BoundField HeaderText="Cantidad de Dominios" DataField="Cant" />
                    <asp:TemplateField HeaderText="Acciones" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton runat='server' Text="Agregar Dominio"
                                CommandName="Agregar" CommandArgument='<%# Eval("ID") %>'
                                CausesValidation="false" ID='LinkButton1'></asp:LinkButton>
                            &nbsp;|&nbsp;
                        <asp:LinkButton runat='server' Text="Ver Dominios"
                            CommandName="Ver" CommandArgument='<%# Eval("ID") %>'
                            CausesValidation="false" ID='LinkButton2'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>

    <div id="newDomain" class="w3-modal">

        <div class="w3-modal-content">
            <div class="w3-container">
                <asp:HiddenField ID="Id_tipo" runat="server" />
                <span onclick="document.getElementById('newDomain').style.display='none'" class="w3-button w3-display-topright">&times;</span>
                <div class="w3-row">
                    <div class="w3-col s12 m1">&nbsp;</div>
                    <div class="w3-col s12 m10">
                        <br />
                        <h3>
                            <asp:Label ID="LabelTituloDom" runat="server"></asp:Label>
                        </h3>
                            <div class="=GridRow">

                                <div class="col2">
                                    <label>Nombre del Dominio</label>
                                    <asp:TextBox ID="txtNombreDom" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col2">
                                    <label>Descripcion del Dominio</label>
                                    <asp:TextBox ID="txtDescDom" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="col2">
                                    <label>Vigencia del Dominio</label>
                                    <asp:TextBox ID="txtVigenciaDom" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="col2">
                                    <asp:Button ID="Button1" runat="server"
                                        OnClick="BtnAgregarDominio_Click"
                                        Text="Agregar" CssClass="btn btn-success" />

                                </div>

                            </div>
                        <br />
                    </div>
                    <div class="w3-col s12 m1">&nbsp;</div>

                </div>
            </div>
        </div>
    </div>

    <div id="listaDominio" class="w3-modal">
        <br />
        <div class="w3-modal-content">
            <div class="w3-container">
                <span onclick="document.getElementById('listaDominio').style.display='none'" class="w3-button w3-display-topright">&times;</span>
                <div class="w3-row">
                    <div class="w3-col s12 m1">&nbsp;</div>
                    <div class="w3-col s12 m10">
                        <h3>
                            <asp:Label ID="LabelTitle" runat="server"></asp:Label>
                        </h3>
                        <asp:ListView ID="listadoDominos" runat="server">

                            <ItemTemplate>
                                <tr style="">
                                    <td>
                                        <asp:Label Text='<%# Eval("NOMBRE") %>' runat="server" ID="NOMBRELabel" /></td>
                                    <td>
                                        <asp:Label Text='<%# Eval("DESCRIPCION") %>' runat="server" ID="DESCRIPCIONLabel" /></td>
                                    <td>
                                        <asp:Label Text='<%# Eval("VIGENTE") %>' runat="server" ID="VIGENTELabel" /></td>
                                </tr>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <table runat="server">
                                    <tr runat="server">
                                        <td runat="server">
                                            <table runat="server" id="itemPlaceholderContainer" class="table table-striped" border="0">
                                                <thead>
                                                    <tr runat="server" style="">
                                                        <th runat="server">NOMBRE</th>
                                                        <th runat="server">DESCRIPCION</th>
                                                        <th runat="server">VIGENTE</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr runat="server" id="itemPlaceholder"></tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td runat="server" style="">
                                            <asp:DataPager runat="server" ID="DataPager1">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                                    <asp:NumericPagerField></asp:NumericPagerField>
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                                </Fields>
                                            </asp:DataPager>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:ListView>
                        <br />
                    </div>
                    <div class="w3-col s12 m1">&nbsp;</div>

                </div>
            </div>
        </div>
        <br />
    </div>




</asp:Content>


<asp:Content runat="server" ContentPlaceHolderID="ScriptsCPH">
    <script type="text/javascript">
        function OpenModal(idM) {
            document.getElementById(idM).style.display = 'block';
        }
    </script>
</asp:Content>
