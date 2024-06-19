using static System.Console;
using CalculatorLibrary;

namespace CalculatorProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool endApp = false;

            WriteLine("Console Calculator in C#\r");
            WriteLine("--------------------------------\n");

            // 初始化化一个计算器的实例
            Calculator calculator = new Calculator();


            while (!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;
                
                WriteLine("Type a number, and then press Enter");
                numInput1 = ReadLine();

                double cleanNum1 = 0;
                while(!double.TryParse(numInput1, out cleanNum1))
                {
                    Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = ReadLine();
                }

                WriteLine("Type another number, and then press Enter: ");
                numInput2 = ReadLine();


                double cleanNum2 = 0;

                while(!double.TryParse(numInput2, out cleanNum2))
                {
                    Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = ReadLine();
                }

                WriteLine("Choose an option from the following list:");
                WriteLine("\ta - Add");
                WriteLine("\ts - Subtract");
                WriteLine("\tm - Multiply");
                WriteLine("\td - Divide");
                Write("Your option? ");

                string op = ReadLine();

                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);

                    if (double.IsNaN(result))
                    {
                        WriteLine("This operation will result in a mathmatical error.\n");
                    }
                    else
                        WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    WriteLine("oh no! An exception occured trying to do the math.\n - Details: " + e.Message);
                }

                WriteLine("-----------------------------------------------\n");

                WriteLine("Press 'n' and Enter to close the app, or press another key and Enter to continue: ");
                if (ReadLine() != "n")
                {
                    endApp = true;
                }
            }

            return;
        }
    }
}
