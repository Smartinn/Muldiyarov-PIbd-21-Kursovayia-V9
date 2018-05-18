using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.CoverModels
{
    [DataContract]
    public class Room_ClearCoverModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int RoomId { get; set; }
        [DataMember]
        public int ClearId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
