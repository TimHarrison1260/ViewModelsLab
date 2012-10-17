using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ViewModelsLab.Models
{
    /// <summary>
    /// This <c>AddItemViewModel</c> is provided to support the
    /// AddItem view for adding items to Orders.
    /// </summary>
    public class AddItemViewModel
    {
        [DisplayName("Order")]
        [Required(ErrorMessage="(Attrib) Order Id is required")]
        public int OrderId { get; set; }

        [DisplayName("How many")]
        [Required(ErrorMessage="(Attrib) You must specify a quantity to order")]
        [Range(1, 100, ErrorMessage = "(Attrib) Please enter a number between 1 and 100")]
        public int Quantity { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage="(Attrib) Hey! Which product?")]
        public string ProductName { get; set; }

        [DisplayName("Product")]
        public SelectList ProductList { get; set; }
    }

    //public class Product
    //{
    //    [DisplayName("Name")]
    //    public string Name { get; set; }

    //    [DisplayName("Price")]
    //    public decimal Price { get; set; }
    //}
}