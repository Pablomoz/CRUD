using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Redes.Models
{
    public class BodegaContext : DbContext
    {
        public BodegaContext()
        {
        }

        public BodegaContext(DbContextOptions<BodegaContext> options) : base(options)
        {
        }

        public  DbSet<Redes> Redes { get; set; }
    }
    
    
}
