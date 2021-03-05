﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IDataResult<CarImage> Get(int id);
        IResult Add(CarImage carImage,IFormFile formFile);
        IResult Update(CarImage carImages,IFormFile formFile);
        IResult Delete(CarImage carImage);
        
    }
}
