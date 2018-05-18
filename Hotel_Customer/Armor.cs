using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hotel_Customer
{
    public class Armor
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public ArmorStatus ArmorStatus { get; set; }
        public decimal priceAll {get;set;}
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<ArmorItem> ArmorItems { get; set; }
        
    }
}
