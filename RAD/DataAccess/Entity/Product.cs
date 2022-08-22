using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAD_project;

namespace RAD.DataAccess.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        private readonly ObservableListSource<IncomeProduct> _incomeProducts = new ObservableListSource<IncomeProduct>();
        public virtual ObservableListSource<IncomeProduct> IncomeProducts
        {
            get
            {
                return _incomeProducts;
            }
        }
        private readonly ObservableListSource<ProductConsumption> _productConsumptions = new ObservableListSource<ProductConsumption>();
        public virtual ObservableListSource<ProductConsumption> ProductConsumptions
        {
            get
            {
                return _productConsumptions;
            }
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
