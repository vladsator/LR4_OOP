using System;
using System.Collections.Generic;

namespace LR_3_code_Cch
{
    internal class Program
    {
        // Create a delegate.
        delegate string Del(string str);

        // Instantiate the delegate using an anonymous method.
        

        static void Main()
        {
            Del d = delegate (string str)
            {
                char[] strToArray = str.ToCharArray();
                int num;
                int charCounter = 0;
                int intCounter = 0;
                foreach (var ch in strToArray)
                {
                    if (int.TryParse(ch.ToString(), out num))
                    {
                        intCounter++;
                    }
                    else
                    {
                        charCounter++;
                    }
                }
                if (charCounter > intCounter)
                    return "Символов больше!";
                else
                {
                    return "Цифр больше!";
                }
            };

            GetWinner(d, "sdfd5588888888888888888888888888494fdgdh19/9b4dgtdfgdf");

            var myList = new MyList<int>();
            myList.Clearing += MyList_Clearing;

            myList.Add(5);
            myList.Add(10);
            myList.Add(14);

            myList.Clear();

            myList.Add(5);
            myList.Add(10);
            myList.Add(14);

            myList.Clear();

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void MyList_Clearing(object sender, ClearEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void GetWinner(Del method, string str)
        {
            Console.WriteLine(method(str));
        }
    }
}
