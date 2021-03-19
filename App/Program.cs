﻿using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();

            int cursorX, cursorY;
            cursorX = Console.CursorLeft;
            cursorY = Console.CursorTop;

            var answer = ShowMenu("Here is some text. Choose an option",
                new List<string> { "Option 1", "Option 2", "Option 3" });

            Console.WriteLine($"You chose: {answer}");

            string ShowMenu(string prompt, List<string> options)
            {
                int selectedMenuItem = 0;

                Console.Clear();
                Console.WriteLine(prompt);

                while(true)
                {
                    ShowMenuItems(options);

                    var key = Console.ReadKey();

                    if (key.Key == System.ConsoleKey.DownArrow
                        && selectedMenuItem < options.Count - 1)
                    {
                        selectedMenuItem++;
                    }

                    if (key.Key == System.ConsoleKey.UpArrow
                        && selectedMenuItem > 0)
                    {
                        selectedMenuItem--;
                    }

                    if (key.Key == System.ConsoleKey.Enter)
                    {
                        return options[selectedMenuItem];
                    }
                }

                void ShowMenuItems(List<string> options)
                {
                    Console.SetCursorPosition(cursorX, cursorY);

                    for(int i = 0; i < options.Count; i++)
                    {
                        if (i == selectedMenuItem)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }

                        Console.WriteLine(options[i]);
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
