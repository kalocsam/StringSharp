using Newtonsoft.Json;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using System;
namespace StringSharp.Conversions
{
    public static class StringConversions
    {
        /// <summary>
        /// Create Uri object from string value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Uri AsUri(this string value)
        {
            return new Uri(value);
        }


        /// <summary>
        /// Create Uri object from string value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="uriKind"></param>
        /// <returns></returns>
        public static Uri AsUri(this string value, UriKind uriKind)
        {
            return new Uri(value, uriKind);
        }


        /// <summary>
        /// Deserialize json string to given T type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? FromJsonAs<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }


        /// <summary>
        /// Convert string to number.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Example value: "1", "1.0"</param>
        /// <returns></returns>
        public static T AsNumber<T>(this string value) where T : INumber<T>
        {
            return T.Parse(value, null);
        }


        /// <summary>
        /// Split string by space, semi-colon (;), tab (\t) or new line (\r, \n)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Example values: "1 2 3 4", "1;2;3;4", "1 2   3   4"</param>
        /// <returns></returns>
        public static IEnumerable<T> AsNumbers<T>(this string value) where T : INumber<T>
        {
            foreach (var toConvert in value.Split(new[] { ' ', ';', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                yield return T.Parse(value, null);
            }
        }

        ///// <summary>
        ///// Split the string values to char array.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static char[] AsEnumerable(this string value)
        //{
        //    var spanValue = value.AsSpan();
        //    return spanValue.ToArray();
        //}
    }
}
