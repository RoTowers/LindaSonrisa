﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LindaSonrisa.Dalc
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LindaSonrisaEntities : DbContext
    {
        public LindaSonrisaEntities()
            : base("name=LindaSonrisaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BOLETA> BOLETA { get; set; }
        public DbSet<CARGO> CARGO { get; set; }
        public DbSet<CLIENTE> CLIENTE { get; set; }
        public DbSet<COMUNA> COMUNA { get; set; }
        public DbSet<DETALLE> DETALLE { get; set; }
        public DbSet<DOCUMENTO> DOCUMENTO { get; set; }
        public DbSet<EMPLEADO> EMPLEADO { get; set; }
        public DbSet<FAMILIA_DE_PRODUCTOS> FAMILIA_DE_PRODUCTOS { get; set; }
        public DbSet<HORARIO> HORARIO { get; set; }
        public DbSet<ODONTOLOGO> ODONTOLOGO { get; set; }
        public DbSet<ORDEN_DE_PEDIDO> ORDEN_DE_PEDIDO { get; set; }
        public DbSet<ORDENES_PRODUCTO> ORDENES_PRODUCTO { get; set; }
        public DbSet<PRODUCTO> PRODUCTO { get; set; }
        public DbSet<PROVEEDOR> PROVEEDOR { get; set; }
        public DbSet<PROVINCIA> PROVINCIA { get; set; }
        public DbSet<RESERVA> RESERVA { get; set; }
        public DbSet<SERVICIO> SERVICIO { get; set; }
        public DbSet<SERVICIO_PRODUCTO> SERVICIO_PRODUCTO { get; set; }
        public DbSet<SITUACION_ECONOMICA> SITUACION_ECONOMICA { get; set; }
        public DbSet<TIPO_DE_PRODUCTO> TIPO_DE_PRODUCTO { get; set; }
        public DbSet<USUARIOS> USUARIOS { get; set; }
    }
}
