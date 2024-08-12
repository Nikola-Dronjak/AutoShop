using AutoShopWeb.ViewModels;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
namespace AutoShop.Utility
{
    public class CarListingsStatusComparer : IComparer<CarListingVM>
    {
        public int Compare(CarListingVM? x, CarListingVM? y) => x.Car.Status.CompareTo(y.Car.Status);
    }
}
