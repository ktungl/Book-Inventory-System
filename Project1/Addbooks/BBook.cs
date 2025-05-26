using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Addbooks
{
    public class BBook
    {
        public int BookID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Category {get; set;}

        public int Price { get; set; }

        public int Stock {  get; set; }
        public string Description { get; set; }

        public byte[] Image { get; set; }
    }
}

