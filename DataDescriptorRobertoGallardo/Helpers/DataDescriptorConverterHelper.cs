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
        internal static string ConvertJsonToDataDescriptor(Type classObject, JObject payload ) 
        {
            DataDescriptor dataDescriptor = ConvertClassToDataDescriptor(classObject);


            string result = JsonConvert.SerializeObject(ConvertJsonToClass(classObject, dataDescriptor, payload));
            return result;
        }

        internal static object ConvertJsonToClass(Type type, DataDescriptor dataDescriptor, JObject payload)
        {
            object result = Activator.CreateInstance(type);

            type.GetField(dataDescriptor.Name).SetValue(result, payload);

            return result;
            
        }

            internal static DataDescriptor ConvertClassToDataDescriptor(Type type)
        {
            DataDescriptor dataDescriptor = new();
                dataDescriptor.Primitive = type.IsPrimitive;
                dataDescriptor.Name= type.Name;
                dataDescriptor.Alias= "";
                dataDescriptor.MapDescription= "";
                dataDescriptor.Multiple = false;
                dataDescriptor.Fields = GetDataDescriptorFields(type);

           return dataDescriptor;
        }
        internal static DataDescriptor[] GetDataDescriptorFields(Type type)
        {
            List<DataDescriptor> dataDescriptorProperties = new();

            foreach (FieldInfo field in type.GetFields())
            {
                DataDescriptor dataDescriptor = new();
                dataDescriptor.Primitive = field.FieldType.IsPrimitive;
                dataDescriptor.Name = field.Name;
                dataDescriptor.Alias = "";
                dataDescriptor.MapDescription = "";
                dataDescriptor.Multiple = false;
                if(!field.FieldType.IsPrimitive && field.FieldType != typeof(string)) dataDescriptor.Fields = GetDataDescriptorFields(field.FieldType);
                dataDescriptorProperties.Add(dataDescriptor);
            }
            return dataDescriptorProperties.ToArray();
        }
    }
}
