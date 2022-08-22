using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAD_project;

namespace RAD.DataAccess.Entity
{
    public class Consumption
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        private readonly ObservableListSource<ProductConsumption> _productConsumptions = new ObservableListSource<ProductConsumption>();
        public virtual ObservableListSource<ProductConsumption> ProductConsumptions
        {
            get
            {
                return _productConsumptions;
            }
        }
    }
}
