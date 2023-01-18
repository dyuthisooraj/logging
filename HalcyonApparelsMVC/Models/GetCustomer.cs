using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace HalcyonApparelsMVC.Models
{
    public class GetCustomer
    {
        [DisplayName("CustomerId")]
        [Required(ErrorMessage = "CustomerId is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string ContactId { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string Fname { get; set; } = null!;

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string Lname { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string? Email { get; set; }

        public List<OrderDetailsMVC> orderList { get; set; }
    }
}

