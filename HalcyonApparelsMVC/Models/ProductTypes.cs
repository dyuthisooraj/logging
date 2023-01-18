using System.ComponentModel.DataAnnotations;

namespace HalcyonApparelsMVC.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        public string ProdType { get; set; }

        public ICollection<AccessoryType> accessoryTypes { get; set; }


    }

    public class AccessoryType
    {
        [Key]
        public int Id { get; set; }

        public string AccsryType { get; set; }

    }
}
