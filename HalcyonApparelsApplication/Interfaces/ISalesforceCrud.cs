using HalcyonApparelsApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcyonApparelsApplication.Interfaces
{
    public interface ISalesforceCrud
    {
        public bool SalesforcePost(List<CustomerDTO> customerDTO);
    }
}
