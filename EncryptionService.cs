using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace CreateAttribute
{
    public interface IEncryptionService
    {
        void Encrypt<T>(string filename, T obj, string encryptionKey);
        T Decrypt<T>(string filename, string encryptionKey);
    }

    public class EncryptionService : IEncryptionService
    {
        public T Decrypt<T>(string filename, string encryptionKey)
        {
            var key = new DESCryptoServiceProvider();
            var d = key.CreateDecryptor(Encoding.ASCII.GetBytes("64bitPas"), Encoding.ASCII.GetBytes(encryptionKey));
            using (var fs = File.Open(filename, FileMode.Open))
            using (var cs = new CryptoStream(fs, d, CryptoStreamMode.Read))
                return (T)(new XmlSerializer(typeof(T))).Deserialize(cs);
        }

        public void Encrypt<T>(string filename, T obj, string encryptionKey)
        {
            var key = new DESCryptoServiceProvider();
            var e = key.CreateEncryptor(Encoding.ASCII.GetBytes("64bitPas"), Encoding.ASCII.GetBytes(encryptionKey));
            using (var fs = File.Open(filename, FileMode.Create))
            using (var cs = new CryptoStream(fs, e, CryptoStreamMode.Write))
                (new XmlSerializer(typeof(T))).Serialize(cs, obj);
        }
    }
}
