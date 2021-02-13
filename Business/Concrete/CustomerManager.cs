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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _iCustomerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _iCustomerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _iCustomerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _iCustomerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }
        public IResult Update(Customer customer)
        {
            _iCustomerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_iCustomerDal.GetById(id), Messages.CustomerById);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_iCustomerDal.GetAll(), Messages.CustomerListed);
        }
    }
}
