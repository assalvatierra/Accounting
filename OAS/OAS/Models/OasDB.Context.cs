﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OAS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OasDBContainer : DbContext
    {
        public OasDBContainer()
            : base("name=OasDBContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<fsAccount> fsAccounts { get; set; }
        public virtual DbSet<fsAccntCategory> fsAccntCategories { get; set; }
        public virtual DbSet<fsTrxHdr> fsTrxHdrs { get; set; }
        public virtual DbSet<fsTrxDetail> fsTrxDetails { get; set; }
        public virtual DbSet<fsSubAccnt> fsSubAccnts { get; set; }
        public virtual DbSet<fsAccntSetting> fsAccntSettings { get; set; }
        public virtual DbSet<fsConfigCode> fsConfigCodes { get; set; }
        public virtual DbSet<fsTrxStatus> fsTrxStatus { get; set; }
    }
}