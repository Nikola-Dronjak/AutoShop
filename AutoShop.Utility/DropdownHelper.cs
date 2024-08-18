using AutoShop.Queries.BodyTypeQueries;
using AutoShop.Queries.BrandQueries;
using AutoShop.Queries.EngineTypeQueries;
using AutoShop.Queries.FuelTypeQueries;
using AutoShop.Queries.ModelQueries;
using AutoShop.Queries.TransmissionTypeQueries;
using AutoShop.ViewModel;
using AutoShopWeb.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoShop.Utility
{
    public static class DropdownHelper
    {
        public static async Task PopulateDropdown(CarListingVM carListing, IMediator mediator)
        {
            var engineTypes = await mediator.Send(new GetAllEngineTypesQuery());
            var transmissionTypes = await mediator.Send(new GetAllTransmissionTypesQuery());
            var fuelTypes = await mediator.Send(new GetAllFuelTypesQuery());
            var bodyTypes = await mediator.Send(new GetAllBodyTypesQuery());
            var models = await mediator.Send(new GetAllModelsQuery());
            var brands = await mediator.Send(new GetAllBrandsQuery());

            carListing.EngineTypeOptions = engineTypes.Select(et => new SelectListItem
            {
                Text = et.Type,
                Value = et.EngineTypeId.ToString()
            });

            carListing.TransmissionTypeOptions = transmissionTypes.Select(tt => new SelectListItem
            {
                Text = tt.Type,
                Value = tt.TransmissionTypeId.ToString()
            });

            carListing.FuelTypeOptions = fuelTypes.Select(ft => new SelectListItem
            {
                Text = ft.Type,
                Value = ft.FuelTypeId.ToString()
            });

            carListing.BodyTypeOptions = bodyTypes.Select(bt => new SelectListItem
            {
                Text = bt.Type,
                Value = bt.BodyTypeId.ToString()
            });

            carListing.ModelOptions = models.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.ModelId.ToString()
            });

            carListing.BrandOptions = brands.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.BrandId.ToString()
            });
        }

        public static async Task PopulateDropdownFilter(CarListingFilterVM searchCriteria, IMediator mediator)
        {
            var engineTypes = await mediator.Send(new GetAllEngineTypesQuery());
            var transmissionTypes = await mediator.Send(new GetAllTransmissionTypesQuery());
            var fuelTypes = await mediator.Send(new GetAllFuelTypesQuery());
            var bodyTypes = await mediator.Send(new GetAllBodyTypesQuery());
            var models = await mediator.Send(new GetAllModelsQuery());
            var brands = await mediator.Send(new GetAllBrandsQuery());

            searchCriteria.EngineTypeOptions = engineTypes.Select(et => new SelectListItem
            {
                Text = et.Type,
                Value = et.EngineTypeId.ToString()
            });

            searchCriteria.TransmissionTypeOptions = transmissionTypes.Select(tt => new SelectListItem
            {
                Text = tt.Type,
                Value = tt.TransmissionTypeId.ToString()
            });

            searchCriteria.FuelTypeOptions = fuelTypes.Select(ft => new SelectListItem
            {
                Text = ft.Type,
                Value = ft.FuelTypeId.ToString()
            });

            searchCriteria.BodyTypeOptions = bodyTypes.Select(bt => new SelectListItem
            {
                Text = bt.Type,
                Value = bt.BodyTypeId.ToString()
            });

            searchCriteria.ModelOptions = models.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.ModelId.ToString()
            });

            searchCriteria.BrandOptions = brands.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.BrandId.ToString()
            });
        }
    }
}
