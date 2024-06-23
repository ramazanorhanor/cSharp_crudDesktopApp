using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22EntityFrameworkDemo
{
    public class ETrade_BtkContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

    }
}
