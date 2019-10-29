using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAttribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class | AttributeTargets.Struct)]
    public class EncryptionAttribute : System.Attribute
    {
        public static string ClassName;
        public object[] Parametrs;

        public EncryptionAttribute(string className, params object[] parametrs)
        {
            ClassName = className;
            Parametrs = parametrs;
        }

        public IEncryptionService MyClassType = Activator.CreateInstance(Type.GetType(ClassName)) as IEncryptionService;

       public void Encryption()
        {
            MyClassType.Encrypt(Parametrs[1].ToString(), Parametrs[2], Parametrs[3].ToString());
        }

        //public T Decryption<T>()
        //{
        //    return MyClassType.Decrypt(Parametrs[1].ToString(), Parametrs[3].ToString());
        //}
    }
}
