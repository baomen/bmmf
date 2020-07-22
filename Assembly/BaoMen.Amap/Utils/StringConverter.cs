using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Utils
{
    /// <summary>
    /// 字符串转换器。针对高德字符串返回空数组使用
    /// </summary>
    public class StringConverter : JsonConverter
    {
        /// <summary>
        /// 是否可以转换
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string) || objectType == typeof(string[]);
        }

        /// <summary>
        /// 读取JSON
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)  //数组;
            {
                serializer.Deserialize<string[]>(reader);
                return null;
            }
            else
            {
                return serializer.Deserialize<string>(reader);
            }
        }

        /// <summary>
        /// 写JSON
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
