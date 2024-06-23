using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21ProjeYazarakADO_NET
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } //nvarchar(50) 
        public decimal UnitPrice { get; set; } // money
        public int StockAmount { get; set; }
    }
}
