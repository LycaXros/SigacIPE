﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIGAC.Layers.Bussiness.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DEPARTAMENTO> DEPARTAMENTO { get; set; }
        public virtual DbSet<EMPLEADO> EMPLEADO { get; set; }
        public virtual DbSet<SIEDU_AUDITORIA> SIEDU_AUDITORIA { get; set; }
        public virtual DbSet<SIEDU_CIERRE_PAE> SIEDU_CIERRE_PAE { get; set; }
        public virtual DbSet<SIEDU_COBERTURA> SIEDU_COBERTURA { get; set; }
        public virtual DbSet<SIEDU_COMPETENCIA> SIEDU_COMPETENCIA { get; set; }
        public virtual DbSet<SIEDU_COMPETENCIA_EVENTO> SIEDU_COMPETENCIA_EVENTO { get; set; }
        public virtual DbSet<SIEDU_CONSOLIDA_PAE> SIEDU_CONSOLIDA_PAE { get; set; }
        public virtual DbSet<SIEDU_CONVENIO> SIEDU_CONVENIO { get; set; }
        public virtual DbSet<SIEDU_CONVOCATORIA_EVENTO> SIEDU_CONVOCATORIA_EVENTO { get; set; }
        public virtual DbSet<SIEDU_DOCENTE_EVENTO> SIEDU_DOCENTE_EVENTO { get; set; }
        public virtual DbSet<SIEDU_EMPLEADO_EXTERNO> SIEDU_EMPLEADO_EXTERNO { get; set; }
        public virtual DbSet<SIEDU_ENTIDAD> SIEDU_ENTIDAD { get; set; }
        public virtual DbSet<SIEDU_EVAL_DESARROLLO> SIEDU_EVAL_DESARROLLO { get; set; }
        public virtual DbSet<SIEDU_EVAL_GRADO> SIEDU_EVAL_GRADO { get; set; }
        public virtual DbSet<SIEDU_EVAL_PARTICIPANTE> SIEDU_EVAL_PARTICIPANTE { get; set; }
        public virtual DbSet<SIEDU_EVALUACION> SIEDU_EVALUACION { get; set; }
        public virtual DbSet<SIEDU_EVENTO> SIEDU_EVENTO { get; set; }
        public virtual DbSet<SIEDU_EVENTO_CATEGORIA> SIEDU_EVENTO_CATEGORIA { get; set; }
        public virtual DbSet<SIEDU_EVENTO_ESCUELA> SIEDU_EVENTO_ESCUELA { get; set; }
        public virtual DbSet<SIEDU_FORMA_ESCUELA_COHORTE> SIEDU_FORMA_ESCUELA_COHORTE { get; set; }
        public virtual DbSet<SIEDU_INASISTE_EVENTO> SIEDU_INASISTE_EVENTO { get; set; }
        public virtual DbSet<SIEDU_NECESIDAD> SIEDU_NECESIDAD { get; set; }
        public virtual DbSet<SIEDU_NECESIDAD_E> SIEDU_NECESIDAD_E { get; set; }
        public virtual DbSet<SIEDU_PAE_CAPACITACION> SIEDU_PAE_CAPACITACION { get; set; }
        public virtual DbSet<SIEDU_PAE_FORMACION> SIEDU_PAE_FORMACION { get; set; }
        public virtual DbSet<SIEDU_PARTICIPANTE_EVENTO> SIEDU_PARTICIPANTE_EVENTO { get; set; }
        public virtual DbSet<SIEDU_PERSONA> SIEDU_PERSONA { get; set; }
        public virtual DbSet<SIEDU_PREGUNTA> SIEDU_PREGUNTA { get; set; }
        public virtual DbSet<SIEDU_PRESUPUESTO> SIEDU_PRESUPUESTO { get; set; }
        public virtual DbSet<SIEDU_TEMA> SIEDU_TEMA { get; set; }
        public virtual DbSet<ACTIVOS> ACTIVOS { get; set; }
        public virtual DbSet<ASIGNATURAS> ASIGNATURAS { get; set; }
        public virtual DbSet<AULAS> AULAS { get; set; }
        public virtual DbSet<AULAS_ACTIVOS> AULAS_ACTIVOS { get; set; }
        public virtual DbSet<MOVIMIENTO_PERSONAL> MOVIMIENTO_PERSONAL { get; set; }
        public virtual DbSet<RECINTOS> RECINTOS { get; set; }
        public virtual DbSet<SIEDU_LOG> SIEDU_LOG { get; set; }
        public virtual DbSet<SUB_TIPOS> SUB_TIPOS { get; set; }
        public virtual DbSet<TIPOS> TIPOS { get; set; }
        public virtual DbSet<TIPOS_ASIGNATURA> TIPOS_ASIGNATURA { get; set; }
        public virtual DbSet<SIEDU_DOMINIO> SIEDU_DOMINIO { get; set; }
<<<<<<< HEAD
=======
        public virtual DbSet<SIEDU_ARCHIVO> SIEDU_ARCHIVO { get; set; }
        public virtual DbSet<SIEDU_PAE> SIEDU_PAE { get; set; }
>>>>>>> 9ec6df310172c8c815d9c106161a2ecd4fa4883a
        public virtual DbSet<SIEDU_TIPO_DOMINIO> SIEDU_TIPO_DOMINIO { get; set; }
    }
}
