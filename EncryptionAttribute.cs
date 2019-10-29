using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAttribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class | AttributeTargets.Struct)]
    public class EncryptionAttribute : Attribute
    {
        private static string className;
        private object[] parametrs;

        public EncryptionAttribute(string className, params object[] parametrs)
        {
            ClassName = className;
            Parametrs = parametrs;
        }

        public static string ClassName { get => className; set => className = value; }
        public object[] Parametrs { get => parametrs; set => parametrs = value; }

        public IEncryptionService MyClassType = Activator.CreateInstance(Type.GetType(className)) as IEncryptionService;

       

        public void Encryption()
        {
            MyClassType.Encrypt(Parametrs[0].ToString(), Parametrs[1]);
        }

        public T Decryption<T>()
        {
            return MyClassType.Decrypt<T>(Parametrs[0].ToString());
        }
    }
}
