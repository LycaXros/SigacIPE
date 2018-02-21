<%@ Page Title="" Language="C#" MasterPageFile="~/SIGAC.Master" AutoEventWireup="true" EnableEventValidation="false" EnableViewState="false" CodeBehind="Necesidad_Cap.aspx.cs" Inherits="Sigac.WEB.Vistas.AdministrarPAE.Necesidad_Cap" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="server">
    
    <!--Modal Scripts-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js" type="text/javascript"></script> 
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js" type="text/javascript"></script> 
    <!--Modal Scripts-->    

    <!--Body Content INICIO-->
    <!--Panel Principal INICIO-->
    <div class="panel panel-primary">
        <!--Panel Principal Header INICIO-->
        <div class="panel-heading">
            <h4 class="panel-title">Administracion del PAE Capacitacion</h4>
        </div>
        <!--Panel Principal Header FIN-->
        <!--Panel Principal Filtros INICIO-->
        <div class="panel-body">
            <div class="row">
                <div class="col-md-1">
                    <p class="textoFiltro">Vigencia:</p>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlVigencia" runat="server" AutoPostBack="false" CssClass="chosen-select" TabIndex="15" BackColor="#EEEEEE" Width="120px" Height="30px"></asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <p class="textoFiltro">Escuela:</p>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlEscuela" runat="server" AutoPostBack="false" CssClass="chosen-select" TabIndex="15" BackColor="#EEEEEE" Width="120px" Height="30px"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:LinkButton ID="btnBuscar" runat="server" Visible="True" TabIndex="17" CssClass="btn btn-success" Width="140px"><span class="glyphicon glyphicon-search"></span>&nbsp; Buscar</asp:LinkButton>
                        <%--<button type="button" class="btn" data-toggle="modal" data-target=".modalEditar"><i class="glyphicon glyphicon-pencil"></i></button>--%>
                </div>
            </div>
        </div>
        <!--Panel Principal Filtros FIN-->
        <!--Panel Principal Detalles INICIO-->
        <asp:Panel ID="pn_resultados" runat="server">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4 class="panel-title">Consultas</h4>
                </div>
                <div class="panel-body consultasStyle">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gv_menu" runat="server" AutoGenerateColumns="False" Width="930px" CssClass="grid sortable {disableSortCols: [1]} " AllowPaging="True" PageIndex="1" ShowFooter="True" EmptyDataText="* *  NO HAY DATOS QUE MOSTRAR * *" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-CssClass="text-center">
                                    <Columns>
                                        <asp:TemplateField HeaderText="OPCIONES">
                                            <ItemTemplate>
                                                <button id="btnEditar" type="button" class="btn" data-toggle="modal" data-target=".modalEditar"><i class="glyphicon glyphicon-pencil"></i></button>
                                                <button id="btnAprobar" type="button" class="btn" data-toggle="modal" data-target=".modalEditar"><i class="glyphicon glyphicon-ok"></i></button>
                                                <button id="btnNoAprobar" type="button" class="btn" data-toggle="modal" data-target=".modalEditar"><i class="glyphicon glyphicon-remove-sign"></i></button>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="celdaHead" Width="40px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CAPA_UDE_ESCU" HeaderText="ESCUELA" SortExpression="CAPA_UDE_ESCU">
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_DOM_PROCE" HeaderText="PROCESO" SortExpression="CAPA_DOM_PROCE" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_DOM_ESTRA" HeaderText="ESTRATEGIA" SortExpression="CAPA_DOM_ESTRA" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_ID_CARRERA" HeaderText="CARRERA" SortExpression="CAPA_ID_CARRERA" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_NRO_NECE" HeaderText="NECESIDAD" SortExpression="CAPA_NRO_NECE" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_ESTADO" HeaderText="ESTADO" SortExpression="CAPA_ESTADO" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_TOTAL_PERSONAS" HeaderText="TOTAL APROBADO" SortExpression="CAPA_TOTAL_PERSONAS" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_TOTAL_EVENTOS" HeaderText="TOTAL EVENTOS" SortExpression="CAPA_TOTAL_EVENTOS" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_DOM_MODAL" HeaderText="MODALIDAD" SortExpression="CAPA_DOM_MODAL" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_PPTO" HeaderText="PRESUPUESTO" SortExpression="CAPA_PPTO" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_EVEN_T1" HeaderText="EV 1er TRIM" SortExpression="CAPA_EVEN_T1" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_PERS_T1" HeaderText="PAR 1er TRIM" SortExpression="CAPA_PERS_T1" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_EVEN_T2" HeaderText="EV 2do TRIM" SortExpression="CAPA_EVEN_T2" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_PERS_T2" HeaderText="PAR 2do TRIM" SortExpression="CAPA_PERS_T2" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_EVEN_T3" HeaderText="EV 3er TRIM" SortExpression="CAPA_EVEN_T3" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_PERS_T3" HeaderText="PAR 3er TRIM" SortExpression="CAPA_PERS_T3" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_EVEN_T4" HeaderText="EV 4to TRIM" SortExpression="CAPA_EVEN_T4" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CAPA_PERS_T4" HeaderText="PAR 4to TRIM" SortExpression="CAPA_PERS_T4" >
                                            <HeaderStyle CssClass="celdaHead" />
                                        </asp:BoundField>
                                    </Columns>
                                    
                                </asp:GridView>
                        </div>
                    </div>
                </div>                
            </div>
        </asp:Panel>
        <!--Panel Principal Detalles FIN-->
    </div>
    <!--Panel Principal FIN-->
    <!--Body Content FIN-->

    <!-- MODAL INICIO -->
    <div class="modal fade modalEditar" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <!--Modal Header INICIO-->
                <div class="modal-header" style="background-color:#011B7A;color:white; font-weight:bold;">
                    <button class="btn btn-danger btnClose" type="button" data-dismiss="modal" aria-label="Close"><i class="glyphicon glyphicon-remove"></i></button>
                    <h4 class="modal-title" id="gridSystemModalLabel">Editar/Aprobar PAE Necesidad Capacitacion</h4>
                 </div>
                <!--Modal Header FIN-->
                <!--Modal Body INICIO -->
                <div class="modal-body">
                    <div class="panel panel-primary" style="margin-bottom:0; width:1080px">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-2">
                                    <p style="width:150px; font-weight: bold;">Escuela:</p>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label id="labelEscuela" Text="Escuela a presentar.." Width="180px" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <p style="width:150px; font-weight: bold;">Proceso:</p>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label id="labelProceso" Text="Proceso a presentar.." Width="180px"  runat="server"></asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <p style="width:70px;font-weight: bold;">Estrategia:</p>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label id="labelEstrategia" Text="Estrategia a presentar.." Width="180px" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    <p style="width:150px; font-weight: bold;">Nombre de Evento:</p>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label id="labelNombreEvento" Text="Nombre del Evento.." Width="180px" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <p style="width:150px; font-weight: bold;">Nivel Academico:</p>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label id="labelNivelAcademico" Text="Nivel Academico.." Width="180px" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <p style="width:70px; font-weight: bold;">Necesidad:</p>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label id="labelNecesidad" Text="Necesidad del evento.." Width="180px" runat="server"></asp:Label>
                                </div>
                            </div>
                            <br/>
                            <div class="container panel panel-body">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    
                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Modalidad:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:DropDownList ID="ddlModalidad" runat="server" AutoPostBack="false" CssClass="chosen-select" TabIndex="15" BackColor="#EEEEEE" Width="120px" Height="30px"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Presupuesto:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:DropDownList ID="ddlPresupuesto" runat="server" AutoPostBack="false" CssClass="chosen-select" TabIndex="15" BackColor="#EEEEEE" Width="120px" Height="30px"></asp:DropDownList>
                                    </div>

                                    <div class="col-md-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>

                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Eventos 1er Trimestre:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtEventosPrimerTrimestre" runat="server" Width="60px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Participantes 1er Trimestre:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtParticipantesPrimerTrimestre" runat="server" Width="60px"></asp:TextBox>
                                    </div>

                                    <div class="col-md-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>

                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Eventos 2do Trimestre:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtEventosSegundoTrimestre" runat="server" Width="60px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Participantes 2do Trimestre:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtParticipantesSegundoTrimestre" runat="server" Width="60px"></asp:TextBox>
                                    </div>

                                    <div class="col-md-1"></div>
                                </div>  
                                <div class="row">
                                    <div class="col-md-1"></div>

                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Eventos 3er Trimestre:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtEventosTercerTrimestre" runat="server" Width="60px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Participantes 3er Trimestre:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtParticipantesTercerTrimestre" runat="server" Width="60px"></asp:TextBox>
                                    </div>

                                    <div class="col-md-1"></div>
                                </div>  
                                <div class="row">
                                    <div class="col-md-1"></div>

                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Eventos 4to Trimestre:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtEventosCuartoTrimestre" runat="server" Width="60px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Participantes 4to Trimestre:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtParticipantesCuartoTrimestre" runat="server" Width="60px"></asp:TextBox>
                                    </div>

                                    <div class="col-md-1"></div>
                                </div> 
                                <div class="row">
                                    <div class="col-md-1"></div>

                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Total Eventos:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label id="labelTotalEventos" Text="N/A" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <p style="font-weight: bold;">Total Aprobado:</p>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label id="labelTotalAprobados" Text="N/A" runat="server"></asp:Label>
                                    </div>

                                    <div class="col-md-1"></div>
                                </div>                                 
                            </div>
                        </div>
                    </div>
                </div>
                <!--Modal Body FIN -->
                <!--Modal Footer INICIO -->
                <div class="modal-footer" style="margin-top:0; padding-top:0; text-align: center;">
                    <button id="btnGuardar" class="btn btn-success"><span class="glyphicon glyphicon-floppy-disk"></span>&nbsp; Guardar</button>
                    <button id="btnCancelar" class="btn btn-danger" data-dismiss="modal" aria-label="Close"><span class="glyphicon glyphicon-remove"></span>&nbsp; Cancelar</button>
                </div>
                <!--Modal Footer FIN -->
            </div>
        </div>
    </div>
    <!--Modal FIN-->
</asp:Content>
