using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace CreateAttribute
{
    public interface IEncryptionService
    {
        void Encrypt<T>(string filename, T obj);
        T Decrypt<T>(string filename);
    }
    [XmlTypeAttribute(AnonymousType = true)]
    public class EncryptionService : IEncryptionService
    {
        
        public T Decrypt<T>(string filename)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "anyType";
            DESCryptoServiceProvider DESalg = new DESCryptoServiceProvider();
            byte[] key = { 127, 101, 173, 226, 108, 89, 33, 128 };
            byte[] keyIV = { 68, 160, 246, 137, 229, 210, 20, 239 };
            var d = DESalg.CreateDecryptor(key, keyIV);
            using (var fs = File.Open(filename, FileMode.Open))
            using (var cs = new CryptoStream(fs, d, CryptoStreamMode.Read))
                return (T)(new XmlSerializer(typeof(T), xRoot)).Deserialize(cs);
        }

        public void Encrypt<T>(string filename, T obj)
        {
            DESCryptoServiceProvider DESalg = new DESCryptoServiceProvider();
            byte[] key = { 127, 101, 173, 226, 108, 89, 33, 128 };
            byte[] keyIV = {68, 160, 246, 137, 229, 210, 20, 239}; 
            var e = DESalg.CreateEncryptor(key, keyIV); 
            using (var fs = File.Open(filename, FileMode.Create))    
            using (var cs = new CryptoStream(fs, e, CryptoStreamMode.Write))
                (new XmlSerializer(typeof(T))).Serialize(cs, obj);
        }
    }
}
