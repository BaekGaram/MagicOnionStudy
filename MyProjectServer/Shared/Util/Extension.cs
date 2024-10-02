using System;
using Newtonsoft.Json;

namespace Shared.Util
{
    public static class Extension
    {
        public static T ToPacket<T>(this string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception)
            {
                return default(T); // 역직렬화 실패 시 기본값 반환 (참조형은 null, 값형은 기본값)
            }
        }

        public static string ToJson<T>(this T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}