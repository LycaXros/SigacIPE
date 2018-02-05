//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class SIGAC_CARGOS
    {
        public bool FUERZA { get; set; }
        public decimal CARGO { get; set; }
        public string DESCRIPCION { get; set; }
        public string ABREVIATURA { get; set; }
        public string VIGENTE { get; set; }
        public string TIPO_CARGO { get; set; }
        public string CREADO_POR { get; set; }
        public System.DateTime FECHA_CREACION { get; set; }
        public string MAQUINA_CREACION { get; set; }
        public string ACTUALIZADO_POR { get; set; }
        public Nullable<System.DateTime> FECHA_ACTUALIZA { get; set; }
        public string MAQUINA_ACTUALIZA { get; set; }
        public Nullable<decimal> NIVEL_RIESGO { get; set; }
        public Nullable<decimal> CARGO_PADRE { get; set; }
        public Nullable<decimal> FUERZA_PADRE { get; set; }
        public string CONDICION_TOP { get; set; }
        public Nullable<decimal> TIEMPO_MAXIMO { get; set; }
        public Nullable<decimal> TIEMPO_MINIMO { get; set; }
        public Nullable<decimal> ORDEN { get; set; }
        public string NIVEL_MISIONAL { get; set; }
        public string NIVEL_JERARQUICO { get; set; }
        public string OBJETIVO_GENERAL { get; set; }
        public string CARGO_CRITICO { get; set; }
        public Nullable<decimal> ID_DESPLIEGUE { get; set; }
        public Nullable<decimal> ID_NIVEL_RESPONSABILIDAD { get; set; }
        public Nullable<decimal> ID_MODALIDAD { get; set; }
        public Nullable<decimal> ID_HAB_COMPORTAMENTAL { get; set; }
        public string COD_MIGRACION { get; set; }
        public string REG_VALIDADO { get; set; }
        public string REG_ACT_POR { get; set; }
        public Nullable<System.DateTime> REG_FECHA_ACT { get; set; }
        public string REG_MAQUINA_ACT { get; set; }
    }
}
