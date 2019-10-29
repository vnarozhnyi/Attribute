using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAttribute
{
    class Program
    {
        public class TestAttribute
        {
            [Encryption(className:"EncryptionService", parametrs: new object[] { "testfile.xml", test, "key" })]
            public static string test = "test";

            public void GetAttribute(Type t)
            {
                EncryptionAttribute MyAttribute = (EncryptionAttribute)Attribute.GetCustomAttribute(t, typeof(EncryptionAttribute));

                if (MyAttribute == null)
                {
                    Console.WriteLine("Attribute not fond");
                }

                MyAttribute.Encryption();
            }
        }

        static void Main()
        {
            TestAttribute test = new TestAttribute();
            test.GetAttribute(typeof(Program));

        }
    }
}
