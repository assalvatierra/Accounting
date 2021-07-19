using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OAS.Models;

namespace xSamples.Data
{
    public class xSamplesContext : DbContext
    {
        public xSamplesContext (DbContextOptions<xSamplesContext> options)
            : base(options)
        {
        }

        public DbSet<OAS.Models.fsAccount> fsAccount { get; set; }
    }
}
