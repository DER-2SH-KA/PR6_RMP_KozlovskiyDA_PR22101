﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR5_KozlovskiyDA_PR22101.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class demonEntities : DbContext
    {
        public demonEntities()
            : base("name=demonEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Drinks> Drinks { get; set; }
        public DbSet<DrinksAndOrders> DrinksAndOrders { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<RawMaterials> RawMaterials { get; set; }
        public DbSet<RawMaterialsAndDrinks> RawMaterialsAndDrinks { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}