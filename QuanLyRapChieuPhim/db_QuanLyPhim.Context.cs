﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyRapChieuPhim
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyDoanhThuPhimEntities1 : DbContext
    {
        public QuanLyDoanhThuPhimEntities1()
            : base("name=QuanLyDoanhThuPhimEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Phim> Phims { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}