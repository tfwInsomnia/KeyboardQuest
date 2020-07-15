using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Console_RPG {
    public static class DataManager {

        public static bool Save<T>(string fileName, Object obj) {

            var xs = new XmlSerializer(typeof(T));
            using (TextWriter sw = new StreamWriter(fileName)) {
                xs.Serialize(sw,obj);
            }

            if (File.Exists(fileName)) return true;
            return false;
        }

        public static T Load<T>(string fileName) {

            Object rslt;
            if (File.Exists(fileName)) {
                var xs = new XmlSerializer(typeof(T));
                using(var sr = new StreamReader(fileName)) {
                    rslt = (T)xs.Deserialize(sr);
                }
                return (T)rslt;
            } else {
                return default(T);
            }

        }
    }
}
