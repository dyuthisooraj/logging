using HalcyonApparelsMVC.Models;

namespace HalcyonApparelsMVC.DTO
{
    public class CustomerDtoMVC
    
    {

        public string ContactId { get; set; } = null!;


        public string Fname { get; set; } = null!;


        public string Lname { get; set; } = null!;


        public string? Email { get; set; } = null!;

        public List<OrderDetailsMVC>? OrderDetailsMVC { get; set; }

    }

}
