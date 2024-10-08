﻿using AutoShop.Domain;
using AutoShop.Infrastructure;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
namespace DataAccessLayer.CarListingRepository
{
    public class CarListingRepository : ICarListingRepository
    {
        private readonly ApplicationDbContext _db;

        public CarListingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<CarListing> GetAll()
        {
            return _db.CarListings
                .Include(u => u.Model)
                    .ThenInclude(m => m.Brand)
                .Include(u => u.EngineType)
                .Include(u => u.TransmissionType)
                .Include(u => u.FuelType)
                .Include(u => u.BodyType)
                .Include(u => u.Images)
                .ToList();
        }

        public CarListing GetById(int id)
        {
            return _db.CarListings
                .Include(u => u.Model)
                    .ThenInclude(m => m.Brand)
                .Include(u => u.EngineType)
                .Include(u => u.TransmissionType)
                .Include(u => u.FuelType)
                .Include(u => u.BodyType)
                .Include(u => u.Images)
                .FirstOrDefault(u => u.CarId == id);
        }

        public bool VINExists(string vin, int excludeCarId)
        {
            return _db.CarListings.AsNoTracking().Any(u => u.VIN == vin && u.CarId != excludeCarId);
        }

        public void Add(CarListing car)
        {
            _db.Add(car);
        }

        public void Update(CarListing car)
        {
            _db.Update(car);
        }

        public void Delete(CarListing car)
        {
            _db.Remove(car);
        }
    }
}
