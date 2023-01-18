using HalcyonApparelsApplication.DTO;
using HalcyonApparelsApplication.Interfaces;
using HalcyonApparelsDomain.Entities;
using HalcyonApparelsInfrastructure.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcyonApparelsInfrastructure.Implementation
{
    public class Mapping : IMapping
    {
        private readonly AppDBContext _dbobj;

        public Mapping(AppDBContext dbobj)
        {
            _dbobj = dbobj;
        }


        public List<CustomerDetails> GetCustomer()
        {

            //return _dbobj.CustomerDetails.Select(x => x.Email).ToList();
            return _dbobj.CustomerDetails.ToList();

        }



        public List<AccessoryDetails> GetAccessoryType()
        {
            return _dbobj.AccessoryDetails.ToList();
        }

        public List<ProductType> GetProductType()
        {
            return _dbobj.Products.ToList();
        }

        public bool Addaccsry(string atype, string ptype)
        {
            var prodtype = _dbobj.Products.ToList().Where(c => c.ProdType.Equals(ptype)).ToList().FirstOrDefault();
            if (prodtype == null)
            {
                prodtype.Id = 0;
                prodtype.ProdType = ptype;
            }
            var acclist = prodtype.accessoryTypes;
            if (acclist != null)
            {
                acclist.Add(new AccessoryType { AccsryType = atype });
            }
            else
            {
                acclist = new List<AccessoryType>();
                acclist.Add(new AccessoryType { AccsryType = atype });

            }
            prodtype.accessoryTypes = acclist;
            if (prodtype.Id == 0)
            {
                _dbobj.Products.Add(prodtype);
                _dbobj.SaveChanges();
            }
            else
            {
                _dbobj.Products.Update(prodtype);
                _dbobj.SaveChanges();
            }
            //var bag = _dbobj.OrderDetails.ToList().Where(x => x.Product_Type__c.Equals(ptype));
            return true;
        }

    }
}
