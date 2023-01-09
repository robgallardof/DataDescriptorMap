using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DataDescriptorRobertoGallardo.Helpers;
using DataDescriptorRobertoGallardo.BussinessClasses;

namespace DataDescriptorRobertoGallardo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            JObject o1 = JObject.Parse(File.ReadAllText("Payload.json"));

            try
            {
                File.WriteAllText("result.json", DataDescriptorConverterHelper.ConvertJsonToDataDescriptor(typeof(Address), o1));
            }
            catch (Exception)
            {
                throw;
            }
            //// read JSON directly from a file
            //using (StreamReader file = File.OpenText("Payload.json"))
            //using (JsonTextReader reader = new JsonTextReader(file))
            //{
            //    JObject o2 = (JObject)JToken.ReadFrom(reader);
            //}
        }

        [TestMethod]
        public void TestMethod2()
        {
        }

        [TestMethod]
        public void TestMethod3()
        {
        }
    }
}