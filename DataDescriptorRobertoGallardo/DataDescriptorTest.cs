using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DataDescriptorRobertoGallardo.Helpers;
using DataDescriptorRobertoGallardo.BussinessClasses;
using DataDescriptorRobertoGallardo.Class;
using DataDescriptorRobertoGallardo.BusinessClasses;
using System.Net;

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
            DataDescriptor dataDescriptionObject = JsonConvert.DeserializeObject<DataDescriptor>(File.ReadAllText(@"DataDescriptors\ShipmentOrderDataDescriptor.json"));
            Assert.IsNotNull(dataDescriptionObject);
            Assert.IsNotNull(payloadObject);

            string result = DataDescriptorConverterHelper.ConvertJsonToDataDescriptor(payloadObject, dataDescriptionObject);

            Assert.IsNotNull(result);

            File.WriteAllText(@"ResultingJsons\resultShipmentOrder.json", result);

            ShipmentOrder shipmentOrder = JsonConvert.DeserializeObject<ShipmentOrder>(result) ?? throw new InvalidOperationException();
            Assert.IsNotNull(shipmentOrder);
        }

        [TestMethod]
        /// <summary>
        /// Test With Payload Address.
        /// </summary>
        public void TestAddress()
        {
            JObject payloadObject = JObject.Parse(File.ReadAllText(@"Payloads\AddressPayload.json"));
            DataDescriptor dataDescriptionObject = JsonConvert.DeserializeObject<DataDescriptor>(File.ReadAllText(@"DataDescriptors\AddressDataDescriptor.json"));
            Assert.IsNotNull(dataDescriptionObject);
            Assert.IsNotNull(payloadObject);

            string result = DataDescriptorConverterHelper.ConvertJsonToDataDescriptor(payloadObject, dataDescriptionObject);

            Assert.IsNotNull(result);

            File.WriteAllText(@"ResultingJsons\resultAddress.json", result);
            Address address = JsonConvert.DeserializeObject<Address>(result) ?? throw new InvalidOperationException();
            Assert.IsNotNull(address);
        }

        [TestMethod]
        /// <summary>
        /// Test With Payload Package.
        /// </summary>
        public void TestPackage()
        {
            JObject payloadObject = JObject.Parse(File.ReadAllText(@"Payloads\PackagePayload.json"));
            DataDescriptor dataDescriptionObject = JsonConvert.DeserializeObject<DataDescriptor>(File.ReadAllText(@"Datadescriptors\PackageDataDescriptor.json"));
            Assert.IsNotNull(dataDescriptionObject);
            Assert.IsNotNull(payloadObject);

            string result = DataDescriptorConverterHelper.ConvertJsonToDataDescriptor(payloadObject, dataDescriptionObject);

            Assert.IsNotNull(result);

            File.WriteAllText(@"ResultingJsons\resultPackage.json", result);
            Package package = JsonConvert.DeserializeObject<Package>(result) ?? throw new InvalidOperationException();
            Assert.IsNotNull(package);
        }

        /// <summary>
        /// Test With Payload Product.
        /// </summary>
        [TestMethod]
        public void TestProduct()
        {
            JObject payloadObject = JObject.Parse(File.ReadAllText(@"Payloads\ProductPayload.json"));
            DataDescriptor dataDescriptionObject = JsonConvert.DeserializeObject<DataDescriptor>(File.ReadAllText(@"Datadescriptors\ProductDataDescriptor.json"));
            Assert.IsNotNull(dataDescriptionObject);
            Assert.IsNotNull(payloadObject);

            string result = DataDescriptorConverterHelper.ConvertJsonToDataDescriptor(payloadObject, dataDescriptionObject);

            Assert.IsNotNull(result);

            File.WriteAllText(@"ResultingJsons\resultProduct.json", result);
            Product product = JsonConvert.DeserializeObject<Product>(result) ?? throw new InvalidOperationException();
            Assert.IsNotNull(product);
        }
    }
}