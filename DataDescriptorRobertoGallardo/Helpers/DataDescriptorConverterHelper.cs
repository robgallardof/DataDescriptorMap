using DataDescriptorRobertoGallardo.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataDescriptorRobertoGallardo.Helpers
{
    internal static class DataDescriptorConverterHelper
    {
        /// <summary>
        /// ConvertJsonToDataDescriptor.
        /// </summary>
        /// <param name="classObject"></param>
        /// <param name="payload"></param>
        /// <param name="dataDescriptorObject"></param>
        /// <returns></returns>
        internal static string ConvertJsonToDataDescriptor(Type classObject, JObject payload, DataDescriptor dataDescriptorObject)
        {
            JToken result = JsonGenerator(payload, dataDescriptorObject);
            var test = result.ToString();
            return test;
        }

        /// <summary>
        /// JSON String Generator.
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <param name="dataDescriptor"></param>
        /// <returns></returns>
        private static JToken JsonGenerator(JToken jsonObject, DataDescriptor dataDescriptor)
        {
            StringBuilder jsonString = new();
   
            jsonString.Append("{");
            if (!dataDescriptor.Multiple)
            {
                foreach (var item in dataDescriptor.Fields)
                {
                    jsonString.Append($"\"{item.Alias}\":\"{jsonObject[item.Name]}\",");
                }
                jsonString = jsonString.Remove(jsonString.Length - 1, 1);
            }
            else
            {
                dataDescriptor.Multiple = false;
                foreach (var item in jsonObject.Children())
                {
                    JsonGenerator(item, dataDescriptor);
                }
            }
            jsonString.Append("}");

            jsonString = jsonString.Replace("\"[", "[").Replace("]\"", "]").Replace(":\"{", ":{").Replace("}\",", "},");
            
            JToken result = JToken.Parse(jsonString.ToString());

            return result;
        }
    }
}
