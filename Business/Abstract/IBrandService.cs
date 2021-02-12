﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IDataResult<Brand> GetById(int brand);
        IDataResult<List<Brand>> GetAll();
    }
}
