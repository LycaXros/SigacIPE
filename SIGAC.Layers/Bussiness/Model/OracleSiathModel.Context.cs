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
    
    public partial class SiathEntities : DbContext
    {
        public SiathEntities()
            : base("name=SiathEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SIGAC_EMPLEADOS> SIGAC_EMPLEADOS { get; set; }
        public virtual DbSet<SIGAC_CARGOS> SIGAC_CARGOS { get; set; }
        public virtual DbSet<SIGAC_CARRERAS> SIGAC_CARRERAS { get; set; }
        public virtual DbSet<SIGAC_CATEGORIAS> SIGAC_CATEGORIAS { get; set; }
        public virtual DbSet<SIGAC_GRADOS> SIGAC_GRADOS { get; set; }
        public virtual DbSet<SIGAC_LUGARES_GEOGRAFICOS> SIGAC_LUGARES_GEOGRAFICOS { get; set; }
        public virtual DbSet<SIGAC_NIVELES_ACADEMICOS> SIGAC_NIVELES_ACADEMICOS { get; set; }
        public virtual DbSet<SIGAC_UNIDADES_DEPENDENCIA> SIGAC_UNIDADES_DEPENDENCIA { get; set; }
    }
}
