using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Autoatendimento.Test.Helper
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj)
        {
            var serializer = new JsonSerializer
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new ExcludeStreamContractResolver()
            };
            var stringWriter = new StringWriter();
            var jsonWriter = new JsonTextWriter(stringWriter);
            serializer.Serialize(jsonWriter, obj);

            return stringWriter.ToString();
        }

        public static T FromJson<T>(this object obj)
        {
            return JsonConvert.DeserializeObject<T>(obj as string);
        }
    }

    public class ExcludeStreamContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            if (type == typeof(Stream) || type.IsSubclassOf(typeof(Stream)))
            {
                return new List<JsonProperty>();
            }

            var itens = base.CreateProperties(type, memberSerialization).ToList();

            return itens.FindAll(p => !(p.PropertyType == typeof(Stream) || p.PropertyType.IsSubclassOf(typeof(Stream))));
        }
    }	

}
