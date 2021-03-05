using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage carImage, IFormFile formFile)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckImageIsExist(carId));
            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> {new CarImage{
                    CarId=carId,ImagePath=@"\wwwroot\uploads\default",Date=DateTime.MinValue } });
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(x => x.CarId == carId));
        }

        public IResult Update(CarImage carImages, IFormFile formFile)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImages.CarId));
            if (result != null)
            {
                return result;
            }
            //var currentImagePath = _carImageDal.Get(x => x.Id == carImages.Id).ImagePath;
            carImages.ImagePath = FileHelper.Update(carImages.ImagePath, formFile);
            carImages.Date = DateTime.Now;
            _carImageDal.Update(carImages);
            return new SuccessResult();


        }

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(x => x.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }

    

        private IResult CheckImageIsExist(int carId)
        {
            var isExist = _carImageDal.GetAll(x => x.CarId == carId).Count;
            if (isExist == 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
