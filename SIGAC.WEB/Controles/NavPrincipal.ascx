<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavPrincipal.ascx.cs" Inherits="SIGAC.WEB.Controles.NavPrincipal" %>

<nav id='cssmenu'>
    <div id="head-mobile">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <div class="button"></div>
    <ul>
        <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
        <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>" class='active'><i class="fas fa-home"></i>INICIO</a></li>
        <li><a href="#"><i class="fas fa-sticky-note"></i>ADMINISTRAR PAE</a>
            <ul style="z-index: 9999;">
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>PAE/Administrar">ADMINISTRAR PAE</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>PAE/Coberturas">ADMINISTRAR COBERTURAS</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>PAE/Necesidades">ADMINISTRAR NECESIDADES</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">ADMINISTRAR NECESIDADES CAPACITACION</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">ADMINISTRAR COBERTURAS FORMACION</a></li>
            </ul>
        </li>
        <li><a href="#"><i class="fas fa-list-alt"></i>PROGRAMAS</a>
            <ul style="z-index: 9999;">
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>Programas/Administrar">ADMINISTRAR PROGRAMAS</a></li>
            </ul>
        </li>
        <li><a href="#"><i class="fas fa-calendar-alt"></i>DESARROLLO DE EVENTOS</a>
            <ul style="z-index: 9999;">
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">ADMINISTRAR PRESUPUESTOS</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">ADMINISTRAR PERSONAL EXTERNO</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">BUSCAR EVENTOS ESCUELA</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">EDITAR INFORMACION DESARROLLO DE EVENTOS ESCUELA</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">CONVOCATORIA EVENTO ESCUELA</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">INSERTAR INFORMACION EVENTO ESCUELA</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">PARTICIPANTE EVENTO ESCUELA</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">DOCENTE EVENTO ESCUELA</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">INASISTENTE EVENTO ESCUELA</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">ENVIAR EVALUACION EVENTO ESCUELA</a></li>
            </ul>
        </li>
        <li><a href="#"><i class="fas fa-check-circle"></i>EVALUACIONES</a>
            <ul style="z-index: 9999;">
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">BUSCAR EVALUACION</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">AGREGAR EVALUACION</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">EDITAR EVALUACION</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">ELIMINAR EVALUACION</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">ADMINISTRAR PREGUNTAS EVALUACION</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">DESARROLLO EVALUACION</a></li>
            </ul>
        </li>
        <li><a href="#"><i class="fas fa-cog"></i>SISTEMA</a>
            <ul style="z-index: 9999;">
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>Sistema/Recintos">RECINTOS</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>Sistema/Escuelas">ESCUELA</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>Sistema/Aulas">AULAS</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>Sistema/Cursos">CURSOS</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>Sistema/Asignaturas">ASIGNATURAS</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>Sistema/Usuarios">USUARIOS</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">GRUPOS</a></li>
                <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>">PERMISOS</a></li>
                <li><a href="#"><i class="fas fa-flag"></i>Tablas</a>
                    <ul>
                        <li><a href="<%= SIGAC.Layers.GlobalVariables.ServerUrl%>Sistema_Tablas/Dominios">DOMINIOS</a></li>
                    </ul>
                </li>
            </ul>
        </li>
    </ul>
</nav>
