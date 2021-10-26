﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JPinaLeenkenGroupEntities : DbContext
    {
        public JPinaLeenkenGroupEntities()
            : base("name=JPinaLeenkenGroupEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CatEntidadFederativa> CatEntidadFederativas { get; set; }
        public virtual DbSet<Empleado> Empleadoes { get; set; }
    
        public virtual int EmpleadoDelete(Nullable<int> idEmpleado)
        {
            var idEmpleadoParameter = idEmpleado.HasValue ?
                new ObjectParameter("IdEmpleado", idEmpleado) :
                new ObjectParameter("IdEmpleado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoDelete", idEmpleadoParameter);
        }
    
        public virtual int EmpleadoUpdate(Nullable<int> idEmpleado, string nombre, string numeroNomina, string apellidoPaterno, string apellidoMaterno, Nullable<int> idEntidad)
        {
            var idEmpleadoParameter = idEmpleado.HasValue ?
                new ObjectParameter("IdEmpleado", idEmpleado) :
                new ObjectParameter("IdEmpleado", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var numeroNominaParameter = numeroNomina != null ?
                new ObjectParameter("NumeroNomina", numeroNomina) :
                new ObjectParameter("NumeroNomina", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var idEntidadParameter = idEntidad.HasValue ?
                new ObjectParameter("IdEntidad", idEntidad) :
                new ObjectParameter("IdEntidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoUpdate", idEmpleadoParameter, nombreParameter, numeroNominaParameter, apellidoPaternoParameter, apellidoMaternoParameter, idEntidadParameter);
        }
    
        public virtual ObjectResult<CatEntidadFederativaGetAll_Result> CatEntidadFederativaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CatEntidadFederativaGetAll_Result>("CatEntidadFederativaGetAll");
        }
    
        public virtual int EmpleadoAdd(string numeroNomina, string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<int> idEntidad)
        {
            var numeroNominaParameter = numeroNomina != null ?
                new ObjectParameter("NumeroNomina", numeroNomina) :
                new ObjectParameter("NumeroNomina", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var idEntidadParameter = idEntidad.HasValue ?
                new ObjectParameter("IdEntidad", idEntidad) :
                new ObjectParameter("IdEntidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoAdd", numeroNominaParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, idEntidadParameter);
        }
    
        public virtual ObjectResult<EmpleadoGetAll_Result> EmpleadoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoGetAll_Result>("EmpleadoGetAll");
        }
    
        public virtual ObjectResult<EmpleadoGetById_Result> EmpleadoGetById(Nullable<int> idEmpleado)
        {
            var idEmpleadoParameter = idEmpleado.HasValue ?
                new ObjectParameter("IdEmpleado", idEmpleado) :
                new ObjectParameter("IdEmpleado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoGetById_Result>("EmpleadoGetById", idEmpleadoParameter);
        }
    }
}
