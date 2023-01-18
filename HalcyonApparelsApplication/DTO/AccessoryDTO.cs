using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HalcyonApparelsApplication.DTO
{
    public class AccessoryDTO
    {
        [DisplayName("Accessory Id")]
        [Required(ErrorMessage = "Accessory Id is required")]
        [Column(TypeName = "INT")]
        public int AccessoryId { get; set; }

        [DisplayName("Accessory Name")]
        [Required(ErrorMessage = "Accessory Name is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string AccessoryName { get; set; } = null!;

        [DisplayName("Accessory Type")]
        [Required(ErrorMessage = "Accessory Type is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string AccessoryType { get; set; } = null!;

        [DisplayName("Accessory Brand")]
        [Required(ErrorMessage = "Accessory Brand is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string AccessoryBrand { get; set; } = null!;
        [DisplayName("Price")]
        //[Required(ErrorMessage = "Accessory Price is required")]
        [Column(TypeName = "DECIMAL")]
        [Range(1, 100000)]
        public decimal AccessoryPrice { get; set; }

        [DisplayName("Discount")]
        [Column(TypeName = "DECIMAL")]
        [Range(1, 100)]
        public decimal AccessoryDiscount { get; set; }

        public string ImageUrl { get; set; } = "imagelink";


        //[NotMapped]
        //[DisplayName("Upload File")]
        //public IFormFile ImageFile { get; set; }
    }
}

