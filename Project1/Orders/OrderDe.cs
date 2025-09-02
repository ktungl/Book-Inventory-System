using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Orders
{
    public class OrderDe
    {

        public int OrderID { get; set; }

        public int MemberID { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }

        public int BookID { get; set; }

        public int Qty { get; set; }

        public int Price { get; set; }

        public string Name { get; set; }

        public string BookTitle { get; set; }

    }
}
