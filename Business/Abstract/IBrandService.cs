using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {

       IDataResult<Brand> GetById(int id);
        IDataResult<List<Brand>> GetAll();
        IResult AddBrand(Brand brand);
        IResult DeleteBrand(Brand brand);
        IResult UpdateBrand(Brand brand);


    }
}
