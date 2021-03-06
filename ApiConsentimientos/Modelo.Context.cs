﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiConsentimientos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ApiConsentimientosV2Entities : DbContext
    {
        public ApiConsentimientosV2Entities()
            : base("name=ApiConsentimientosV2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Procedimiento> Procedimiento { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<ConsentimientoInformado> ConsentimientoInformado { get; set; }
    
        public virtual ObjectResult<spAgenda_Result> spAgenda(Nullable<int> numeroIDMedico, Nullable<System.DateTime> fecha)
        {
            var numeroIDMedicoParameter = numeroIDMedico.HasValue ?
                new ObjectParameter("NumeroIDMedico", numeroIDMedico) :
                new ObjectParameter("NumeroIDMedico", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spAgenda_Result>("spAgenda", numeroIDMedicoParameter, fechaParameter);
        }
    }
}
