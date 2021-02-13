using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _iBrandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _iBrandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _iBrandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _iBrandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);

        }
        public IResult Update(Brand brand)
        {
            _iBrandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }


        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_iBrandDal.GetAll(),Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_iBrandDal.GetById(id),Messages.BrandById);
        }

    }
}
