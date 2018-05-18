﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Customer
{
    public class Storage
    {
        public int Id { get; set; }
        [Required]
        public string StorageName { get; set; }

        [ForeignKey("StorageId")]
        public virtual List<StorageClear> StorageClears { get; set; }
    }
}
