using System;

namespace Souq.ViewModels
{
    public class OrderCreateViewModel
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}
