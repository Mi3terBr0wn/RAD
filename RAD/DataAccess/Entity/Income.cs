using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAD_project;

namespace RAD.DataAccess.Entity
{
    public class Income
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public bool Paid { get; set; }
        private readonly ObservableListSource<IncomeProduct> _incomeProducts = new ObservableListSource<IncomeProduct>();
        public virtual ObservableListSource<IncomeProduct> IncomeProduct
        {
            get
            {
                return _incomeProducts;
            }
        }
        private readonly ObservableListSource<Payment> _payments = new ObservableListSource<Payment>();
        public virtual ObservableListSource<Payment> Payment
        {
            get
            {
                return _payments;
            }
        }

    }
}
