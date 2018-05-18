using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.ViewModels
{
    [DataContract]
    public class RoomViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string RoomName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        public List<Room_ClearViewModel> Room_Clears { get; set; }
    }
}
