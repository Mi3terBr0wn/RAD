using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD.DataAccess.Entity
{
    public class IncomeProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int IncomeId { get; set; }
        public Income Income { get; set; }
        public int Quantity { get; set; }
    }
}
