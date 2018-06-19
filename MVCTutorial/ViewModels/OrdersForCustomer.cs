using MVCTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTutorial.ViewModels {

    public class OrdersForCustomer {
        public Customer Customer { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public OrdersForCustomer() {

        }
    }
}