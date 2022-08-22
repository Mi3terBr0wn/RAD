using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD.DataAccess.Entity
{
    public class ProductConsumption
    {
        public int Id { get; set; }
        public int ConsumptionId { get; set; }
        public Consumption Consumption { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
