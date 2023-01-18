using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcyonApparelsDomain.Entities
{
    public class LoginCredentials
    {
        public int Id { get; set; } = 0;

        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 3)]
        public string? UserName { get; set; }

        [StringLength(10, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
