using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RAD.DataAccess.Entity;

namespace RAD.DataAccess
{
    public class Context : DbContext
    {
        public Context() : base("Host=localhost;Database=postgres;Username=postgres;Password=password") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeProduct> IncomeProducts { get; set; }
        public DbSet<ProductConsumption> ProductConsumptions { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
