﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCar(Car car)
        {
            if (car.DailyPrice>0 && car.CarName.Length>2)
            {
                _carDal.Add(car);
              
            }
        
           
        }

        public void DeleteCar(Car car)
        {
            _carDal.Delete(car);
        
        }

        public List<Car> GetAll()
        {
          return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(p=>p.Id==id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(x => x.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(x => x.ColorId == colorId);
        }

        public void UpdateCar(Car car)
        {
            _carDal.Update(car);
          
        }
    }
}
