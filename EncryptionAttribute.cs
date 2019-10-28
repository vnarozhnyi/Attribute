using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class EncryptionAttribute : System.Attribute
    {
        public static string ClassName;
        private object[] Parametrs;

        public EncryptionAttribute(string className, params object[] parametrs)
        {
            ClassName = className;
            Parametrs = parametrs;
        }
        
        EncryptionAttribute MyClassType = (EncryptionAttribute)Activator.CreateInstance(Type.GetType(ClassName));
    }
}
