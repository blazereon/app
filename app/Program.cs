using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

class Program
{
    static Random random = new Random();
    static int maxNum = 5; // Maximum number of recursion
    static int keyNum = 0; // Maximum number of key/lock room pairs

    static void Main(string[] args)
    {
        //function call
            string randomString = genRoom("START", 0); // Start with depth 0
        //display the room
            Console.Write(randomString);
        //Add the exit at the end
            Console.Write("EXIT");
    }

    static string genRoom(string symbol, int numCount)
    {
        
        if (symbol == "START")
        {
            numCount = numCount + 3;
            return "START" + " -> " + genRoom("ROOM", numCount) + genRoom("CONTENT", numCount);
        }
        else if (symbol == "CONTENT")
        {
            int choice = random.Next(3);
            if (choice == 0)
            {
                numCount = numCount + 1;
                return genRoom("ROOM", numCount);
            }
            else if (choice == 1 && keyNum < 2)
            {
                keyNum = keyNum + 1;
                numCount = numCount + 4;
                return genRoom("KEY", numCount) + genRoom("CONTENT", numCount) + genRoom("LOCK", numCount) + genRoom("CONTENT", numCount);
            }
            else
            {
                numCount = numCount + 1;
                return genRoom("CONTENT", numCount);
            }
        }
        else if (symbol == "ROOM")
        {
            return "ROOM" + " -> ";
        }
        else if (symbol == "KEY")
        {
            return "KEY" + " -> ";
        }
        else if (symbol == "LOCK")
        {
            return "LOCK" + " -> ";
        }
        else
        {
            return "";
        }
    }
}
