﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nhsneuro
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class nhsneuroEntities : DbContext
    {
        public nhsneuroEntities()
            : base("name=nhsneuroEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<ConditionSymptom> ConditionSymptoms { get; set; }
        public virtual DbSet<Symptom> Symptoms { get; set; }
    }
}
