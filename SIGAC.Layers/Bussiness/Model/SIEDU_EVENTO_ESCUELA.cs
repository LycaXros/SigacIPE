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
    
    public partial class SIEDU_EVENTO_ESCUELA
    {
        public int EVEE_EVEE { get; set; }
        public Nullable<int> EVEE_EVEN { get; set; }
        public int EVEE_CAPA { get; set; }
        public Nullable<byte> EVEE_NRO_EVENTO { get; set; }
        public Nullable<bool> EVEE_TRIMES { get; set; }
        public Nullable<int> EVEE_NRO_PARTICIPANTES { get; set; }
        public Nullable<System.DateTime> EVEE_FECHAINI { get; set; }
        public Nullable<System.DateTime> EVEE_FECHAFIN { get; set; }
        public string EVEE_CERRADO { get; set; }
        public Nullable<decimal> EVEE_ENTI { get; set; }
        public Nullable<short> EVEE_DOM_FINANCIA { get; set; }
        public Nullable<int> EVEE_PPTO { get; set; }
        public Nullable<int> EVEE_COSTO_CAPA { get; set; }
        public Nullable<byte> EVEE_NRO_DIAS { get; set; }
        public Nullable<int> EVEE_NRO_CONVOCADOS { get; set; }
        public Nullable<int> EVE_NRO_NOAPROBADOS { get; set; }
        public Nullable<int> EVE_NRO_APROBADOS { get; set; }
        public Nullable<short> EVEE_CONV { get; set; }
        public Nullable<bool> EVEE_UDE_FUERZA { get; set; }
        public Nullable<decimal> EVEE_UDE_UDEPE { get; set; }
        public Nullable<int> EVEE_LUGGEO_CAPACITA { get; set; }
        public Nullable<int> EVEE_NRO_DESERTADOS { get; set; }
        public Nullable<int> EVEE_EVAL { get; set; }
        public string EVEE_USU_CREA { get; set; }
        public System.DateTime EVEE_FECHA_CREA { get; set; }
        public string EVEE_MAQUINA_CREA { get; set; }
        public string EVEE_IP_CREA { get; set; }
        public string EVEE_USU_MOD { get; set; }
        public Nullable<System.DateTime> EVEE_FECHA_MOD { get; set; }
        public string EVEE_MAQUINA_MOD { get; set; }
        public string EVEE_IP_MOD { get; set; }
    
        public virtual SIEDU_EVALUACION SIEDU_EVALUACION { get; set; }
    }
}
