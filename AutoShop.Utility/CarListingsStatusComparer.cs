using AutoShopWeb.ViewModels;

namespace AutoShop.Utility
{
    public class CarListingsStatusComparer : IComparer<CarListingVM>
    {
        public int Compare(CarListingVM? x, CarListingVM? y)
        {
            return x.Car.Status.CompareTo(y.Car.Status);
        }
    }
}
