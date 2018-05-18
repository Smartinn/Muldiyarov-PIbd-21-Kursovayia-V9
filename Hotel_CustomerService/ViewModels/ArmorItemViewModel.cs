﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.ViewModels
{
    [DataContract]
    public class ArmorItemViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int RoomId { get; set; }
        [DataMember]
        public string RoomName { get; set; }
        [DataMember]
        public decimal Price { get; set; }

    }
}
