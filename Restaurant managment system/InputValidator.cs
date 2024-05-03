using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class InputValidator
{
    public static string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static int ReadInt(string prompt)
    {
        int output;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out output))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input, please enter a valid integer.");
            Console.ResetColor();
            Console.Write(prompt);
        }
        return output;
    }

    public static decimal ReadDecimal(string prompt)
    {
        decimal output;
        Console.Write(prompt);
        while (!decimal.TryParse(Console.ReadLine(), out output))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input, please enter a valid decimal.");
            Console.ResetColor();
            Console.Write(prompt);
        }
        return output;
    }

    public static float ReadFloat(string prompt)
    {
        float output;
        Console.Write(prompt);
        while (!float.TryParse(Console.ReadLine(), out output))
        {
            Console.WriteLine("Invalid input, please enter a valid float.");
            Console.Write(prompt);
        }
        return output;
    }

    public static double ReadDouble(string prompt)
    {
        double output;
        Console.Write(prompt);
        while (!double.TryParse(Console.ReadLine(), out output))
        {
            Console.WriteLine("Invalid input, please enter a valid double.");
            Console.Write(prompt);
        }
        return output;
    }
}
