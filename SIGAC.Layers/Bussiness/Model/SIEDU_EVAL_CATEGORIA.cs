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
    
    public partial class SIEDU_EVAL_CATEGORIA
    {
        public int EVCR_EVAL { get; set; }
        public bool EVCR_FUERZA { get; set; }
        public decimal EVCR_ID_CATEGORIA { get; set; }
        public string EVCR_USU_CREA { get; set; }
        public System.DateTime EVCR_FECHA_CREA { get; set; }
        public string EVCR_MAQUINA_CREA { get; set; }
        public string EVCR_IP_CREA { get; set; }
        public string EVCR_USU_MOD { get; set; }
        public Nullable<System.DateTime> EVCR_FECHA_MOD { get; set; }
        public string EVCR_MAQUINA_MOD { get; set; }
        public string EVCR_IP_MOD { get; set; }
    
        public virtual SIEDU_EVALUACION SIEDU_EVALUACION { get; set; }
    }
}
