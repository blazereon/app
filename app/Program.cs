using System;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();
    static int maxNum = 5; // Maximum number of recursion
    static int keyNum = 0; // Track number of keys
    static List<string> transitions = new List<string>(); // List to track room transitions

    static void Main(string[] args)
    {
        string randomString = genRoom("START", 0); // Start with depth 0
        Console.Write(randomString);
        Console.Write("EXIT");

        Console.WriteLine("\n\nRoom Transitions:");
        foreach (var transition in transitions)
        {
            Console.WriteLine(transition);
        }
    }

    static string genRoom(string symbol, int numCount)
    {
        if (numCount >= maxNum)
        {
            return "";
        }

        if (symbol == "START")
        {
            transitions.Add("START -> ROOM");
            return "START -> " + genRoom("ROOM", numCount + 1) + genRoom("CONTENT", numCount + 1);
        }
        else if (symbol == "CONTENT")
        {
            int choice = random.Next(3);
            if (choice == 0)
            {
                transitions.Add("CONTENT -> ROOM");
                return genRoom("ROOM", numCount + 1);
            }
            else if (choice == 1 && keyNum < 3)
            {
                keyNum++;
                transitions.Add("CONTENT -> KEY");
                var result = genRoom("KEY", numCount + 1);
                transitions.Add("KEY -> CONTENT");
                result += genRoom("CONTENT", numCount + 1);
                transitions.Add("CONTENT -> LOCK");
                result += genRoom("LOCK", numCount + 1);
                transitions.Add("LOCK -> CONTENT");
                result += genRoom("CONTENT", numCount + 1);
                return result;
            }
            else
            {
                transitions.Add("CONTENT -> CONTENT");
                return genRoom("CONTENT", numCount + 1);
            }
        }
        else if (symbol == "ROOM")
        {
            return "ROOM -> ";
        }
        else if (symbol == "KEY")
        {
            return "KEY -> ";
        }
        else if (symbol == "LOCK")
        {
            return "LOCK -> ";
        }
        else
        {
            return "";
        }
    }
}
