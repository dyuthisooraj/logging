using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HalcyonApparelsDomain.Entities;

namespace HalcyonApparelsApplication.DTO
{
    public class CustomerDTO
    {
        
        public string ContactId { get; set; } = null!;


        public string Fname { get; set; } = null!;

        
        public string Lname { get; set; } = null!;

       
        public string? Email { get; set; } = null!;

        public List<OrderDetails>? orderList { get; set; } 

    }
    
}
