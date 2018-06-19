using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTutorial.Models {

	public class Customer {

		public int Id { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public decimal TotalSales { get; set; }

		public Customer() { }
	}
}