using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMySql.Common
{
    public class JsonConvert
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string json)
        {
            try
            {
                T t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                return t;
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObject(object value)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy/MM/dd HH:mm:ss";
            return Newtonsoft.Json.JsonConvert.SerializeObject(value, timeFormat);
        }
    }
}
