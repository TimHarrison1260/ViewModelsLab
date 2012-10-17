using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;               //  fluent mapping of classes
using ViewModelsLab.Domain;     //  Access the business models
using ViewModelsLab.Models;     //  Access the UI ViewModels


namespace ViewModelsLab.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            //  Instantiate the maps
            Mapper.Initialize(c => c.AddProfile(new UserProfile()));
        }

    }

    /// <summary>
    /// The profile used for this application.
    /// It contains the individual mappings for classes
    /// used within this application.
    /// </summary>
    public class UserProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            //  Map by convention: where possible, and add specific rules where the object names don't match.
            //  Include this map as the Order model and OrderDetailViewModel contains lists.
            Mapper.CreateMap<Domain.OrderLineItem, Models.OrderLineItem>();
            //  Include to map the Order to the OrderDetailviewModel.
            Mapper.CreateMap<Domain.Order, Models.OrderDetailViewModel>()
                //  because the Order has element id, and automapper will splits names using Pascal Notation.
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.id))
                //  because the total cost fo the order is not a property, but a method GetTotal.
                .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.GetTotal()))
                ;
            //  Assert the mappings are valid and can be used.
            Mapper.AssertConfigurationIsValid();
        }
    }
}