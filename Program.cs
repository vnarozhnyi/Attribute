using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    class Program
    {
        public class TestAttribute
        {
            [Encryption(className: "EncryptionService", parametrs: new object[] { "testfile.xml", test, "key" })]
            public const string test = "test";
           
        }

        static void Main(string[] args)
        {
         
        }
    }
}
