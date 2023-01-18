using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcyonApparelsDomain.Entities
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
