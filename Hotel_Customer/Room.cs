using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Customer
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("RoomId")]
        public virtual List<ArmorItem> ArmorItems { get; set; }
    }
}
