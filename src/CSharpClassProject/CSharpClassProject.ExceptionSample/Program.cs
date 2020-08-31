using System;
using System.IO;

namespace CSharpClassProject.ExceptionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nullable<int> value1 = 0;
            // int? value = value1;

            // int? value2 = null;

            // Console.WriteLine(value2 == null ? 1 : value2);
            // Console.WriteLine(value2 ?? 1);            

            //Console.WriteLine(value2.GetValueOrDefault());

            // if (value2.HasValue)
            //Console.WriteLine(value2.Value);

            // var note = "test";
            // var a = note.Equals("test");


            // try
            // {
            //     ExceptionMethod();
            // }
            // catch
            // {
            //     Console.WriteLine("Other catch");
            // }

            //Divide();

            OpenFile();

            Console.ReadLine();
        }

        public static void TestMethod(ref bool a)
        {
        }

        public static void Divide()
        {
            try
            {
                var a = 0;
                var b = 1 / a;

                Console.WriteLine(b);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void OpenFile()
        {
            try
            {
                var file = File.Open(@"C:\Temp\abcd.txt", FileMode.Open);	
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não existe");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        static void ExceptionMethod()
        {
            try
            {
                Console.WriteLine("try");

                string text = null;

                // if (text == null)
                //     throw new Exception("Null object");

                Console.WriteLine(text.ToUpper());
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.GetBaseException().ToString());
                throw; // line 47
                       // throw ex; // line 53
                       // throw new Exception("Null object");
            }            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }
    }
}
