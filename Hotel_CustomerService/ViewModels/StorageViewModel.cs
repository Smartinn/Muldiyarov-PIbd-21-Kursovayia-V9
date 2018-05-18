using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.ViewModels
{
    [DataContract]
    public class StorageViewModel
    {
        [DataMember]
        public List<StorageClearViewModel> StorageClears;
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StorageName { get; set; }
    }
}
