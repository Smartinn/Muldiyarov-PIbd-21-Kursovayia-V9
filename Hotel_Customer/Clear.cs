using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Customer
{
    public class Clear
    {
        public int Id { get; set; }

        [Required]
        public string ClearName { get; set; }

        [ForeignKey("ClearId")]
        public virtual List<Room_Clear> Room_Clears { get; set; }

        [ForeignKey("ClearId")]
        public virtual List<StorageClear> StorageClears { get; set; }
    }
}
