using DataDescriptorRobertoGallardo.BussinessClasses;

namespace DataDescriptorRobertoGallardo.BusinessClasses
{
    internal class ShipmentOrder
    {
        public string CarrierShipmentId;
        public string ReceiverReference;
        public DateTime ShippingStartDate;
        public Address FromAddress;
        public Address ToAddress;
        public Package[] Packages;
    }
}