using Business.Abstract;
using Business.BusinessAspect.Autofac.Security;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Business.Concrete
{ 
   public class CarImageManager : ICarImageService
   {
      private readonly ICarImageDal _carImageDal;

    public CarImageManager(ICarImageDal carImageDal)
    {
        _carImageDal = carImageDal;
    }


    public IDataResult<CarImage> GetById(int id)
    {
        return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id),Messages.CarImageListed);
    }

    public IDataResult<CarImage> GetByCarId(int id)
    {
        return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == id),Messages.CarImageListed);
    }

    public IDataResult<List<CarImage>> GetListByCarId(int id)
    {
            var Result = new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll().Where(c => c.CarId == id).ToList());
            return Result;
    }


    public IDataResult<List<CarImage>> GetAll()
    {
        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
    }

    //public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
    //{
    //    var result = new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
    //    IfCarImageOfCarNotExistsAddDefault(result, carId);
    //    return result;
    //}

      
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 0)
            {
                var defaultImage = DefaultImage(carId);
                return new SuccessDataResult<List<CarImage>>(defaultImage.Data);
            }

            return new SuccessDataResult<List<CarImage>>(result);

        }

        private IDataResult<List<CarImage>> DefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>
            {
                new CarImage
                {
                    CarId = carId, 
                    ImagePath = ($@"{Environment.CurrentDirectory}\Images\default-car.png")
                }
            };
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

        //   [SecuredOperation("carImage.add")]
        //  [ValidationAspect(typeof(CarImageValidator))]
        //   [CacheRemoveAspect("ICarService.Get")
        public IResult Add(CarImage carImage, IFormFile file)
    {
        var result = BusinessRules.Run(
            CheckIfCarImageCountOfCarCorrect(carImage.CarId));
        if (result != null) return result;
        carImage.ImagePath = new FileHelperOnDisk().Add(file, CreateNewPath(file));
        carImage.Date = DateTime.Now;
        _carImageDal.Add(carImage);
        return new SuccessResult(Messages.CarImageAdded);
    }

    public IResult Update(CarImage carImage, IFormFile file)
    {
        var carImageToUpdate = _carImageDal.Get(c => c.Id == carImage.Id);
        carImage.CarId = carImageToUpdate.CarId;
        carImage.ImagePath = new FileHelperOnDisk().Update(carImageToUpdate.ImagePath, file, CreateNewPath(file));
        carImage.Date = DateTime.Now;
        _carImageDal.Update(carImage);
        return new SuccessResult(Messages.CarImageUpdated);
    }

    public IResult Delete(CarImage carImage)
    {
        new FileHelperOnDisk().Delete(carImage.ImagePath);
        _carImageDal.Delete(carImage);
        return new SuccessResult(Messages.CarImageDeleted);
    }

    private void IfCarImageOfCarNotExistsAddDefault(List<CarImage> result, int carId)
    {
        if (!result.Any())
        {
            var defaultCarImage = new CarImage
            {
                CarId = carId,
                ImagePath =
                    $@"{Environment.CurrentDirectory}\Images\default-car.png",
                Date = DateTime.Now
            };
            result.Add(defaultCarImage);
        }
    }

    private string CreateNewPath(IFormFile file)
    {
        var fileInfo = new FileInfo(file.FileName);
        var newPath =
            $@"{Environment.CurrentDirectory}\Images\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
        return newPath;
    }

    private IResult CheckIfCarImageCountOfCarCorrect(int carId)
    {
        var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
        if (result >= 5) return new ErrorResult(Messages.CarImageCountOfCarError);
        return new SuccessResult();
    }

        private List<CarImage> CheckIfCarImageNull(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage {
                    CarId=id,
                    ImagePath = @"\Images\default-car.png",
                    Date=DateTime.Now
                } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }
    }
}
