using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace SiHan.Libs.Utils.Text
{
    /// <summary>
    /// 序列化帮助类
    /// </summary>
    public static class SerializeHelper<T> where T : class, new()
    {
        /// <summary>
        /// 将对象序列化为XML文本
        /// </summary>
        public static string ToXml(T obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (Utf8StringWriter stringWriter = new Utf8StringWriter())
                {
                    serializer.Serialize(stringWriter, obj);
                    return stringWriter.ToString();
                }
            }
        }

        /// <summary>
        /// XML反序列化
        /// </summary>
        public static T FromXml(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StringReader sr = new StringReader(xml))
                {
                    return (T)serializer.Deserialize(sr);
                }
            }
        }

        /// <summary>
        /// 序列化对象为byte数组
        /// </summary>
        public static byte[] ToBytes(T obj)
        {
            if (obj == null)
            {
                return null;
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream())
                {
                    formatter.Serialize(stream, obj);
                    return stream.ToArray();
                }
            }
        }

        /// <summary>
        /// 将byte数组反序列化为对象
        /// </summary>
        public static T FromBytes(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            else
            {
                using (var memStream = new MemoryStream())
                {
                    var binForm = new BinaryFormatter();
                    memStream.Write(bytes, 0, bytes.Length);
                    memStream.Seek(0, SeekOrigin.Begin);
                    var obj = (T)binForm.Deserialize(memStream);
                    return obj;
                }
            }
        }

        /// <summary>
        /// 序列化到JSON字符串
        /// </summary>
        public static string ToJson(T obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {
                return JsonConvert.SerializeObject(obj);
            }
        }

        /// <summary>
        /// 从JSON反序列化到对象
        /// </summary>
        public static T FromJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}



