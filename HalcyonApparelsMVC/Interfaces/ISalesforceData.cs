using HalcyonApparelsMVC.DTO;
using HalcyonApparelsMVC.Models;

namespace HalcyonApparelsMVC.Interfaces
{
    public interface ISalesforceData
    {
        public List<CustomerDetailsMVC> SalesforceCustomerDetails(string access_token);

        //public List<OrderDetailsMVC> SalesforceOrderDetails(string access_token,string id);

        public bool Post(List<CustomerDetailsMVC> custdet);
    }
}
