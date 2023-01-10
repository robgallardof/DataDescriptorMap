using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DataDescriptorRobertoGallardo.Helpers;
using DataDescriptorRobertoGallardo.BussinessClasses;
using DataDescriptorRobertoGallardo.Class;
using DataDescriptorRobertoGallardo.BusinessClasses;

namespace DataDescriptorRobertoGallardo
{
    [TestClass]
    public class DataDescriptorTest
    {
        [TestMethod]
        /// <summary>
        /// Test With Payload TestShipmentOrder.
        /// </summary>
        public void TestShipmentOrder()
        {
            JObject payloadObject = JObject.Parse(File.ReadAllText(@"Payloads\ShipmentOrderPayload.json"));
            DataDescriptor dataDescriptionObject = JsonConvert.DeserializeObject<DataDescriptor>(File.ReadAllText(@"DataDescriptors\ShipmentOrderDataDescriptor.json"))
            ?? throw new InvalidOperationException();

            string result = DataDescriptorConverterHelper.ConvertJsonToDataDescriptor(typeof(ShipmentOrder), payloadObject, dataDescriptionObject);

            if (result == null) return;

            File.WriteAllText("resultShipmentOrder.json", result);
            ShipmentOrder shipmentOrder = JsonConvert.DeserializeObject<ShipmentOrder>(result) ?? throw new InvalidOperationException();
            _ = shipmentOrder;
        }

        [TestMethod]
        /// <summary>
        /// Test With Payload Address.
        /// </summary>
        public void TestAddress()
        {
            JObject payloadObject = JObject.Parse(File.ReadAllText(@"Payloads\AddressPayload.json"));
            DataDescriptor dataDescriptionObject = JsonConvert.DeserializeObject<DataDescriptor>(File.ReadAllText(@"DataDescriptors\AddressDataDescriptor.json"))
            ?? throw new InvalidOperationException();

            string result = DataDescriptorConverterHelper.ConvertJsonToDataDescriptor(typeof(Address), payloadObject, dataDescriptionObject);

            if (result == null) return;
            
            File.WriteAllText("resultAddress.json", result);
            Address address = JsonConvert.DeserializeObject<Address>(result) ?? throw new InvalidOperationException();
            _ = address;
        }

        [TestMethod]
        /// <summary>
        /// Test With Payload Package.
        /// </summary>
        public void TestPackage()
        {
            JObject payloadObject = JObject.Parse(File.ReadAllText(@"Payloads\PackagePayload.json"));
            DataDescriptor dataDescriptionObject = JsonConvert.DeserializeObject<DataDescriptor>(File.ReadAllText(@"Datadescriptors\PackageDataDescriptor.json"))
            ?? throw new InvalidOperationException();

            string result = DataDescriptorConverterHelper.ConvertJsonToDataDescriptor(typeof(Package), payloadObject, dataDescriptionObject);

            if (result == null) return;
            File.WriteAllText("resultPackage.json", result);
            Package package = JsonConvert.DeserializeObject<Package>(result) ?? throw new InvalidOperationException();
            _ = package;
        }

        /// <summary>
        /// Test With Payload Product.
        /// </summary>
        [TestMethod]
        public void TestProduct()
        {
            JObject payloadObject = JObject.Parse(File.ReadAllText(@"Payloads\ProductPayload.json"));
            DataDescriptor dataDescriptionObject = JsonConvert.DeserializeObject<DataDescriptor>(File.ReadAllText(@"Datadescriptors\ProductDataDescriptor.json"))
            ?? throw new InvalidOperationException();

            string result = DataDescriptorConverterHelper.ConvertJsonToDataDescriptor(typeof(Product), payloadObject, dataDescriptionObject);

            if (result == null) return;
            File.WriteAllText("resultProduct.json", result);
            Product product = JsonConvert.DeserializeObject<Product>(result) ?? throw new InvalidOperationException();
            _ = product;
        }
    }
}