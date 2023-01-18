using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HalcyonApparelsMVC.Models
{
    public class AccessoryDetailsMVC
    {

       
        [DisplayName("Id")]
        //[Required(ErrorMessage = "Accessory Id is required")]
        [Column(TypeName = "INT")]
        public int AccessoryId { get; set; } = 0;

        [DisplayName("Title")]
        //[Required(ErrorMessage = "Accessory Name is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string AccessoryName { get; set; } = null!;

        [DisplayName("Type")]
        //[Required(ErrorMessage = "Accessory Type is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string AccessoryType { get; set; } = null!;

        [DisplayName("Brand")]
        //[Required(ErrorMessage = "Accessory Brand is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string AccessoryBrand { get; set; } = null!;

        [DisplayName("Price")]
        [Required(ErrorMessage = "Accessory Price is required")]
        [Column(TypeName = "DECIMAL")]
        [Range(1, 100000, ErrorMessage = "Please enter valid Price")]
        public decimal AccessoryPrice { get; set; }

        [DisplayName("Discount")]
        [Column(TypeName = "DECIMAL")]
        [Range(1, 100, ErrorMessage = "Please enter valid Discount")]
        public decimal AccessoryDiscount { get; set; }

        public string? ImageUrl { get; set; }


        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
