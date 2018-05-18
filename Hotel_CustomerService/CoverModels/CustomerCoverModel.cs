using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Hotel_CustomerService.CoverModels
{
    [DataContract]
    public class CustomerCoverModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CustomerF { get; set; }
        [DataMember]
        public string CustomerI { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public string CustomerLogin { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
