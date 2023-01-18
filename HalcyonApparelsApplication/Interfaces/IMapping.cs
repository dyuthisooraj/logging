using HalcyonApparelsApplication.DTO;
using HalcyonApparelsDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcyonApparelsApplication.Interfaces
{
    public interface IMapping
    {

        //public List<string> GetCustomer();

        List<CustomerDetails> GetCustomer();
        List<AccessoryDetails> GetAccessoryType();

        List<ProductType> GetProductType();


        public bool Addaccsry(string atype, string ptype);

    }
}
