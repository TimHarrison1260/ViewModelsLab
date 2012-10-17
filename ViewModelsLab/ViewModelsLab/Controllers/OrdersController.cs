using System.Web.Mvc;
using ViewModelsLab.Domain;
using ViewModelsLab.Models;
using AutoMapper;
using ViewModelsLab.Filters;

namespace ViewModelsLab.Controllers
{
    public class OrdersController : Controller
    {
        private IOrderRepository orderRepository;
        private IProductRepository productRepository;

        public OrdersController(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        //
        // GET: /Orders/

        public ActionResult Index()
        {
            var orders = orderRepository.GetAll();

            return View(orders);
        }

        [OrderToOrderDetailMap]
        public ActionResult OrderDetail(int? id)
        {
            var order = id != null ? orderRepository.Get(id.Value) : null;

            if (order == null)
            {
                return View("Index");
            }

            // TODO: complete and return View with view model
            //  Comment whichever method is not to be used.

            //  1.  These lines convert here and pass the viewmodel to the view
            //OrderDetailViewModel orderDetailView = new OrderDetailViewModel();
            //orderDetailView = Mapper.Map<Order, OrderDetailViewModel>(order);
            //return View(orderDetailView);
            //  2.  This line pases the model to the view, the mapping is handled
            //      in the custom mapping attribute [OrderToOrderDetailMapAttribute]
            return View(order);
        }

        [HttpGet]
        public ActionResult AddItem(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }

            // DONE: create view model for form and return View with view model
            AddItemViewModel model = new AddItemViewModel();
            //  Pass the Order Id through
            model.OrderId = (int)id;
            //  Load the products into the Product SelectList
            model.ProductList = new SelectList(productRepository.GetAll(), "Name", "Name");
            //  Render the view
            return View(model);
        }

        [HttpPost]
        public ActionResult AddItem(AddItemViewModel addItem)    // TODO: insert view model parameter for binding
        {
            if (ModelState.IsValid)
            {
                // TODO: Get product and order from repositories using view model properties, and add product to order, then redirect to order detail
                //  1. map view model to model
                Domain.Order order = orderRepository.Get(addItem.OrderId);
                Domain.Product product = productRepository.Get(addItem.ProductName);
//                var orderLineItem = new Domain.OrderLineItem(product, addItem.Quantity);
                //  2   Add item to the model
                order.AddOrderLineItem(product, addItem.Quantity);
                orderRepository.Save(order);
                //  3   If OK, redirect to OrderDetail
                return RedirectToAction("OrderDetail", "Orders", new { id=addItem.OrderId });
            }
            else
            {
                // TODO: update view model with products data and return View with view model
                addItem.ProductList = new SelectList(productRepository.GetAll(), "Name", "Name");
            }
            return View(addItem);
        }

    }
}
