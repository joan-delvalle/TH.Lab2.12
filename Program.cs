using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Lab2._12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
                List<int> evaluated = new List<int>();

                Console.WriteLine("=== Array Expression Evaluator ===");

                Console.WriteLine("Enter 10 integers:");
                while (numbers.Count < 10)
                {
                    Console.Write($"Number #{numbers.Count + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int input))
                    {
                        numbers.Add(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                }

                Console.WriteLine("\nEnter a formula using 'x' (e.g., (2*x + 3) % 5):");
                string formula = Console.ReadLine();

                foreach (int x in numbers)
                {
                    string expression = formula.Replace("x", x.ToString());

                    try
                    {
                        object result = new DataTable().Compute(expression, "");
                        if (int.TryParse(result.ToString(), out int value))
                            evaluated.Add(value);
                        else
                            evaluated.Add((int)Math.Round(Convert.ToDouble(result)));
                    }
                    catch
                    {
                        Console.WriteLine($"Error evaluating expression for x = {x}. Using 0.");
                        evaluated.Add(0);
                    }
                }

                Console.WriteLine("\n--- Results ---");
                Console.WriteLine("Original Array: " + string.Join(", ", numbers));
                Console.WriteLine("Evaluated Array: " + string.Join(", ", evaluated));
            
        }
    }

}
    

