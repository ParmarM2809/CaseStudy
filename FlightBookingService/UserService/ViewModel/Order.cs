using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.ViewModel
{
    public class Order
    {

        public Guid OrderId {get;set;}
        public string details {get;set;}
        public decimal Price {get;set;}
        public int UserId { get; set; }


    }
}
