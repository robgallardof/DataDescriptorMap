using DataDescriptorRobertoGallardo.BussinessClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDescriptorRobertoGallardo.BusinessClasses
{
    internal class ShipmentOrder
    {
        public string CarrierShipmentld;
        public string ReceiverReference;
        public DateTime ShippingStartDate;
        public Address FromAddress;
        public Address ToAdress;
        public Package[] Packages;
    }
}
