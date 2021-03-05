using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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

    public IDataResult<List<CarImage>> GetAll()
    {
        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
    }

    public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
    {
        var result = _carImageDal.GetAll(c => c.CarId == carId);
        IfCarImageOfCarNotExistsAddDefault(result, carId);
        return new SuccessDataResult<List<CarImage>>(result,Messages.CarImageListed);
    }

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
                    $@"{Environment.CurrentDirectory}\Public\Images\default-car.png",
                Date = DateTime.Now
            };
            result.Add(defaultCarImage);
        }
    }

    private string CreateNewPath(IFormFile file)
    {
        var fileInfo = new FileInfo(file.FileName);
        var newPath =
            $@"{Environment.CurrentDirectory}\Public\Images\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
        return newPath;
    }

    private IResult CheckIfCarImageCountOfCarCorrect(int carId)
    {
        var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
        if (result >= 5) return new ErrorResult(Messages.CarImageCountOfCarError);
        return new SuccessResult();
    }

    }


}
