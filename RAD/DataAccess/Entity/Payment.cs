using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD.DataAccess.Entity
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int IncomeId { get; set; }
        public Income Income { get; set; }

    }
}
