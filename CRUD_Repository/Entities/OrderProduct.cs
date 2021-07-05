using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_DAL.Entities
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string Title { get; set; }
    }
}
