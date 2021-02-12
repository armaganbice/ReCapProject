using Business.Abstract;
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
            _iBrandDal.Delete(brand);
            return new SuccessResult("Brand added");
        }

        public IResult Delete(Brand brand)
        {
            _iBrandDal.Delete(brand);
            return new SuccessResult("Brand deleted");

        }
        public IResult Update(Brand brand)
        {
            _iBrandDal.Update(brand);
            return new SuccessResult("Brand Updated");
        }


        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_iBrandDal.GetAll(),"Brand Listed");
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_iBrandDal.GetById(id),"Brand by Id");
        }

    }
}
