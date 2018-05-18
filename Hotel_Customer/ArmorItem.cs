using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hotel_Customer
{
    public class ArmorItem
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public decimal Price { get; set; }
        public virtual Armor Armor { get; set; }
        public virtual Room Room { get; set; }
    }
}
