using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Utills.Serialize
{
    public class SerializeJson
    {
        /// <summary>
        /// 単純読み込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public T Read<T>(string path)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            T obj = default(T);
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (fs)
            {
                obj = (T)serializer.ReadObject(fs);
            }
            return obj;
        }

        /// <summary>
        /// 単純書き込み
        /// </summary>
        public void Write<T>(T obj, string path)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.WriteObject(fs, obj);
            }
        }
    }
    
}
