﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cerebro14.DAL.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CiudadEntities : DbContext
    {
        public CiudadEntities()
            : base("name=CiudadEntities")
        {
        }
        public CiudadEntities(string connStringName)
          : base("name=" + connStringName)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TABacciones> TABacciones { get; set; }
        public virtual DbSet<TABCiudades> TABCiudades { get; set; }
        public virtual DbSet<TABedificios> TABedificios { get; set; }
        public virtual DbSet<TABeventos> TABeventos { get; set; }
        public virtual DbSet<TABsensor> TABsensor { get; set; }
        public virtual DbSet<TABsensorEvento> TABsensorEvento { get; set; }
        public virtual DbSet<TABusuarios> TABusuarios { get; set; }
    }
}
