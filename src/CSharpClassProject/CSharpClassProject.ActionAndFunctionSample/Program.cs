using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpClassProject.ActionAndFunctionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Action Sample");
            Console.WriteLine();

            ActionSample();

            Console.WriteLine();
            Console.WriteLine("Action Exercise");
            Console.WriteLine();

            ActionExercise();

            Console.WriteLine();
            Console.WriteLine("Function Sample");
            Console.WriteLine();

            FunctionSample();

            Console.WriteLine();
            Console.WriteLine("Function Exercise");
            Console.WriteLine();

            FunctionExercise();

            Console.ReadLine();
        }        

        #region Function

        static void FunctionSample()
        {
            Func<string> function1 = () => "Hello Function1!";
            function1 += () => 
            {
                return "Hello Function 2!";
            };

            function1 += MessageFunction;

            Console.Write(function1.Invoke());

            foreach (var item in function1.GetInvocationList())
            {
                Console.WriteLine(item.DynamicInvoke());
            }            

            Func<int, int, string> function2 = (int a, int b) => $"{a + b}";
            function2 += (a, b) => $"{a}{b}";
            function2 += MessageFunction1;

            foreach (var item in function2.GetInvocationList())
            {
                Console.WriteLine((string)item.DynamicInvoke(new object[] { 1, 2 }));
            }
        }

        static string Sum(decimal a, decimal b)
        {
            return $"Sum: {a + b}";
        }

        static string MessageFunction()
        {
            return "Hello Function3!";
        }

        static string MessageFunction1(int number1, int number2)
        {
            return "Hello Function3!";
        }

        static void FunctionExercise()
        {
            // Exercise: Calculator (use decimal as parameter)
            // Sum
            // Minus
            // Multiply
            // Divide

            Func<decimal, decimal, string> calculator = (a, b) => $"Sum: {a + b}";
            calculator += (a, b) => $"Minus: {a - b}";
            calculator += (a, b) => $"Multiply: {a * b}";
            calculator += (a, b) => $"Divide: {a / b}";

            foreach (var calc in calculator.GetInvocationList())
            {
                Console.WriteLine(calc.DynamicInvoke(new object[] { 1m, 2m }));
            }
        }

        #endregion Function

        #region Action

        static void ActionSample()
        {
            // Action without parameter

            Action action1 = () => Console.WriteLine("This is an action!");
            action1 += () =>
            {
                Console.WriteLine("This is an action 1!");
                Console.WriteLine("This is an action 2!");
            };

            action1 += Message;

            action1.Invoke();

            // Action with parameter

            // Action<string> action = (string text) => Console.WriteLine(text); 
            Action<string> action2 = (text) => Console.WriteLine(text);
            action2 += MessageText;

            action2.Invoke("");

            var list = new List<string>();
            list.ForEach(s => Console.WriteLine(s));

            // Action with parameters

            Action<string, int> action3 = MessageTextWithValue;
            action3.Invoke(arg2: 0, arg1: "");

            Action action4 = () => Console.WriteLine("This is an action!");
            action4 += () =>
            {
                Console.WriteLine("This is an action 1!");
                Console.WriteLine("This is an action 2!");
            };

            action4 = Message;
            action4 = null;

            if (action4 != null)
                action4.Invoke();

            action4?.Invoke();
        }

        static void ActionExercise()
        {
            // Exercise: Calculator (use decimal as parameter)
            // Sum
            // Minus
            // Multiply
            // Divide

            Action<decimal, decimal> calculator;

            calculator = (a, b) => Console.WriteLine($"Sum: {a + b}");
            calculator += (a, b) => Console.WriteLine($"Minus: {a - b}");
            calculator += (a, b) => Console.WriteLine($"Divide: {a / b}");
            calculator += (a, b) => Console.WriteLine($"Multiply: {a * b}");

            calculator.Invoke(4, 2);
        }

        static void Message()
        {
            Console.WriteLine("Message");
        }

        static void MessageText(string value = "")
        {
            Console.WriteLine(value);
        }

        static void MessageTextWithValue(string value, int number)
        {
            Console.WriteLine($"{value} {number}");
        }

        static void MessageTextWithValue2(int number, string value)
        {
            Console.WriteLine($"{value} {number}");
        }

        #endregion Action        
    }
}
