using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTutorial.Models {

    public class Order {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Total { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public Order() {

        }

    }
}