﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _07PC_MVC.Models.DataModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Abouts> Abouts { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Faqs> Faqs { get; set; }
        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Sliders> Sliders { get; set; }
        public virtual DbSet<Testimonials> Testimonials { get; set; }
    }
}
