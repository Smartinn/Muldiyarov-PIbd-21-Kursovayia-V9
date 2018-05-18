using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.ViewModels
{
    [DataContract]
    public class StorageLoadViewModel
    {
        [DataMember]
        public string StorageName { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public List<StorageClearLoadViewModel> Clears { get; set; }
    }

    [DataContract]
    public class StorageClearLoadViewModel
    {
        [DataMember]
        public string ClearName { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
