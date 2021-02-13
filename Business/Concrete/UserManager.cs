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
    public class UserManager : IUserService
    {
        IUserDal _iUserDal;
        public UserManager(IUserDal userDal)
        {
            _iUserDal = userDal;
        }
        public IResult Add(User user)
        {
            _iUserDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _iUserDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        public IResult Update(User user)
        {
            _iUserDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_iUserDal.GetById(id), Messages.UserById);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_iUserDal.GetAll(), Messages.CarListed);
        }
    }
}
