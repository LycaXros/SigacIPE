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
    using System.Linq;

    public partial class ASIGNATURAS
    {
        public decimal ID { get; set; }
        public decimal CURSOS { get; set; }
        public string NOMBRE { get; set; }
        public byte[] DESCRIPCION { get; set; }
        public byte[] CONTENIDO { get; set; }
        public byte[] OBSERVACION { get; set; }
        public Nullable<decimal> HORAS { get; set; }
        public Nullable<System.DateTime> FECHA_INICIO { get; set; }
        public Nullable<System.DateTime> FECHA_FIN { get; set; }
        public Nullable<decimal> CREDITOS { get; set; }
        public string CAMPO1 { get; set; }
        public string CAMPO2 { get; set; }
        public string CAMPO3 { get; set; }
        public Nullable<decimal> ESTATUS { get; set; }
        public string HORARIO1 { get; set; }
        public string HORARIO2 { get; set; }
        public string HORA1 { get; set; }
        public string HORA2 { get; set; }
        public Nullable<decimal> TIPO { get; set; }


        public string NOMBRE_CURSO
        {
            get
            {
                using (SiathEntities enti = new SiathEntities())
                {
                    return enti.SIGAC_CURSOS
                        .Where(x => x.ID_CURSO == this.CURSOS)
                        .Select(X => X.DESCRIPCION)
                        .First();
                }
            }
        }
        public string NOMBRE_TIPO
        {
            get
            {
                using (SigacEntities enti = new SigacEntities())
                {
                    return enti.TIPOS_ASIGNATURA
                        .Where(x => x.ID == this.TIPO)
                        .Select(X => X.DESCRIPCION)
                        .First();
                }
            }
        }

        public string FECHAS
        {
            get
            {
                return string.Format("Del {0} al {1}.",
                    FECHA_INICIO.Value.ToShortDateString(),
                    FECHA_FIN.Value.ToShortDateString());
            }
        }

        public string HORARIOS
        {
            get
            {
                return string.Format("{0} de {1} y {2} de {3}",
                    HORARIO1, HORA1, HORARIO2, HORA2);
            }
        }
    }
}
