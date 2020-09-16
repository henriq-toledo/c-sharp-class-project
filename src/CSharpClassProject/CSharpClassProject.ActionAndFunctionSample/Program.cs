using System;
using System.Collections.Generic;

namespace CSharpClassProject.ActionAndFunctionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ActionSample();
            ActionExercise();

            Console.ReadLine();
        }

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
