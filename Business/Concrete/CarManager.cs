using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Concrete;
using FluentValidation;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Caching;
using Business.BusinessAspect.Autofac.Security;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;
        public CarManager(ICarDal carDal)
        {
            _iCarDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _iCarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult Update(Car car)
        {
            _iCarDal.Update(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(),Messages.CarListed); 
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_iCarDal.GetById(id),Messages.CarById);
        }

        public IDataResult<List<CarDetailDto>> GetCarById(int id)
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarById(id), Messages.CarById);
            ICarImageDal carImageDal = new EfCarImageDal();
            //ICarImageService carimagemanager = new CarImageManager(carImageDal);
            //List<CarImage> carimages = carimagemanager.GetImagesByCarId(id);
            //result.Data.CarImages = carimages;
            return result;
        }


        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarsByBrandId(brandId),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarsByColorId(colorId),Messages.CarListed);
        }

       
    }
}
