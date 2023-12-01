using System;
using System.Text;

namespace P01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string input = "";
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] instructions = input.Split(" ");
                string command = instructions[0];

                if (command == "TakeOdd")
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            sb.Append(password[i]);
                        }
                    }
                    password = sb.ToString();
                    Console.WriteLine(password);

                }
                else if (command == "Cut")
                {
                    int index = int.Parse(instructions[1]);
                    int length = int.Parse(instructions[2]);
                    password = password.Remove(index, length);
                    Console.WriteLine(password);

                }
                else if (command == "Substitute")
                {
                    string textToreplace = instructions[1];
                    string substutite = instructions[2];
                    if (!password.Contains(textToreplace))
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                    else
                    {
                        while (password.Contains(textToreplace))
                        {
                            password = password.Replace(textToreplace, substutite);

                        }

                        Console.WriteLine(password);
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}