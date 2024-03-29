﻿using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreateAttribute
{
    class Program
    {
        public class TestAttribute
        {
            [Encryption(className: "CreateAttribute.EncryptionService", parametrs: new object[] { "testfile.xml", test })]
            public const string test = "test";

            public void GetAttribute(object obj)
            {
                var filedInfo = typeof(TestAttribute).GetField(test); 
                var encryptionAttribute = filedInfo.GetCustomAttribute(typeof(EncryptionAttribute)) as EncryptionAttribute;

                if(encryptionAttribute == null)
                {
                    Console.WriteLine("Attribute not found");
                }

                encryptionAttribute.Encryption();
            }
        }

        static void Main()
        {
            TestAttribute test = new TestAttribute();
            test.GetAttribute(TestAttribute.test); 

        }
    }
}
