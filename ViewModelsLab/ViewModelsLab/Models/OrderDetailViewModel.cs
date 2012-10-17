using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;        // for the property attributes
using System.ComponentModel;                        //  DisplayNameAttribute is in here

namespace ViewModelsLab.Models
{
    /// <summary>
    /// View Model for the Order Details 
    /// </summary>
    public class OrderDetailViewModel
    {
        [DisplayName("Order Number")]
        public int OrderId { get; set; }

        [DisplayNameAttribute("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Order items")]
        public IList<OrderLineItem> OrderLineItems { get; set; }

        [DisplayName("Total Cost")]
        public decimal TotalCost { get; set; }
    }

    public class OrderLineItem
    {
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Price")]
        public decimal ProductPrice { get; set; }

    }
}