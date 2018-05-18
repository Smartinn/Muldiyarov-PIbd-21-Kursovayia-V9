using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.ViewModels
{
    [DataContract]
    public class ArmorViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CustomerF { get; set; }
        [DataMember]
        public string CustomerI { get; set; }
        [DataMember]
        public string ArmorStatus { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string DateImplement { get; set; }
        [DataMember]
        public decimal priceAll { get; set; }
        [DataMember]
        public virtual List<ArmorItemViewModel> ArmorItems { get; set; }
    }
}
