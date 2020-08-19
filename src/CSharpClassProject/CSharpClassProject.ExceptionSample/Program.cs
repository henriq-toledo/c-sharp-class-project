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


            try
            {
                ExceptionMethod();
            }
            catch
            {
                Console.WriteLine("Other catch");
            }

            Console.ReadLine();
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
