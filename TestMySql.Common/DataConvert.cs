using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMySql.Common
{
    public static class DataConvert
    {
        public static DateTime NullDate = new DateTime(1900, 1, 1);
        /// <summary>
        /// 转为int值(转型失败返回0)
        /// </summary>
        /// <param name="fValue">原值</param>
        /// <returns></returns>
        public static int ToInt32(object fValue)
        {
            return ToInt32(fValue, 0);
        }
        /// <summary>
        /// 转为int值
        /// </summary>
        /// <param name="fValue">原值</param>
        /// <param name="defaultValue">转型失败返回值</param>
        /// <returns></returns>
        public static int ToInt32(object fValue, int defaultValue)
        {
            int returnValue = defaultValue;
            if (object.Equals(fValue, null))
            {
                return defaultValue;
            }
            else if (fValue is Enum)
            {
                return Convert.ToInt32(fValue);
            }
            else if (int.TryParse(fValue.ToString(), System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out returnValue))
            {
                return returnValue;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 转为int值(转型失败返回0)
        /// </summary>
        /// <param name="fValue">原值</param>
        /// <returns></returns>
        public static UInt16 ToUInt16(object fValue)
        {
            return ToUInt16(fValue, 0);
        }
        /// <summary>
        /// 转为int值
        /// </summary>
        /// <param name="fValue">原值</param>
        /// <param name="defaultValue">转型失败返回值</param>
        /// <returns></returns>
        public static UInt16 ToUInt16(object fValue, ushort defaultValue)
        {
            ushort returnValue = defaultValue;
            if (object.Equals(fValue, null))
            {
                return defaultValue;
            }
            else if (ushort.TryParse(fValue.ToString(), out returnValue))
            {
                return returnValue;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 转换为byte
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static byte ToByte(object fValue)
        {
            return ToByte(fValue, 0);
        }

        /// <summary>
        /// 转换为byte
        /// </summary>
        /// <param name="fValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static byte ToByte(object fValue, byte defaultValue)
        {
            byte returnValue = defaultValue;
            if (object.Equals(fValue, null))
            {
                return defaultValue;
            }
            if (byte.TryParse(fValue.ToString(), out returnValue))
            {
                return returnValue;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object fValue)
        {
            return ToDecimal(fValue, 0);
        }

        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <param name="fValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object fValue, decimal defaultValue)
        {
            decimal returnValue = defaultValue;
            if (object.Equals(fValue, null))
            {
                return defaultValue;
            }
            if (decimal.TryParse(fValue.ToString(), out returnValue))
            {
                return returnValue;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 转换为string
        /// </summary>
        /// <param name="fValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string ToString(object fValue)
        {
            if (object.Equals(fValue, null))
            {
                return "";
            }
            return fValue.ToString();
        }
        /// <summary>
        /// 转换为时间格式，失败返回1900-1-1
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object fValue)
        {
            if (object.Equals(fValue, null))
            {
                return NullDate;
            }
            DateTime returnValue = NullDate;
            if (DateTime.TryParse(fValue.ToString(), out returnValue))
            {
                return returnValue;
            }
            else
            {
                return NullDate;
            }
        }
        /// <summary>
        /// 转换为bool值
        /// </summary>
        /// <param name="fValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Boolean ToBoolean(object fValue)
        {
            return ToBoolean(fValue, false);
        }
        /// <summary>
        /// 转换为bool值
        /// </summary>
        /// <param name="fValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Boolean ToBoolean(object fValue, bool defaultValue)
        {
            if (object.Equals(fValue, null))
            {
                return defaultValue;
            }
            bool returnValue = defaultValue;
            if (bool.TryParse(fValue.ToString(), out returnValue))
            {
                return returnValue;
            }
            return defaultValue;
        }


        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static Guid ToGuid(object fValue)
        {
            return ToGuid(fValue, Guid.Empty);
        }

        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <param name="fValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid ToGuid(object fValue, Guid defaultValue)
        {
            Guid returnValue = defaultValue;
            if (object.Equals(fValue, null))
            {
                return defaultValue;
            }
            if (Guid.TryParse(fValue.ToString(), out returnValue))
            {
                return returnValue;
            }
            return defaultValue;
        }

        /// <summary>
        /// base64转成utf8
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string FromBase64String(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return "";
            return Encoding.UTF8.GetString(Convert.FromBase64String(content));
        }
        /// <summary>
        /// utf8转成base64
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string ToBase64String(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return "";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(content));
        }

        /// <summary>
        /// 返回时间差  单位：天
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <returns></returns>
        public static int DateDiff(DateTime DateTime1)
        {
            int dateDiff = 0;
            try
            {
                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                dateDiff = ts.Days;
            }
            catch
            {

            }
            return dateDiff;
        }

        /// <summary>
        /// 将长整型转换为时间格式
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ConvertToDate(long d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time.ToString("yyyy-MM-dd");

        }

        /// <summary>
        /// 将时间类型转换为整型
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static long ConvertToBigint(DateTime d)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            TimeSpan ts1 = new TimeSpan(startTime.Ticks);
            TimeSpan ts2 = new TimeSpan(d.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            double ss = (d - startTime).TotalSeconds;
            return long.Parse(Math.Round(ss).ToString());
        }

    }
}
