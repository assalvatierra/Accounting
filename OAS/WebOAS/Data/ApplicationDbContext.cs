using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OAS.Models;

namespace WebOAS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<fsAccount> fsAccount { get; set; }
        public DbSet<fsAccntCategory> fsAccntCategory { get; set; }
        public DbSet<fsTrxHdr> fsTrxHdrs { get; set; }
        public DbSet<fsTrxDetail> fsTrxDetails { get; set; }
        public DbSet<fsSubAccnt> fsSubAccnts { get; set; }
        public DbSet<fsAccntSetting> fsAccntSettings { get; set; }
        public DbSet<fsConfigCode> fsConfigCodes { get; set; }
        public DbSet<fsTrxStatus> fsTrxStatus { get; set; }
        public DbSet<fsRptCat> fsRptCats { get; set; }
        public DbSet<fsRptCatAccnt> fsRptCatAccnts { get; set; }
        public DbSet<fsEntity> fsEntity { get; set; }
        public DbSet<fsUser> fsUsers { get; set; }
        public DbSet<fsEntityUsers> fsEntityUsers { get; set; }


    }
}
