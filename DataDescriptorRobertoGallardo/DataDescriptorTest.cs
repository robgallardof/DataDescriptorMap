using DataDescriptorRobertoGallardo.BusinessClasses;
using DataDescriptorRobertoGallardo.BussinessClasses;
using DataDescriptorRobertoGallardo.Class;
using DataDescriptorRobertoGallardo.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataDescriptorRobertoGallardo
{
    [TestClass]
    public class DataDescriptorTest
    {
        #region Enums

        private enum DataDescriptors
        {
            FedexShipment,
            FedexAddress,
            FedexItem,
            FedexProduct
        }

        #endregion Enums

        #region Methods

        /// <summary>
        /// Gets DataDescriptors.
        /// </summary>
        /// <returns></returns>
        private static List<DataDescriptor> GetDataDescriptors()
        {
            Dictionary<DataDescriptors, string> dataDescriptorPath = new Dictionary<DataDescriptors, string>();

            dataDescriptorPath.Add(DataDescriptors.FedexShipment, @"DataDescriptors\ShipmentOrderDataDescriptor.json");
            dataDescriptorPath.Add(DataDescriptors.FedexAddress, @"DataDescriptors\AddressDataDescriptor.json");
            dataDescriptorPath.Add(DataDescriptors.FedexItem, @"Datadescriptors\PackageDataDescriptor.json");
            dataDescriptorPath.Add(DataDescriptors.FedexProduct, @"Datadescriptors\ProductDataDescriptor.json");

            List<DataDescriptor> dataDescriptors = new List<DataDescriptor>();

            foreach (var dataDescriptor in dataDescriptorPath)
            {
                dataDescriptors.Add(JsonConvert.DeserializeObject<DataDescriptor>(File.ReadAllText(dataDescriptorPath[dataDescriptor.Key])));
            }
            return dataDescriptors;
        }

        #endregion Methods

        [TestMethod]
        public void TestShipmentOrder()
        {
            JObject payloadObject = JObject.Parse(File.ReadAllText(@"Payloads\ShipmentOrderPayload.json"));

            Assert.IsNotNull(payloadObject);

            List<DataDescriptor> dataDescriptors = GetDataDescriptors();

            string result = PayloadConverterHelper.PayloadConvert(payloadObject, dataDescriptors[(int)DataDescriptors.FedexShipment], dataDescriptors.ToArray()).ToString();

            Assert.IsNotNull(result);

            File.WriteAllText(@"ResultingJsons\resultShipmentOrder.json", result);

            ShipmentOrder shipmentOrder = JsonConvert.DeserializeObject<ShipmentOrder>(result) ?? throw new InvalidOperationException();
            Assert.IsNotNull(shipmentOrder);
        }

        [TestMethod]
        public void TestAddress()
        {
            JObject payloadObject = JObject.Parse(File.ReadAllText(@"Payloads\AddressPayload.json"));
            Assert.IsNotNull(payloadObject);

            List<DataDescriptor> dataDescriptors = GetDataDescriptors();

            string result = PayloadConverterHelper.PayloadConvert(payloadObject, dataDescriptors[((int)DataDescriptors.FedexAddress)]).ToString();

            Assert.IsNotNull(result);

            File.WriteAllText(@"ResultingJsons\resultAddress.json", result);
            Address address = JsonConvert.DeserializeObject<Address>(result) ?? throw new InvalidOperationException();
            Assert.IsNotNull(address);
        }

        [TestMethod]
        public void TestPackage()
        {
            JObject payloadObject = JObject.Parse(File.ReadAllText(@"Payloads\PackagePayload.json"));

            Assert.IsNotNull(payloadObject);

            List<DataDescriptor> dataDescriptors = GetDataDescriptors();

            string result = PayloadConverterHelper.PayloadConvert(payloadObject, dataDescriptors[((int)DataDescriptors.FedexItem)]).ToString();

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

            Assert.IsNotNull(payloadObject);

            List<DataDescriptor> dataDescriptors = GetDataDescriptors();

            string result = PayloadConverterHelper.PayloadConvert(payloadObject, dataDescriptors[((int)DataDescriptors.FedexProduct)]).ToString();

            Assert.IsNotNull(result);

            File.WriteAllText(@"ResultingJsons\resultProduct.json", result);
            Product product = JsonConvert.DeserializeObject<Product>(result) ?? throw new InvalidOperationException();
            Assert.IsNotNull(product);
        }
    }
}