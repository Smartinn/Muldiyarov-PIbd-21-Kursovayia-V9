using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.CoverModels
{
    [DataContract]
    public class RoomCoverModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string RoomName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        public List<Room_ClearCoverModel> Room_Clears { get; set; }
    }
}
