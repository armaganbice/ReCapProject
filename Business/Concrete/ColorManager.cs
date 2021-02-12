using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _iColorDal;
        public ColorManager(IColorDal colorDal)
        {
            _iColorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _iColorDal.Add(color);
            return new SuccessResult("Color added");
        }

        public IResult Delete(Color color)
        {
            _iColorDal.Delete(color);
            return new SuccessResult("Color deleted");
        }

        public IResult Update(Color color)
        {
            _iColorDal.Update(color);
            return new SuccessResult("Color updated");
        }
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_iColorDal.GetAll(), "Color Listed");
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_iColorDal.GetById(id),"Color get");
        }

    }
}
