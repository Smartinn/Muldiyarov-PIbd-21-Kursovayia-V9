using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.ViewModels
{
    [DataContract]
    public class CustomerViewModel
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
