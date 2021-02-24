using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int customerId);
        IResult AddCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);


    }
}
