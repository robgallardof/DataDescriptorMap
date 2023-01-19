using DataDescriptorRobertoGallardo.Class;
using Newtonsoft.Json.Linq;
using System.Text;

namespace DataDescriptorRobertoGallardo.Helpers
{
    internal static class PayloadConverterHelper
    {
        #region Constants

        private const string DATE_FORMAT = "dd/MM/yyyy hh:mm:ss";

        #endregion Constants

        #region Methods

        /// <summary>
        /// Generate Json Object using a DataDescriptor.
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="dataDescriptorObject"></param>
        /// <returns></returns>
        internal static JToken PayloadConvert(JObject payload, DataDescriptor dataDescriptorObject)
        {
            return PayloadConvert(payload, dataDescriptorObject, new DataDescriptor[] { dataDescriptorObject });
        }

        /// <summary>
        /// Generate Json Object using DataDescriptors.
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <param name="currentDataDescriptor"></param>
        /// <param name="dataDescriptors"></param>
        /// <returns></returns>
        internal static JToken PayloadConvert(JToken jsonObject, DataDescriptor currentDataDescriptor, DataDescriptor[] dataDescriptors)
        {
            StringBuilder jsonString = new();
            jsonString.Append("{");

            foreach (var item in currentDataDescriptor.Fields)
            {
                string value = jsonObject[item.Name]?.ToString();

                DataDescriptor dataDescriptorField = dataDescriptors.FirstOrDefault(x => x.Name.Equals(item.Type));
                if (dataDescriptorField == null)
                {
                    if (nameof(DateTime).ToUpper().Equals(item.Type.ToUpper()))
                        value = DateTime.Parse(value).ToString(DATE_FORMAT);

                    jsonString.Append($"\"{item.Alias}\":\"{value}\",");
                }
                else
                {
                    if (dataDescriptors != null)
                    {
                        if (item.Multiple)
                        {
                            jsonString.Append($"\"{item.Alias}\":[");
                            foreach (JToken jToken in jsonObject[item.Name])
                            {
                                jsonString.Append($"{PayloadConvert(jToken, dataDescriptorField, dataDescriptors).ToString()},");
                            }
                            jsonString.Append(']');
                        }
                        else
                        {
                            jsonString.Append($"\"{item.Alias}\":\"{PayloadConvert(JToken.Parse(value), dataDescriptorField, dataDescriptors).ToString()}\",");
                        }
                    }
                }
            }

            jsonString = jsonString.Replace("\"[", "[").Replace("]\"", "]").Replace(":\"{", ":{").Replace("}\",", "},");

            jsonString.Append("}");
            JToken result = JToken.Parse(jsonString.ToString());

            return result;
        }

        #endregion Methods
    }
}