using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Customer
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string CustomerF { get; set; }
        [Required]
        public string CustomerI { get; set; }
        [Required]
        public string CustomerLogin { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Mail { get; set; }

        [ForeignKey("CustomerId")]
        public virtual List<Armor> Armors { get; set; }
    }
}
