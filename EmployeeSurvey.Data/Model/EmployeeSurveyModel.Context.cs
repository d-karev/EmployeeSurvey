﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeSurvey.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EmployeeSurveyModelContainer : DbContext
    {
        public EmployeeSurveyModelContainer()
            : base("name=EmployeeSurveyModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> EmployeeSet { get; set; }
        public virtual DbSet<Survey> SurveySet { get; set; }
        public virtual DbSet<ProgrammingLanguage> ProgrammingLanguageSet { get; set; }
        public virtual DbSet<KnownLanguage> KnownLanguageSet { get; set; }
    }
}
