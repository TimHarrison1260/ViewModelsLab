using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;       //  Access to Action Filters, ActionFilterAttribute.
using AutoMapper;           //  Access to Automapper.
using ViewModelsLab.Domain; //  Access to the domain models.
using ViewModelsLab.Models; //  Access to the model viewmodels. 

namespace ViewModelsLab.Filters
{
    public class OrderToOrderDetailMapAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Filter to apply the mapping between the Domain.Order business object
        /// and the Model.OrderDetailViewModel.  It uses Automapper to perform
        /// the mapping.  The configuration of Automapper is in the Mapping folder
        /// </summary>
        /// <param name="filterContext"></param>
        /// <remarks>
        /// We override the OnActionExecuted so that the mapping is done AFTER the
        /// action method has executed.  The action method returns the Domain,Order
        /// object and this filter passes the mapped Model.OrderDetailViewModel 
        /// to the view prior to it being rendered.
        /// </remarks>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //  Get the model from the controller.viewData
            var model = (Domain.Order)filterContext.Controller.ViewData.Model;
            //  Map the model to the viewModel
            var viewModel = Mapper.Map<Order, OrderDetailViewModel>(model);
            //  replace the viewData with the new mapped viewModel
            filterContext.Controller.ViewData.Model = viewModel;
        }
    }
}