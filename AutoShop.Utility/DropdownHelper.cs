using AutoShop.Services.Interfaces;
using AutoShop.ViewModel;
using AutoShopWeb.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoShop.Utility
{
    public static class DropdownHelper
    {
        public static void PopulateDropdown(CarListingVM carListing, IEngineTypeService engineTypeService, ITransmissionTypeService transmissionTypeService, IFuelTypeService fuelTypeService, IBodyTypeService bodyTypeService, IModelService modelService, IBrandService brandService)
        {
            carListing.EngineTypeOptions = engineTypeService.EngineTypes.Select(et => new SelectListItem
            {
                Text = et.Type,
                Value = et.EngineTypeId.ToString()
            });

            carListing.TransmissionTypeOptions = transmissionTypeService.TransmissionTypes.Select(tt => new SelectListItem
            {
                Text = tt.Type,
                Value = tt.TransmissionTypeId.ToString()
            });

            carListing.FuelTypeOptions = fuelTypeService.FuelTypes.Select(ft => new SelectListItem
            {
                Text = ft.Type,
                Value = ft.FuelTypeId.ToString()
            });

            carListing.BodyTypeOptions = bodyTypeService.BodyTypes.Select(bt => new SelectListItem
            {
                Text = bt.Type,
                Value = bt.BodyTypeId.ToString()
            });

            carListing.ModelOptions = modelService.Models.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.ModelId.ToString()
            });

            carListing.BrandOptions = brandService.Brands.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.BrandId.ToString()
            });
        }

        public static void PopulateDropdownFilter(CarListingFilterVM searchCriteria, IEngineTypeService engineTypeService, ITransmissionTypeService transmissionTypeService, IFuelTypeService fuelTypeService, IBodyTypeService bodyTypeService, IModelService modelService, IBrandService brandService)
        {
            searchCriteria.EngineTypeOptions = engineTypeService.EngineTypes.Select(et => new SelectListItem
            {
                Text = et.Type,
                Value = et.EngineTypeId.ToString()
            });

            searchCriteria.TransmissionTypeOptions = transmissionTypeService.TransmissionTypes.Select(tt => new SelectListItem
            {
                Text = tt.Type,
                Value = tt.TransmissionTypeId.ToString()
            });

            searchCriteria.FuelTypeOptions = fuelTypeService.FuelTypes.Select(ft => new SelectListItem
            {
                Text = ft.Type,
                Value = ft.FuelTypeId.ToString()
            });

            searchCriteria.BodyTypeOptions = bodyTypeService.BodyTypes.Select(bt => new SelectListItem
            {
                Text = bt.Type,
                Value = bt.BodyTypeId.ToString()
            });

            searchCriteria.ModelOptions = modelService.Models.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.ModelId.ToString()
            });

            searchCriteria.BrandOptions = brandService.Brands.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.BrandId.ToString()
            });
        }
    }
}
