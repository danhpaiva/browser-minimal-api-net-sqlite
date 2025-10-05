using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrowserApi.Models;

namespace BrowserApi.Data
{
    public class BrowserApiContext : DbContext
    {
        public BrowserApiContext (DbContextOptions<BrowserApiContext> options)
            : base(options)
        {
        }

        public DbSet<BrowserApi.Models.NavegadorWeb> NavegadorWeb { get; set; } = default!;
    }
}
