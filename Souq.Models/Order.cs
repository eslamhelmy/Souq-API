using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souq.Models
{
    public class Order
    {
        public int ID { get; set; }
        
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }


        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public OrderStatus Status { get; set; }
    }
}
