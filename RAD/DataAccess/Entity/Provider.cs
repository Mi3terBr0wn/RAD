using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD.DataAccess.Entity
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }

}
