using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.CoverModels
{
    [DataContract]
    public class StorageClearCoverModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StorageId { get; set; }
        [DataMember]
        public int ClearId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
