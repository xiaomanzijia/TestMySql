using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestMySql.Model;
using TestMySql.Common;


namespace TestMySql.App_Start
{
    public class JsonNetFormatter : MediaTypeFormatter
    {

        public JsonNetFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
        }

        public override bool CanWriteType(Type type)
        {
            // don't serialize JsonValue structure use default for that
            //if (type == typeof(JsonValue) || type == typeof(JsonObject) || type == typeof(JsonArray))
            //    return false;

            return true;
        }

        public override bool CanReadType(Type type)
        {
            //if (type == typeof(IKeyValueModel))
            //    return false;
            return true;
        }

        public override System.Threading.Tasks.Task<object> ReadFromStreamAsync(Type type, Stream stream, HttpContent formatterContext, IFormatterLogger formatterLogger)
        {
            var task = Task<object>.Factory.StartNew(() =>
            {
                var settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };

                var sr = new StreamReader(stream);
                var jreader = new JsonTextReader(sr);

                var ser = new JsonSerializer();
                ser.Converters.Add(new IsoDateTimeConverter());

                object val = ser.Deserialize(jreader, type);
                return val;
            });

            return task;
        }

        public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, System.IO.Stream stream, HttpContent formatterContext, System.Net.TransportContext transportContext)
        {
            if (value is HttpError)
            {
                HttpError error = (HttpError)value;
                CommonCallBack cbModel = new CommonCallBack();
                cbModel.code = -1;
                cbModel.opcode = DataConvert.ToString(HttpContext.Current.Request.RequestContext.RouteData.Values["action"]);
                if (error.ContainsKey("ExceptionMessage"))
                {
                    cbModel.msg = DataConvert.ToString(error["ExceptionMessage"]);
                }
                else if (error.ContainsKey("Message"))
                {
                    cbModel.msg = DataConvert.ToString(error["Message"]);
                }
                else
                {
                    cbModel.msg = "未知错误";
                }
                cbModel.status = "exception";
                value = cbModel;
            }
            var task = Task.Factory.StartNew(() =>
            {
                var settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };

                string json = TestMySql.Common.JsonConvert.SerializeObject(value);

                byte[] buf = System.Text.Encoding.UTF8.GetBytes(json);
                stream.Write(buf, 0, buf.Length);
                stream.Flush();
            });

            return task;
        }
    }
}